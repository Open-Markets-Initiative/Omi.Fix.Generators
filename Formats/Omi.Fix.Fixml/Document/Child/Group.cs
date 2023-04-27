namespace Omi.Fixml.Child {
    using System.Linq;
    using Omi.Fix.Specification;

    /// <summary>
    ///  Fix Xml Group Element
    /// </summary>

    public class Group : IParent, IChild {

        /// <summary>
        ///  Name of Group 
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        ///  True if tag is required, false otherwise
        /// </summary>
        public bool Required { get; set;}

        /// <summary>
        ///  Component parent
        /// </summary>
        public IParent Parent { get; set; } // how to deal with this

        /// <summary>
        ///  Component depth in element tree
        /// </summary>
        public int Depth()
            => Omi.Fixml.Depth.Of(this);

        /// <summary>
        ///  Fixml group elements list (fields, groups, components)
        /// </summary>
        public Elements Elements { get; set; } = new Elements();

        /// <summary>
        ///  Does a group element contain child fields?
        /// </summary>
        public bool HasFields
            => Elements.Any();

        /// <summary>
        ///  Convert xml child group element to fixml group
        /// </summary>
        public static Group From(Xml.fixChildGroup element, IParent parent) {
            // Verify values
            var group = new Group {
                Name = element.name,
                Required = Is.Required(element.required),
                Parent = parent
            };

            foreach (var item in element.Items) {
                group.Elements.Add(Field.From(item, group));
            }

            return group;
        }

        /// <summary>
        ///  Convert normalized fix specification group to fixml group 
        /// </summary>
        public static Group From(Fix.Specification.Field element, IParent parent) {
            var group = new Group {
                Name = element.Name,
                Required = element.Required,
                Parent = parent
            };

            foreach (var item in element.Children) {
                group.Elements.Add(Field.From(item, group));
            }

            return group;
        }

        /// <summary>
        ///  Number of indent spaces
        /// </summary>
        public string Indent()
            => Omi.Fixml.Indent.Count(Depth() + 2);

        /// <summary>
        /// Write groups to xml file 
        /// </summary>
        public void Write(StreamWriter stream) {
            if (HasFields) {
                stream.WriteLine($"{Indent()}<group name=\"{Name}\" required=\"{(Required ? 'Y' : 'N')}\">");
                
                Elements.Write(stream);

                stream.WriteLine($"{Indent()}</group>");
            }
            else {
                stream.WriteLine($"{Indent()}<group name=\"{Name}\" required=\"{(Required ? 'Y' : 'N')}\"/>");
            }
        }

        /// <summary>
        ///  Convert fixml group to normalized fix specification group
        /// </summary>
        public Fix.Specification.Field ToSpecification() {
            var group = new Fix.Specification.Field {
                Kind = Kind.Group, 
                Name = Name, 
                Required = Required,
            };

            foreach (var child in Elements) { // nethod?
                group.Children.Add(child.ToSpecification());
            }

            return group;
        }

        /// <summary>
        ///  Verify fixml field element
        /// </summary>
        public void Verify(Fields fields, Fixml.Components components) {
            if (string.IsNullOrWhiteSpace(Name)) {
                throw new Exception("Group name is missing");
            }

            if (!fields.ContainsKey(Name)) {
                throw new Exception($"{Name}: Group is missing from dictionary");
            }

            Elements.Verify(fields, components);
        }

        /// <summary>
        ///  Display Fixml child group as string
        /// </summary>
        public override string ToString()
            => $"{Name} [Group : {Elements.Count}]";
    }
}