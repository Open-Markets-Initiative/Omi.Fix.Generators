namespace Omi.Fixml {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///  Fixml Components Xml Element (Components Section)
    /// </summary>

    public class Components : Dictionary<string, Component> {

        /// <summary>
        /// Convert from xml  to fixml component 
        /// </summary>
        public static Components From(Xml.fix xml) {
            var section = new Components();

            foreach (var element in ListFrom(xml)) {
                var component = Component.From(element);
                section[component.Name] = component; 
            }

            return section;
        }

        /// <summary>
        /// Fix Component from xml file
        /// </summary>
        public static Xml.fixComponent[] ListFrom(Xml.fix xml)
            => xml.components ?? Array.Empty<Xml.fixComponent>();

        /// <summary>
        ///  Convert normalized fix specification components to fixml components 
        /// </summary>
        public static Components From(Fix.Specification.Components components) {  // make this a dictionary also
            var section = new Components();

            foreach (var element in components) {
                var component = Component.From(element);
                section[component.Name] = component;
            }

            return section;
        }

        /// <summary>
        ///  Write components out to Fixml
        /// </summary>
        public void Write(StreamWriter stream) {
            if (this.Any()) {
                stream.WriteLine("  <components>");

                foreach (var component in Values) { // should sort
                    component.Write(stream);
                }

                stream.WriteLine("  </components>"); 
            }
            else {
                stream.WriteLine("  <components/>");
            }
        }

        /// <summary>
        ///  Convert fixml components section to normalized fix specification components
        /// </summary>
        public Fix.Specification.Components ToSpecification() {
            var components = new Fix.Specification.Components();

            foreach (var component in Values) {
                components.Add(component.ToSpecification());
            }
            
            return components;
        }
    }
}