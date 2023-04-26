namespace Omi.Fixml {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///  Fixml Component (predefined collection of elements)
    /// </summary>

    public class Component {

        /// <summary>
        ///  Fixml component name
        /// </summary>
        public string Name { get; set;}

        /// <summary>
        ///  Fixml component fields list
        /// </summary>
        public List<IChild> Fields = new List<IChild>();

        /// <summary>
        ///  Convert fixml component from xml
        /// </summary>
        public static Component From(Xml.fixComponent element) {
            // Verify values
            var component = new Component
            {
                Name = element.name,
            };

            foreach (var item in element.Items) // need ??
            {
                component.Fields.Add(Child.Field.From(item));
            }

            return component;
        }

        /// <summary>
        /// Obtain fixml component from specification
        /// </summary>
        public static Component From(Fix.Specification.Component element) {
            // Verify values?
            var component = new Component {
                Name = element.Name,
            };

            foreach (var item in element.Fields) {  // need ?? 
                component.Fields.Add(Child.Field.From(item));
            }

            return component;
        }

        /// <summary>
        /// Write componenet to xml file 
        /// </summary>
        public void Write(StreamWriter stream) {
            if (HasFields) {
                stream.WriteLine($"    <component name=\"{Name}\">");
                
                foreach (var child in Fields) {
                    child.Write(stream);
                }

                stream.WriteLine("    </component>");
            }
            else {
                stream.WriteLine($"    <component name=\"{Name}\"/>");
            }
        }

        /// <summary>
        ///  Does component have fields?
        /// </summary>
        public bool HasFields
            => Fields.Any();

        /// <summary>
        ///  Convert to standardized specification component
        /// </summary>
        public Fix.Specification.Component ToSpecification()
            => new () {
                Name = Name,
                Fields = Fields.Select(field => field.ToSpecification()).ToList() // sub method
            };

        /// <summary>
        ///  Display fixml component as string
        /// </summary>
        public override string ToString()
            => $"{Name} [{Fields.Count}]";
    }
}