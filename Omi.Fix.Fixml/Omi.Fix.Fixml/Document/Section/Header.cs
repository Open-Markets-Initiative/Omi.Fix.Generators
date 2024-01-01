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

            foreach (var item in ElementsIn(xml)) {
                section.Elements.Add(Child.Field.From(item, section));
            }

            return section;
        }

        /// <summary>
        ///  Array of header elements in fixml
        /// </summary>
        public static object[] ElementsIn(Xml.fix xml)
            => xml?.header.Items ?? Array.Empty<object>();


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
        public void Write(StreamWriter stream, Indent indent) {
            if (HasFields) {
                stream.WriteLine($"{indent}<header>");

                Elements.Write(stream, indent.Increment());

                stream.WriteLine($"{indent}</header>");
            }
            else
            {
                stream.WriteLine($"{indent}<header/>");
            }
        }

        /// <summary>
        ///  Report erroneous fixml header properties
        /// </summary>
        public void Error(Fields fields, Components components, List<string> Errors)
        {

            var repeats = Elements.GroupBy(x => x.Name)
              .Where(g => g.Count() > 1)
              .Select(y => y.Key)
              .ToList();
            if (repeats.Any())
            {
                foreach (var repeat in repeats)
                {
                    Errors.Add($"{repeat} : Tag occurs more than once in header");
                }
            }

            Elements.Error(fields, components, Errors);
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

        /// <summary>
        ///  Display header as string
        /// </summary>
        public override string ToString()
           => $"Count = {Elements.Count}";
    }
}