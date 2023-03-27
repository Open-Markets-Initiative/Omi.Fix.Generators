namespace Omi.Fix.Fields {

    /// <summary>
    ///  Fix Field (Type) Element
    /// </summary>

    public class Field {

        /// <summary>
        /// 
        /// </summary>
        public uint Tag = 0;

        /// <summary>
        /// 
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        ///  
        /// </summary>
        public string Version = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public string Description = string.Empty;

        /// <summary>
        /// 
        /// </summary>
        public Enums Enums = new Enums();

        /// <summary>
        ///  Convert Xml field element to document field
        /// </summary>
        public static Field From(Xml.FixFieldsFixFieldSpec field) {

            // verify values
            return new Field {
                Name = field.Name,
                Tag = field.Tag,
                // others (enums etc)    
            };
        }

        /// <summary>
        ///  Convert Xml field element to specification type
        /// </summary>
        public Specification.Type ToSpecification()
            => new () {
                Name = Name,
                Tag = Tag
            };

        /// <summary>
        ///  Display Fix field as string
        /// </summary>
        public override string ToString()
            => $"{Name} [Field]";
    }
}