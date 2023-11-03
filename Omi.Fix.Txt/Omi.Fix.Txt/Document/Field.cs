namespace Omi.Fix.Txt {
    using System;
    using System.Linq;
    using System.Security.AccessControl;
    using static System.Net.Mime.MediaTypeNames;

    /// <summary>
    ///  Fix Txt Field Record
    /// </summary>

    public class Field {


        /// <summary>
        ///  Fix Field Tag/Number
        /// </summary>
        public string Number = string.Empty;

        /// <summary>
        ///  Fix Field Name
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        ///  Fix Field Underlying Type (int/string/etc)
        /// </summary>
        public string Type = string.Empty;


        /// <summary>
        /// Returns fix Field from string
        /// </summary>
        public static Field From(string line, Enums enums)
         => new () {
             Number = NumberFrom(line),
             Name = NameFrom(line),
             Type = TypeFrom(line, enums)
         };

        /// <summary>
        /// Returns fix field from properties
        /// </summary>
        public static Field From(string number, string name, string type)
         => new () {
             Number = number,
             Name = name,
             Type = type,
         };

        /// <summary>
        /// Returns field number from line
        /// </summary>
        public static string NumberFrom(string line)
        {
            if (!IsValidLine(line))
            {
                throw new ArgumentException($"Invalid line: {line}");
            }
            
            var tokens = TrimLine(line).Split(':');

            if (InvalidSplit(tokens))
            {
                throw new ArgumentException($"Invalid field record: {line}");
            }

            return tokens[0];
        }

        /// <summary>
        /// Returns field name from line
        /// </summary>
        public static string NameFrom(string line)
        {
            if (!IsValidLine(line))
            {
                throw new ArgumentException($"Invalid line: {line}");
            }

            var tokens = TrimLine(line).Split(':');

            if (InvalidSplit(tokens))
            {
                throw new ArgumentException($"Invalid field record: {line}");
            }

            return tokens[1];
        }

        /// <summary>
        /// Returns field type from line
        /// </summary>
        public static string TypeFrom(string line, Enums enums)
        {
            if (!IsValidLine(line))
            {
                throw new ArgumentException($"Invalid line: {line}");
            }
            
            var tokens = TrimLine(line).Split(':');

            if (InvalidSplit(tokens))
            {
                throw new ArgumentException($"Invalid field record: {line}");
            }

            return ConvertType(tokens[2]);
        }

        ///<summary>
        /// Removes comments and white space from line.
        /// </summary>
        public static string TrimLine(string line)
        {
            var index = line.IndexOf("#");

            if (index > 0)
            {
                line = String.Concat(line[..index].Where(c => !Char.IsWhiteSpace(c)));
            }
            return line;
        }

        ///<summary>
        ///Checks that string array is valid
        ///</summary>
        public static bool InvalidSplit(string[] split)
        {
            if(split.Length != 3)
            {
                return true;
            }

            foreach(string field in split){

                if (string.IsNullOrWhiteSpace(field))
                {
                    return true;
                }

            }

            return false;
        }
        
        /// <summary>
        /// Check that line contains field properties
        /// </summary>
        public static bool IsValidLine(string line) {
            // Verify Line is not empty
            if (string.IsNullOrWhiteSpace(line)) {
                throw new ArgumentException(nameof(line));
            }

            var index = line.IndexOf(":enum:"); 

            // Verify line is an enum
            if (index > 0) {
                throw new ArgumentException(nameof(line));  
            }

            // Line is a comment
            if (line[0].Equals("#")) {
                throw new ArgumentException(nameof(line));
            }

            return true;
        }

        /// <summary>
        ///  Check that type is valid fix (TODO full list...add underlying type)
        /// </summary>
        public static string ConvertType(string text) {
            var type = text.Trim();

            switch (type) {
                case "datetime":
                    return "UTCTimeStamp";
                case "bool":
                case "Boolean":
                    return "Boolean";

                case "char":
                case "data":
                case "float":
                case "Amt":
                case "PriceOffset":
                case "Qty":
                case "int":
                case "day-of-month":
                case "String":
                case "Currency":
                case "exchange":
                case "LocalMktDate":
                case "month - year":
                case "MultipleValueString":
                case "UTCDate":
                case "UTCTimeOnly":
                case "long":
                    return type;

                default:
                    return "String";
            }
        }

        /// <summary>
        ///  Converts enums to normalized fix specification
        /// </summary>
        public Specification.Type ToSpecification(Enums enums)
            => new () {
                Tag = NormalizeTag(Number),
                Name = Name,
                Underlying = NormalizeType(Name, Type, enums),
                Enums = enums.ToSpecification(Name)
            };

        /// <summary>
        ///  Normalize tag
        /// </summary>
        public uint NormalizeTag(string text)
            => uint.Parse(text);

        /// <summary>
        ///  Normalize type
        /// </summary>
        public string NormalizeType(string name, string text, Enums enums) {
            var type = text.Trim();

            if (enums.ContainsKey(name)) {
                return enums.TypeFor(name);
            }

            return type.ToUpper();
        }

        /// <summary>
        /// Display fix txt type
        /// </summary>
        public override string ToString()
            => $"{Number} => {Name}, {Type}";
    }
}