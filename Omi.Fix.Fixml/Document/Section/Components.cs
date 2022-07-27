namespace Omi.Fixml {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///  Fixml Components Xml Element (Components Section)
    /// </summary>
    public class Components : List<Component> {

        /// <summary>
        /// default constructor
        /// </summary>
        public Components()
        { }

        /// <summary>
        /// Constructor from IEnumerable
        /// </summary>
        public Components(IEnumerable<Component> components)
        { 
            AddRange(components);
        }

        /// <summary>
        /// convert from xml  to fixml component 
        /// </summary>
        public static Components From(Xml.fix xml)
            => new Components(ListFrom(xml).Select(Component.From));

        /// <summary>
        /// FixComponent from xml file
        /// </summary>
        public static Xml.fixComponent[] ListFrom(Xml.fix xml)
            => xml.components ?? new Xml.fixComponent[0];


        /// <summary>
        ///  Gather fixml components list from normalized fix specification 
        /// </summary>
        public static Components From(Fix.Specification.Components components)
            => new Components(components.Select(Component.From));


        /// <summary>
        ///  Write components out to Fixml
        /// </summary>
        public void Write(StreamWriter stream)
        {
            if (this.Any())
            {
                stream.WriteLine("  <components>");

                foreach (var component in this)
                {
                    component.Write(stream);
                }

                stream.WriteLine("  </components>"); 
            }
            else
            {
                stream.WriteLine("  <components/>");
            }
        }

        /// <summary>
        ///  Convert fixml components section to normalized fix specification components
        /// </summary>
        public Fix.Specification.Components ToSpecification()
        {
            var components = new Fix.Specification.Components();

            foreach (var component in this)
            {
                components.Add(component.ToSpecification());
            }
            
            return components;
        }
    }
}