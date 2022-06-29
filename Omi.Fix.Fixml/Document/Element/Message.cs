namespace Omi.Fixml {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///  Fixml Message
    /// </summary>
    public class Message {

        #region Properties
        public string Name { get; set;}

        public string Type { get; set;}

        public string Category { get; set;}

        public List<IChild> Fields = new List<IChild>();

        #endregion

        /// <summary>
        /// Convert xml message to fixml format
        /// </summary>
        public static Message From(Xml.fixMessage element)
        {
            // verify values
            var message = new Message
            {
                Name = element.name,
                Type = element.msgtype,
                Category = element.msgcat
            };

            foreach (var item in element.Items) // need ??
            {
                message.Fields.Add(Child.Field.From(item));
            }

            return message;
        }

        /// <summary>
        /// obtain fixml message from specification 
        /// </summary>
        public static Message From(Fix.Specification.Message element) {
            // verify values
            var message = new Message
            {
                Name = element.Name,
                Type = element.Type,
                Category = element.Category
            };

            foreach (var item in element.Fields) // need ??
            {
                message.Fields.Add(Child.Field.From(item));
            }

            return message;
        }


        /// <summary>
        /// write fixml mmessage to file
        /// </summary>
        public void Write(System.IO.StreamWriter stream) // need one with different indent
        {
            if (HasFields) // need indents
            {
                stream.WriteLine($"    <message name=\"{Name}\" msgtype=\"{Type}\" msgcat=\"{Category}\">");
                
                foreach (var child in Fields)
                {
                    child.Write(stream);
                }

                stream.WriteLine("    </message>");
            }
            else
            {
                stream.WriteLine($"    <message name=\"{Name}\" msgtype=\"{Type}\" msgcat=\"{Category}\"/>");
            }
        }

        public bool HasFields
            => Fields.Any();


        /// <summary>
        ///  Convert to standardized specification message
        /// </summary>
        public Fix.Specification.Message ToSpecification()
            => new Fix.Specification.Message {
                Type = Type, 
                Name = Name, 
                Category = Category,
                Fields = Fields.Select(field => field.ToSpecification()).ToList()
            };

        /// <summary>
        ///  Display Fixml message as string
        /// </summary>
        public override string ToString()
            => $"{Name} [{Fields.Count}]";
    }
}