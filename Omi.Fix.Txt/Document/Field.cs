namespace Omi.Fix.Txt
{
    using System.Linq;

    /// <summary>
    ///  Fix Field Declaration
    /// </summary>
    public class Field
    {

        #region Properties
        ///////////////////////////////////////////////////

        /// <summary>
        ///  Fix Field Tag/Number
        /// </summary>
        public string Number;

        /// <summary>
        ///  Fix Field Name
        /// </summary>
        public string Name;

        /// <summary>
        ///  Fix Field Underlying Type (int/string/etc)
        /// </summary>
        public string Type;

        #endregion

        /// <summary>
        /// Returns fix Field from string
        /// </summary>
        public static Field From(string line, Enums enums)
         => new Field
         {
             Number = Field.NumberFrom(line),
             Name = Field.NameFrom(line),
             Type = Field.TypeFrom(line, enums)

         };

        /// <summary>
        /// Returns fix field from properties
        /// </summary>
        public static Field From(string number, string name, string type)
         => new Field
         {
             Number = number,
             Name = name,
             Type = type,

         };

        /// <summary>
        /// Returns field number from line
        /// </summary>
        public static string NumberFrom(string line)
        {
            string shorten = line;

            if (Field.IsValidLine(line))
            {
                // trim line to only contain field properties
                if (line.Contains("#"))
                {
                    var cutString = line.Substring(0, line.IndexOf("#"));
                    shorten = String.Concat(cutString.Where(c => !Char.IsWhiteSpace(c)));  
                }

                // split properties as a colon seperated list, throw an exception for invalid lines
                var split = shorten.Split(':');

                if (split.Length != 3)
                {
                    throw new Exception("missing field values");
                }

                var numero = split[0];
                return numero;
            }

            else
            {
                throw new Exception("invalid line");
            }

        }

        /// <summary>
        /// Returns field name from line
        /// </summary>
        public static string NameFrom(string line)
        {
            string shorten = line;

            if (IsValidLine(line))
            {
                // trim line to only contain field properties
                if (line.Contains("#"))
                {
                    var cutString = line.Substring(0, line.IndexOf("#"));
                    shorten = String.Concat(cutString.Where(c => !Char.IsWhiteSpace(c))); 
                }

                // split properties as a colon seperated list, throw exception on invalid lines
                var split = shorten.Split(':');

                if (split.Length != 3)
                {
                    throw new Exception("missing field values");
                }

                var nombre = split[1];
                return nombre;
            }

            else
            {
                throw new Exception("invalid line");
            }
        }

        /// <summary>
        /// Returns field type from line
        /// </summary>
        public static string TypeFrom(string line, Enums enums)
        {
            string shorten = line;

            if (IsValidLine(line))
            {
                // trim line to only contain field properties
                if (line.Contains("#"))
                {
                    var cutString = line.Substring(0, line.IndexOf("#"));
                    shorten = String.Concat(cutString.Where(c => !Char.IsWhiteSpace(c)));  
                }

                // split properties as a colon seperated list, except invalid lines
                var split = shorten.Split(':');

                if (split.Length != 3)
                {
                    throw new Exception("missing field values");
                }

                var type = split[2];

                // convert type to valid fix
                if (type.Contains("datetime"))
                {
                    type = "UTCTimeStamp";
                }
                if (type.Contains("Bool"))
                {
                    type = "Boolean";
                }

                // if type is valid, return type
                if (IsValidType(type))
                {
                    return type;
                }

                // for invalid types, check if type exists among enums
                if (enums.ContainsKey(type) && !IsValidType(type))
                {
                    // infer type from enum values
                    var enumtypes = enums[type];
                    type = GetTypeFromEnum(enumtypes);
                    return type;
                }
                else
                {
                    throw new ArgumentException(type, "invalid type");
                }
            }

            else
            {
                throw new Exception("invalid line");
            }
        }

        /// <summary>
        /// check that line contains field properties
        /// </summary>
        public static bool IsValidLine(string line)
        {
            var idx = line.IndexOf(":enum:"); 

            // line is empty
            if (String.IsNullOrWhiteSpace(line))
            {
                throw new ArgumentException(nameof(line));
            }

            // line is an enum
            if (idx > 0)
            {

                throw new ArgumentException(nameof(line));  
            }

            // line is a comment
            if (line[0].Equals("#"))
            {
                throw new ArgumentException(nameof(line));
            }

            return true;
        }

        // Check that type is valid fix
        public static bool IsValidType(string type)
        {
            var validtypes = new List<string>();
            var lines = File.ReadLines(@"D:\git_users\Sophia\fixgenerators\Omi.Fix.Txt\ValidTypes.txt");

            foreach (var line in lines)
            {
                validtypes.Add(line.ToLower().Trim());   
            }

            if (validtypes.Contains(type.ToLower()))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Obtain type from associated enum
        /// </summary>
        public static string GetTypeFromEnum(Enum enumerator)
        {
            // only checks if int or not an int
            var type = "string";
            var values = enumerator.Values;
            var maybeint = false;

            // If all enum values can be parsed, set to int
            foreach (var value in values)
            {
                if (Int16.TryParse(value.Data, out var val))
                {
                    maybeint = true;
                }
                else
                {
                    maybeint = false;
                }
            }

            if (maybeint)
            {
                type = "int";
            }

            return type;
        }

        /// <summary>
        /// Converts enums to normalized fix specification
        /// </summary>
        public Fix.Specification.Type ToSpecification(Enums enums)
        {
            var type = new Fix.Specification.Type();
            type.Tag = (uint)Int16.Parse(Number);
            type.Name = Name;
            type.Underlying = (Type).ToUpper();
            type.Enums = enums.ToSpecification(Name);

            return type;
        }

        public override string ToString()
            => $"{Number} => {Name}, {Type}";
    }
}