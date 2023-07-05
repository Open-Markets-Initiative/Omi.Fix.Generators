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
        ///  Fix Field Type Version
        /// </summary>
        public string Version = string.Empty; // Maybe should be list

        /// <summary>
        ///  Fix Field Type Description
        /// </summary>
        public string Description = string.Empty;

        /// <summary>
        ///  Fix Field Enumerated Values
        /// </summary>
        public Enums Enums = new();

        // Add notes

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
                Description = field.Description,  
                Enums = Enums.From(field)  
            };
        }

        /// <summary>
        ///  Convert normalized fix type to xml field
        /// </summary>
        public static Type From(Fix.Specification.Type type)
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
                    // TODO
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