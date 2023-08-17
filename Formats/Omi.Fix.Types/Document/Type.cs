using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Omi.Fix.Types {

    /// <summary>
    ///  Fix Field (Type) Element
    /// </summary>

    public class Type {

        /// <summary>
        ///  Fix Field Type Tag/Number
        /// </summary>
        public uint Tag = 0;

        /// <summary>
        ///  Fix Field Type Name
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        ///  Fix Field Type Value Type
        /// </summary>
        public string DataType = string.Empty;

        /// <summary>
        ///  Fix Field Type Version
        /// </summary>
        public string Version = string.Empty; // Maybe should be list

        /// <summary>
        ///  Fix Field Type Description
        /// </summary>
        public string Description = string.Empty;

        /// <summary>
        ///  Fix Field Type Note
        /// </summary>
        public string Note = string.Empty;

        /// <summary>
        ///  Fix Field Enumerated Values
        /// </summary>
        public Enums Enums = new();

        /// <summary>
        ///  Is Field an Enum?
        /// </summary>
        public bool IsEnum => Enums.Any();

        /// <summary>
        ///  Convert Xml field element to document field
        /// </summary>
        public static Type From(Xml.FixFieldsFixFieldSpec field) {

            // verify values
            return new Type {
                Name = field.Name,
                Tag = field.Tag,
                DataType = field.DataType,
                Description = field.Description,
                Version = field.Version,
                Enums = Enums.From(field)
            };
        }

        /// <summary>
        ///  Convert Xml type element to document field
        /// </summary>
        public static Type From(Xml.FixTypesFixType field) {

            // verify values
            return new Type {
                Name = field.Name,
                Tag = field.Tag,
                DataType = field.Type,
                Description = field.Description,
                Version = field.Version,
                Enums = Enums.From(field)
            };
        }

        /// <summary>
        ///  Convert normalized fix type to xml field
        /// </summary>
        public static Type From(Fix.Specification.Type type) {

            var dataType = type.DataType;

            if (String.IsNullOrWhiteSpace(type.DataType)) {
                dataType = type.Underlying;
            }

            return new Type {
                Name = type.Name,
                Tag = type.Tag,
                DataType = dataType,
                Description = type.Description,
                Version = type.Version,
                Enums = Enums.From(type)
            };
        }

        /// <summary>
        ///  Convert Xml field element to specification type
        /// </summary>
        public Specification.Type ToSpecification()
            => new () {
                Name = Name,
                Tag = Tag,
                DataType = DataType,
                Description = Description,
                Version = Version,
                Enums = Enums.ToSpecification()
            };

        /// <summary>
        /// Writes fix type field to stream
        /// </summary>
        public void Write(StreamWriter stream) {
            stream.WriteLine($"  <FixType>");
            stream.WriteLine($"    <Name>{Name}</Name>");
            stream.WriteLine($"    <Tag>{Tag}</Tag>");
            stream.WriteLine($"    <Type>{DataType}</Type>");
            stream.WriteLine($"    <Description>{Description}</Description>");

            if (!String.IsNullOrWhiteSpace(Note)) {
                stream.WriteLine($"    <Note>{Note}</Note>");
            }

            stream.WriteLine($"    <Version>{Version}</Version>");

            if (IsEnum) {
                foreach (var @enum in Enums) {
                    @enum.Write(stream);
                }
            }

            stream.WriteLine("  </FixType>");
        }

        /// <summary>
        ///  Display Fix field as string
        /// </summary>
        public override string ToString() {
            if (string.IsNullOrWhiteSpace(Description)) {
                return $"{Name} : {Tag}";
            }

            return $"{Name} : {Tag}, {Description}"; // add if if enum
        }
    }
}