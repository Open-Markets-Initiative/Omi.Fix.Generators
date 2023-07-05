namespace Omi.Fix.Types {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    ///  Enumerated Field Values
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
        public static Enums From(Xml.FixFieldsFixFieldSpec field)
            => new (ValuesFor(field).Select(Enum.From));

        /// <summary>
        ///  Gather enum xml elements from fix fields xml field
        /// </summary>
        public static Xml.FixFieldsFixFieldSpecFixEnumField[] ValuesFor(Xml.FixFieldsFixFieldSpec field)
            => field.EnumPairs ?? Array.Empty<Xml.FixFieldsFixFieldSpecFixEnumField>();

        /// <summary>
        /// Convert enums from normalized fix specification to fix fields format
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

            foreach (var @enum in this) {
                enums.Add(@enum.ToSpecification());
            }
            
            return enums;
        }
    }
}