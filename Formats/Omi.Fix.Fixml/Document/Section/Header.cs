namespace Omi.Fixml {
    using System.Linq;

    /// <summary>
    ///  Fixml headers section
    /// </summary>

    public class Header : IParent {

        /// <summary>
        ///  Fixml header child elements list (fields, groups, components)
        /// </summary>
        public Elements Elements { get; set; } = new Elements();

        /// <summary>
        ///  Does fixml header have elements?
        /// </summary>
        public bool HasFields
            => Elements.Any();

        /// <summary>
        /// Header components from xml file
        /// </summary>
        public static Header From(Xml.fix xml) {
            var section = new Header();

            foreach (var field in xml.header) {  // need ??
                // Verify format
                section.Elements.Add(new Child.Field { // can these be groups/components
                    Name = field.name,
                    Required = Is.Required(field.required),
                    Parent = section
                });
            }

            return section;
        }

        /// <summary>
        ///  Convert normalized fix specification headers to fixml headers section
        /// </summary>
        public static Header From(Fix.Specification.Header header) {
            var section = new Header();

            foreach (var element in header) {
                section.Elements.Add(Child.Field.From(element, section));
            }

            return section;
        }

        /// <summary>
        ///  Write header out to Fixml
        /// </summary>
        public void Write(StreamWriter stream) {
            if (HasFields) {
                stream.WriteLine("  <header>");

                Elements.Write(stream);

                stream.WriteLine("  </header>");
            }
            else
            {
                stream.WriteLine("  <header/>");
            }
        }

        /// <summary>
        ///  Convert fixml trailer to normalized fix specification trailer
        /// </summary>
        public Fix.Specification.Header ToSpecification() {
            var header = new Fix.Specification.Header();

            foreach (var element in Elements) {
                header.Add(element.ToSpecification());
            }
            
            return header;
        }
    }
}