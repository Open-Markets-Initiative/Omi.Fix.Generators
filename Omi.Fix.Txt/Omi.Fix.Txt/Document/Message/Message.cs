namespace Omi.Fix.Txt{
    using System.Collections.Generic;
    using System.Linq;
    using Omi.Fix.Specification;

    /// <summary>
    /// Types of FIX messages in text file
    /// </summary>
    public class Message {
    
        /// <summary>
        /// 
        /// </summary>
        public string Name = string.Empty;

        public string Type = string.Empty;

        public string Category = string.Empty;

        public Groups Elements = new Groups();

        /// <summary>
        /// Message contructor from properties
        /// </summary>
        public static Message From(string name, string type, string category, Groups elements)
            => new Message {
                Name = name,
                Type = type,
                Category = category,
                Elements = elements
            };

        /// <summary>
        /// Message contructor from string
        /// </summary>
        public static Message From(string line)
        {
            var message = new Message();
            
            // Check for validitry and trim line
            if (line.Contains("#"))
            {
                var cutString = line.Substring(0, line.IndexOf("#"));
                line = String.Concat(cutString.Where(c => !Char.IsWhiteSpace(c)));
            }

            // Split line by colon and obtain properties
            var msgarray = line.Split(':');

            var name = msgarray[0];
            var category = msgarray[1];
            var type = msgarray[2];
            var elements = Groups.From(msgarray[3]); 

            return From(name, category, type, elements);
        }

        /// <summary>
        /// Obtain Fix specification for message from text
        /// </summary>
        /// <returns></returns>
        public Specification.Message ToSpecification()
        => new Specification.Message
        {
            Name = Name,
            Type = Type,
            Category = Category,
            Fields = this.Elements.ToSpecification()
        };
        
        public override string ToString()
            => $"{Name} => {Type}, {Category}";

        
        
    }
}