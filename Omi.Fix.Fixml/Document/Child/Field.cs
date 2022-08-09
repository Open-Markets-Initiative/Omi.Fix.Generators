namespace Omi.Fixml.Child {
    using System;
    using Omi.Fix.Specification;

    /// <summary>
    ///  Fix Xml Field Element
    /// </summary>
    public class Field : IChild {

        public string Name { get; set;}

        public bool Required { get; set;}

        /// <summary>
        /// Obtain child from any objecy
        /// </summary>
        public static IChild From(object item) {
            
            // Verify format and return child of given type
            if (item.GetType() == typeof(Xml.fixChildField))
            {
                var field = (Xml.fixChildField)item;

                return Field.From(field);
            }
            if (item.GetType() == typeof(Xml.fixChildGroup))
            {
                var field = (Xml.fixChildGroup)item;

                return Group.From(field);  
            }
            if (item.GetType() == typeof(Xml.fixChildComponent))
            {
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
        public static Field From(Xml.fixChildField field)
        {
            // verify values
            return new Field
            {
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
        /// Write child field component to stream
        /// </summary>
        public void Write(StreamWriter stream, IChild child)
        { 
            stream.WriteLine($"    <field name=\"{child.Name}\" required=\"{(Required ? 'Y' : 'N')}\"/>");
        }

        /// <summary>
        /// Convert field to specification
        /// </summary>
        public Fix.Specification.Field ToSpecification()
            => new Fix.Specification.Field { Kind = Kind.Field, Name = Name, Required = Required };

        /// <summary>
        ///  Display Fixml child field as string
        /// </summary>
        public override string ToString()
            => $"{Name} [Field]";
    }
}