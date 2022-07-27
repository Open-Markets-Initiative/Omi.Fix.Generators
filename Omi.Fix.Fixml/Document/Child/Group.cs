namespace Omi.Fixml.Child {
    using System.Collections.Generic;
    using System.Linq;
    using Omi.Fix.Specification;

    /// <summary>
    /// Group of children associated with an element
    /// </summary>
    public class Group : List<IChild>, IChild {

        /// <summary>
        /// name of Parent 
        /// </summary>
        public string Name { get; set;}

        /// <summary>
        /// true if tag is required in message, false otherwise
        /// </summary>
        public bool Required { get; set;}

        /// <summary>
        /// obtain group from children
        /// </summary>
        public static Group From(Xml.fixChildGroup element)
        {
            // verify values
            var group = new Group
            {
                Name = element.name,
                Required = Is.Required(element.required)
            };

            foreach (var item in element.Items) 
            {
                group.Add(Field.From(item));
            }

            return group;
        }

        /// <summary>
        /// obtain group from field 
        /// </summary>
        public static Group From(Fix.Specification.Field element)
        {
            var group = new Group
            {
                Name = element.Name,
                Required = element.Required
            };

            foreach (var item in element.Children)
            {
                group.Add(Field.From(item));
            }

            return group;
        }
       public void Write(StreamWriter stream, IChild child)
        {
            stream.WriteLine($"        <{Extensions.ToSpecification(child).Kind.ToString().ToLower()} name=\"{child.Name}\" required=\"{(Required ? 'Y' : 'N')}\"/>");
        }
        /// <summary>
        /// Write groups to xml file 
        /// </summary>
        public void Write(StreamWriter stream) // need one with different indent
        {
            if (HasFields) 
            {
                stream.WriteLine($"      <group name=\"{Name}\" required=\"{(Required ? 'Y' : 'N')}\">");
                
                foreach (var child in this)
                {
                   Write(stream, child); 
                }

                stream.WriteLine("      </group>");
            }
            else
            {
                stream.WriteLine($"        <group name=\"{Name}\" required=\"{(Required ? 'Y' : 'N')}\"/>");
            }
        }

        /// <summary>
        /// True is group has associated fields, false otherwise
        /// </summary>
        public bool HasFields
            => this.Any();

        /// <summary>
        /// converts group tp fix specification
        /// </summary>
        public Fix.Specification.Field ToSpecification()
        {
            var group = new Fix.Specification.Field
            {
                Kind = Kind.Group, 
                Name = Name, 
                Required = Required
            };

            foreach (var child in this)
            {
                group.Children.Add(child.ToSpecification());
            }

            return group;
        }

        /// <summary>
        ///  Display Fixml child group as string
        /// </summary>
        public override string ToString()
            => $"{Name} [Group : {this.Count}]";
    }
}