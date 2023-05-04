namespace Omi.Fixml {
    using System.Linq;

    /// <summary>
    ///  Fixml Component (predefined collection of elements)
    /// </summary>

    public class Component : IParent {

        /// <summary>
        ///  Fixml component name
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///  Fixml component elements list (fields, groups, components)
        /// </summary>
        public Elements Elements { get; set; } = new Elements();

        /// <summary>
        ///  Does component have fields?
        /// </summary>
        public bool HasFields
            => Elements.Any();

        /// <summary>
        ///  Convert xml component to fixml component
        /// </summary>
        public static Component From(Xml.fixComponent element) {
            // Verify values
            var component = new Component {
                Name = element.name
            };

            foreach (var item in element.Items) { // need ??
                component.Elements.Add(Child.Field.From(item, component));
            }

            return component;
        }

        /// <summary>
        /// Obtain fixml component from specification
        /// </summary>
        public static Component From(Fix.Specification.Component element) {
            // Verify values?
            var component = new Component {
                Name = element.Name
            };

            foreach (var item in element.Fields) {  // need ?? 
                component.Elements.Add(Child.Field.From(item, component));
            }

            return component;
        }

        /// <summary>
        ///  Write componenet to xml file 
        /// </summary>
        public void Write(StreamWriter stream) {
            if (HasFields) {
                stream.WriteLine($"    <component name=\"{Name}\">");
                
                Elements.Write(stream, 6);

                stream.WriteLine("    </component>");
            }
            else {
                stream.WriteLine($"    <component name=\"{Name}\"/>");
            }
        }

        /// <summary>
        ///  Convert to standardized specification component
        /// </summary>
        public Fix.Specification.Component ToSpecification()
            => new () {
                Name = Name,
                Fields = Elements.ToSpecification()
            };

        /// <summary>
        ///  Display fixml component as string
        /// </summary>
        public override string ToString()
            => $"{Name} [{Elements.Count}]";
    }
}