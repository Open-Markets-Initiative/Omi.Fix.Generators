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
        /// Constructs component from field element
        /// </summary>
        public static Component From(Fix.Specification.Field element)
            => new Component 
            {
                Name = element.Name,
            };

        /// <summary>
        /// Writes component to XML file
        /// </summary>
        public void Write(System.IO.StreamWriter stream) // need one with different indent
        {
            stream.WriteLine($"    <component name=\"{Name}\"/>");
        }

        /// <summary>
        /// Converts component to specification
        /// </summary>
        public Omi.Fix.Specification.Field ToSpecification()
            => new Omi.Fix.Specification.Field 
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