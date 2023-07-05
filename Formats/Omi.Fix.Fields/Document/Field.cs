namespace Omi.Fix.Fields {

    /// <summary>
    ///  Fix Field (Type) Element
    /// </summary>

    public class Field {

        /// <summary>
        ///  Fix Field Tag/Number
        /// </summary>
        public uint Tag = 0;

        /// <summary>
        ///  Fix Field Name
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        ///  Fix Field Version
        /// </summary>
        public string Version = string.Empty; // Maybe should be list

        /// <summary>
        ///  Fix Field Description
        /// </summary>
        public string Description = string.Empty;

        /// <summary>
        ///  Fix Field Enumerated Values
        /// </summary>
        public Enums Enums = new Enums();

        // Add notes

        /// <summary>
        ///  Is Field an Enum?
        /// </summary>
        public bool IsEnum => Enums.Any();

        /// <summary>
        ///  Convert Xml field element to document field
        /// </summary>
        public static Field From(Xml.FixFieldsFixFieldSpec field) {

            // verify values
            return new Field {
                Name = field.Name,
                Tag = field.Tag,
                Description = field.Description,  
                Enums = Enums.From(field)  
            };
        }

        /// <summary>
        ///  Convert normalized fix type to xml field
        /// </summary>
        public static Field From(Fix.Specification.Type type)
            => new () {
                Name = type.Name,
                Tag = type.Tag,
                Description = type.Description,
                Enums = Enums.From(type)
            };

        /// <summary>
        ///  Convert Xml field element to specification type
        /// </summary>
        public Specification.Type ToSpecification()
            => new () {
                Name = Name,
                Tag = Tag
            };

        /// <summary>
        /// Writes fix type field to stream
        /// </summary>
        public void Write(StreamWriter stream) {
            stream.WriteLine($"  <Type>");
            stream.WriteLine($"    <Name>{Name}</Name>");
            stream.WriteLine($"    <Tag>{Tag}</Tag>");
            stream.WriteLine($"    <Description>{Description}</Description>");

            if (IsEnum) {
                foreach (var @enum in Enums)
                {

                }
            }

            stream.WriteLine("  </Type>");
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