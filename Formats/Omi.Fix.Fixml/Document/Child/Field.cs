namespace Omi.Fixml.Child {
    using System;
    using Omi.Fix.Specification;

    /// <summary>
    ///  Fix Xml Field Element
    /// </summary>

    public class Field : IChild {

        /// <summary>
        ///  Fixml Field name
        /// </summary>
        public string Name { get; set;}

        /// <summary>
        ///  Is Fixml field required?
        /// </summary>
        public bool Required { get; set;}

        /// <summary>
        ///  Convert fixml child from any valid xml element
        /// </summary>
        public static IChild From(object item) {
            
            // Verify format and return child of given type
            if (item.GetType() == typeof(Xml.fixChildField)) {
                var field = (Xml.fixChildField)item;

                return Field.From(field);
            }
            if (item.GetType() == typeof(Xml.fixChildGroup)) {
                var group = (Xml.fixChildGroup)item;

                return Group.From(group);  
            }
            if (item.GetType() == typeof(Xml.fixChildComponent)) {
                var field = (Xml.fixChildComponent)item;

                return Component.From(field);  
            }

            throw new ArgumentOutOfRangeException();
        }

        /// <summary>
        /// Convert from specification to xml format
        /// </summary>
        public static IChild From(Fix.Specification.Field field) {
            switch (field.Kind) {
                case Kind.Field:
                    return new Field {
                        Name = field.Name,
                        Required = field.Required
                    };
                case Kind.Component:
                    return Component.From(field);
                case Kind.Group:
                    return Group.From(field);
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Obtain field from child
        /// </summary>
        public static Field From(Xml.fixChildField field) {
            // verify values
            return new Field {
                Name = field.name,
                Required = Is.Required(field.required)
            };
        }

        /// <summary>
        /// write field to stream
        /// </summary>
        public void Write(StreamWriter stream) { 
            stream.WriteLine($"      <field name=\"{Name}\" required=\"{(Required ? 'Y' : 'N')}\"/>");
        }

        /// <summary>
        /// Convert field to specification
        /// </summary>
        public Fix.Specification.Field ToSpecification()
            => new () { Kind = Kind.Field, Name = Name, Required = Required };

        /// <summary>
        ///  Verify fixml field element
        /// </summary>
        public void Verify(Fields fields, Fixml.Components components) {
            if (string.IsNullOrWhiteSpace(Name)) {
                throw new Exception("Field name is missing");
            }

            if (!fields.ContainsKey(Name)) {
                throw new Exception($"{Name}: Field is missing from dictionary");
            }
        }

        /// <summary>
        ///  Display Fixml child field as string
        /// </summary>
        public override string ToString()
            => $"{Name} [Field]";
    }
}