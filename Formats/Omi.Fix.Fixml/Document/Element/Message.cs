namespace Omi.Fixml {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///  Fixml Message
    /// </summary>

    public class Message {

        #region Properties
        ///////////////////////////////////////////////////////

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
        ///  Fixml message child elements list (fields, groups, components)
        /// </summary>
        public Elements Elements = new ();

        #endregion

        /// <summary>
        ///  Convert xml element to fixml message 
        /// </summary>
        public static Message From(Xml.fixMessage element)
            => new () {
                Name = element.name,
                Type = element.msgtype,
                Category = element.msgcat,
                Elements = Elements.From(element.Items)
            };

        /// <summary>
        ///  Convert normalized specification messages to fixml messages 
        /// </summary>
        public static Message From(Fix.Specification.Message element)
            => new () {
                Name = element.Name,
                Type = element.Type,
                Category = element.Category,
                Elements = Elements.From(element.Fields)
            };

        /// <summary>
        /// Write fixml message to file
        /// </summary>
        public void Write(StreamWriter stream) {
            if (HasFields) {
                stream.WriteLine($"    <message name=\"{Name}\" msgtype=\"{Type}\" msgcat=\"{Category}\">");

                foreach (var child in Elements) {
                    child.Write(stream);
                }

                stream.WriteLine( "    </message>");
            }
            else {
                stream.WriteLine($"    <message name=\"{Name}\" msgtype=\"{Type}\" msgcat=\"{Category}\"/>");
            }
        }

        /// <summary>
        ///  Does message have fields?
        /// </summary>
        public bool HasFields
            => Elements.Any();

        /// <summary>
        ///  Convert to normalized fix specification message
        /// </summary>
        public Fix.Specification.Message ToSpecification()
            => new () {
                Type = Type, 
                Name = Name, 
                Category = Category,
                Fields = Elements.ToSpecification()
            };

        /// <summary>
        ///  Verify fixml message properties
        /// </summary>
        public void Verify(Fields fields, Components components) {
            if (string.IsNullOrWhiteSpace(Name)) {
                throw new Exception("Message name is missing");
            }

            if (string.IsNullOrWhiteSpace(Type)) {
                throw new Exception("Message type is missing");
            }

            Elements.Verify(fields, components);
        }

        /// <summary>
        ///  Display fixml message as string
        /// </summary>
        public override string ToString()
            => $"{Name} [{Elements.Count}]";
    }
}