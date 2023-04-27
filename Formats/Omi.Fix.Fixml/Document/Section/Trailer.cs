namespace Omi.Fixml {
    using System.Linq;

    /// <summary>
    ///  Fixml Trailer section
    /// </summary>

    public class Trailer : IParent {

        /// <summary>
        ///  Fixml trailer child elements list (fields, groups, components)
        /// </summary>
        public Elements Elements { get; set; } = new Elements();

        /// <summary>
        ///  Does fixml trailer have elements?
        /// </summary>
        public bool HasFields
            => Elements.Any();

        /// <summary>
        ///  Convert xml file elements to fixml trailer
        /// </summary>
        public static Trailer From(Xml.fix xml) {
            var section = new Trailer();

            foreach (var field in xml.trailer) { // need ??
                // Verify format

                section.Elements.Add(new Child.Field {
                    Name = field.name,
                    Required = Is.Required(field.required),
                });
            }

            return section;
        }

        /// <summary>
        ///  Convert normalized specification trailer to fixml trailer
        /// </summary>
        public static Trailer From(Fix.Specification.Trailer trailer) {
            var section = new Trailer();

            foreach (var field in trailer) {
                // Verify format
                section.Elements.Add(new Child.Field {
                    Name = field.Name,
                    Required = field.Required,
                });
            }

            return section;
        }

        /// <summary>
        ///  Write fixml trailer out to stream
        /// </summary>
        public void Write(StreamWriter stream) {
            if (HasFields) {
                stream.WriteLine("  <trailer>");

                Elements.Write(stream, 2);

                stream.WriteLine("  </trailer>");
            }
            else {
                stream.WriteLine("  <trailer/>");
            }
        }

        /// <summary>
        ///  Convert fixml trailer to normalized fix specification trailer
        /// </summary>
        public Fix.Specification.Trailer ToSpecification() {
            var trailer = new Fix.Specification.Trailer();

            foreach (var element in Elements) {
                trailer.Add(element.ToSpecification());
            }
            
            return trailer;
        }
    }
}