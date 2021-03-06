namespace Omi.Fix.Txt{
    using System.Collections.Generic;
    using System.Linq;
    using Omi.Fix.Specification;

    /// <summary>
    /// Name and data of corresponing enum
    /// </summary>
    public class Value
    {
        /// <summary>
        /// Name of value
        /// </summary>
        public string Name;

        /// <summary>
        /// Data or symbol for associated Name
        /// </summary>
        public string Data;

        /// <summary>
        /// Contains Value from properties
        /// </summary>
        public static Value From(string name, string data)
            => new Value 
            {
                Name = name,
                Data = data
            };

        /// <summary>
        /// Contains Value from string
        /// </summary>
        public static Value From(string pair)
        {
            // check valid input
            if (string.IsNullOrWhiteSpace(pair))  
            {
                throw new ArgumentException(nameof(pair));
            }

            var idx = pair.IndexOf("="); 
            if (idx < 0)
            {
                throw new ArgumentException(nameof(pair));  
            }

            // trim whitespace from string and find where name and data are split
            var pairnowhite = String.Concat(pair.Where(c => !Char.IsWhiteSpace(c)));
            var name = pairnowhite.Substring(0, pairnowhite.IndexOf("="));

            if (string.IsNullOrEmpty(name)) 
            {
                throw new ArgumentException(nameof(pair));  
            }

            var data = pairnowhite.Substring(pairnowhite.IndexOf("=")+1); 

            return From(name, data);
        }


        public override string ToString()
            => $"{Data} => {Name}";
    }
}