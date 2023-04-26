namespace Omi.Fixml.Child {
    using Omi.Fix.Specification;

    /// <summary>
    ///  Fix Xml Component Element
    /// </summary>

    public class Component : IChild {

        /// <summary>
        ///  Name of child component
        /// </summary>
        public string Name { get; set;} // how to deal with this

        /// <summary>
        ///  Convert child components from Xml element
        /// </summary>
        public static Component From(Xml.fixChildComponent element) {
            // Verify values

            return new Component {
                Name = element.name,
            };
        }

        /// <summary>
        /// Constructs component from field element
        /// </summary>
        public static Component From(Fix.Specification.Field element)
            => new () {
                Name = element.Name,
            };

        /// <summary>
        ///  Convert fixml component to normalized specification component
        /// </summary>
        public Fix.Specification.Field ToSpecification()
            => new () {
                Kind = Kind.Component,
                Name = Name,
            };

        /// <summary>
        ///  Writes component to fixml stream
        /// </summary>
        public void Write(StreamWriter stream)  {
            stream.WriteLine($"      <component name=\"{Name}\"/>");
        }

        /// <summary>
        ///  Verify fixml component element
        /// </summary>
        public void Verify(Fields fields, Fixml.Components components) {
            if (string.IsNullOrWhiteSpace(Name)) {
                throw new Exception("Component name is missing");
            }

            if (!components.ContainsKey(Name)) {
                throw new Exception($"{Name}: Component is missing from dictionary");
            }
        }

        /// <summary>
        ///  Display Fixml child component as string
        /// </summary>
        public override string ToString()
            => $"{Name} [Component]";
    }
}