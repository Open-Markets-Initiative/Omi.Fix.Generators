namespace Omi.Fix.Txt{
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Tag name and range of values
    /// </summary>
    public class Enum
    {
        /// <summary>
        /// The tag name associated with the Enum
        /// </summary>
        public string Name;

        /// <summary>
        /// List of each enum present for a given tag 
        /// </summary>
        public List<Value> Values = new List<Value>();

        /// <summary>
        /// Constructs an enum based on a line in the txt file
        /// </summary>
        public static Enum From(string line)
            => new Enum
            {
                Name = NameFrom(line),
                Values = ValuesFrom(line)
            };

        /// <summary>
        /// Gets the name of an enum from a given line,
        /// Throws an exception for invalid lines
        /// </summary>
        public static string NameFrom(string line)
        {
            // Check if line is a comment
            if (line[0].Equals("#"))
            {
                throw new ArgumentException(nameof(line));
            }

            // Check that line contains enum
            var idx = line.IndexOf(":enum:");

            if (idx < 0)
            {
                throw new ArgumentException(nameof(line));  
            }

            // Check that line contains a non-null name
            var name = line.Substring(0, line.IndexOf(":enum:"));

            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException(nameof(line));  
            }

            return name;
        }

        /// <summary>
        /// Gets the list of each value present in a given enum line
        /// </summary>
        public static List<Value> ValuesFrom(string line)  
        {
            // Validate line
            if (line[0].Equals("#"))
            {
                throw new ArgumentException(nameof(line));
            }

            var idx = line.IndexOf(":enum:");  

            if (idx < 0)  
            {
                throw new ArgumentException(nameof(line));  
            }

            if (string.IsNullOrEmpty(line))
            {
                throw new ArgumentException(nameof(line));
            }

            // Get string to a comma-seperated list of value pairs
            string valuestring;

            // Comments are valid, but not the entire line
            if (line.Contains("#") && !line[0].Equals("#")) 
            {
                var cutString = line.Substring(line.IndexOf(":enum:")+6, line.IndexOf("#"));
                valuestring = String.Concat(cutString.Where(c => !Char.IsWhiteSpace(c)));  
            }

            else
            {
                var cutString = line.Substring(line.IndexOf(":enum:")+6);
                valuestring = String.Concat(cutString.Where(c => !Char.IsWhiteSpace(c)));
            }

            // Split string and add values to list 
            var split = valuestring.Split(",");
            var val = new List<Value>();

            foreach (var pair in split)  
            {
                val.Add(Value.From(pair));
            }

            return val;
        }

        
        /// <summary>
        /// Get enum to specification 
        /// </summary>
        public static Specification.Enum ToSpecification(Value line)
        {
            var enumiumie = new Specification.Enum();
            enumiumie.Value = line.Data;
            enumiumie.Description = line.Name;

            return enumiumie;
        }
        public override string ToString()
           => $"{Name} = {Values}";

    }
}