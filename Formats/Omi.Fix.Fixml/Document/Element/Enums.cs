namespace Omi.Fixml {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///  List of enum values for a Fixml field
    /// </summary>

    public class Enums : List<Enum> {

        /// <summary>
        ///  Default constructor
        /// </summary>
        public Enums()
        { }

        /// <summary>
        /// Constructs enums from an IEnumerable
        /// </summary>
        public Enums(IEnumerable<Enum> enums) { 
            AddRange(enums);
        }

        /// <summary>
        ///  Gather enum values from fixml xml field
        /// </summary>
        public static Enums From(Xml.fixField2 field)
            => new Enums(ListFrom(field).Select(Enum.From));

        /// <summary>
        ///  Gather enum xml elements from fixml
        /// </summary>
        public static Xml.fixFieldValue[] ListFrom(Xml.fixField2 field)
            => field.value ?? Array.Empty<Xml.fixFieldValue>();

        /// <summary>
        ///  Convert normalized fix specification enums to fixml enums
        /// </summary>
        public static Enums From(Fix.Specification.Type type) {
            var enums = new Enums();

            foreach (var @enum in type.Enums) {
                enums.Add(Enum.From(@enum));
            }

            return enums;
        }

        /// <summary>
        ///  Convert fixml enums to normalized fix specification enums
        /// </summary>
        public Fix.Specification.Enums ToSpecification() {
            var enums = new Fix.Specification.Enums();

            foreach (var component in this) {
                enums.Add(component.ToSpecification());
            }
            
            return enums;
        }
    }
}