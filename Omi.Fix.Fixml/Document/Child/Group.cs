namespace Omi.Fixml.Child {
    using System.Collections.Generic;
    using System.Linq;
    using Omi.Fix.Specification;

    /// <summary>
    /// 
    /// </summary>

    public class Group : List<IChild>, IChild {

        public string Name { get; set;}

        public bool Required { get; set;}

        /// <summary>
        /// 
        /// </summary>
        public static Group From(Xml.fixChildGroup element)
        {
            // verify values
            var group = new Group
            {
                Name = element.name,
                Required = Is.Required(element.required)
            };

            foreach (var item in element.Items) // need ??
            {
                group.Add(Child.Field.From(item));
            }

            return group;
        }

        /// <summary>
        /// 
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
                group.Add(Child.Field.From(item));
            }

            return group;
        }

        /// <summary>
        /// 
        /// </summary>
        public void Write(System.IO.StreamWriter stream) // need one with different indent
        {
            if (HasFields) 
            {
                stream.WriteLine($"    <group name=\"{Name}\" required=\"{(Required ? 'Y' : 'N')}\">");
                
                foreach (var child in this)
                {
                    child.Write(stream);
                }

                stream.WriteLine("    </group>");
            }
            else
            {
                stream.WriteLine($"    <group name=\"{Name}\" required=\"{(Required ? 'Y' : 'N')}\"/>");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public bool HasFields
            => this.Any();

        /// <summary>
        /// 
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