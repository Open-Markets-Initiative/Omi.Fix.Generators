namespace Omi.Fix.Txt{
    using System.Linq;

    /// <summary>
    /// Name and data of corresponing enum
    /// </summary>

    public class Value {

        /// <summary>
        /// Name of value
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        /// Data or symbol for associated Name
        /// </summary>
        public string Data = string.Empty;

        /// <summary>
        /// Contains Value from properties
        /// </summary>
        public static Value From(string name, string data)
            => new () {
                Name = name,
                Data = data
            };

        /// <summary>
        /// Contains Value from string
        /// </summary>
        public static Value From(string pair) {
            // Check valid input
            if (string.IsNullOrWhiteSpace(pair))  
            {
                throw new ArgumentException(nameof(pair));
            }

            var idx = pair.IndexOf("="); 
            if (idx < 0)
            {
                throw new ArgumentException(nameof(pair));  
            }

            // Trim whitespace from string and find where name and data are split
            var pairnowhite = String.Concat(pair.Where(c => !Char.IsWhiteSpace(c)));
            var name = pairnowhite.Substring(0, pairnowhite.IndexOf("="));

            if (string.IsNullOrEmpty(name)) 
            {
                throw new ArgumentException(nameof(pair));  
            }

            var data = pairnowhite.Substring(pairnowhite.IndexOf("=")+1); 

            return From(name, data);
        }

        /// <summary>
        ///  Display enumerated value
        /// </summary>
        public override string ToString()
            => $"{Data} => {Name}";
    }
}