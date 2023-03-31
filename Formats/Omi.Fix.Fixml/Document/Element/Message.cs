namespace Omi.Fixml {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///  Fixml Message
    /// </summary>

    public class Message {

        #region Properties

        /// <summary>
        ///  Fixml message name
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        ///  Fixml message type
        /// </summary>
        public string Type = string.Empty;

        /// <summary>
        ///  Fixml message category
        /// </summary>
        public string Category = string.Empty;

        /// <summary>
        ///  Fixml message child fields list
        /// </summary>
        public List<IChild> Fields = new List<IChild>();

        #endregion

        /// <summary>
        /// Convert xml message to fixml format
        /// </summary>
        public static Message From(Xml.fixMessage element) {
            // Verify values
            var message = new Message {
                Name = element.name,
                Type = element.msgtype,
                Category = element.msgcat
            };

            foreach (var item in element.Items) {  // need ?? 
                message.Fields.Add(Child.Field.From(item));
            }

            return message;
        }

        /// <summary>
        /// Obtain fixml message from specification 
        /// </summary>
        public static Message From(Fix.Specification.Message element) {
            var message = new Message {
                Name = element.Name,
                Type = element.Type,
                Category = element.Category
            };

            foreach (var item in element.Fields)  {
                message.Fields.Add(Child.Field.From(item));
            }

            return message;
        }

        /// <summary>
        /// Write fixml message to file
        /// </summary>
        public void Write(StreamWriter stream) {
            if (HasFields) {
                stream.WriteLine($"    <message name=\"{Name}\" msgtype=\"{Type}\" msgcat=\"{Category}\">");

                foreach (var child in Fields) {
                    child.Write(stream);
                }

                stream.WriteLine("    </message>");
            }
            else {
                stream.WriteLine($"    <message name=\"{Name}\" msgtype=\"{Type}\" msgcat=\"{Category}\"/>");
            }
        }

        /// <summary>
        ///  Does message have fields
        /// </summary>
        public bool HasFields
            => Fields.Any();

        /// <summary>
        ///  Convert to normalized fix specification message
        /// </summary>
        public Fix.Specification.Message ToSpecification()
            => new () {
                Type = Type, 
                Name = Name, 
                Category = Category,
                Fields = Fields.Select(field => field.ToSpecification()).ToList()
            };

        /// <summary>
        ///  Verify message properties
        /// </summary>
        public void Verify(Fields fields, Components components) {
            if (string.IsNullOrWhiteSpace(Name)) {
                throw new Exception("Message name is missing");
            }

            if (string.IsNullOrWhiteSpace(Type)) {
                throw new Exception("Message type is missing");
            }

            foreach (var field in Fields) {
                field.Verify(fields, components);
            }
        }

        /// <summary>
        ///  Display fixml message as string
        /// </summary>
        public override string ToString()
            => $"{Name} [{Fields.Count}]";
    }
}