namespace Omi.Fixml.Child {
    
    using Omi.Fix.Specification;

    public class Component : IChild
    {
        /// <summary>
        ///  name of child component
        /// </summary>
        public string Name { get; set;}

        /// <summary>
        /// obtains child components from Xml element
        /// </summary>
        public static Component From(Xml.fixChildComponent element)
        {
            // verify values
            var component = new Component
            {
                Name = element.name,
            };

            return component;
        }

        /// <summary>
        /// Write child component to stream with appropriate indent 
        /// </summary>
        public void Write(StreamWriter stream, IChild child)
        {
            stream.WriteLine($"      <component name=\"{child.Name}\"/>");
        }

        /// <summary>
        /// Constructs component from field element
        /// </summary>
        public static Component From(Fix.Specification.Field element)
            => new () {
                Name = element.Name,
            };

        /// <summary>
        /// Writes component to XML file
        /// </summary>
        public void Write(StreamWriter stream) 
        {
            stream.WriteLine($"      <component name=\"{Name}\"/>");
        }

        /// <summary>
        /// Converts component to specification
        /// </summary>
        public Fix.Specification.Field ToSpecification()
            => new Fix.Specification.Field 
            {
                Kind = Kind.Component,
                Name = Name, 
            };

        /// <summary>
        ///  Display Fixml child component as string
        /// </summary>
        public override string ToString()
            => $"{Name} [Component]";
    }
}