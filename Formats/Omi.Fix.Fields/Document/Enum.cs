namespace Omi.Fix.Fields {

    /// <summary>
    ///  Fix Field Enumerated Value
    /// </summary>

    public class Enum {

        /// <summary>
        ///  Enum Value
        /// </summary>
        public string Name = string.Empty;

        /// <summary>
        ///  Enum Value
        /// </summary>
        public string Value = string.Empty;

        /// <summary>
        ///  Enum description
        /// </summary>
        public string Description = string.Empty;

        /// <summary>
        ///  Convert field value
        /// </summary>
        public static Enum From(Xml.FixFieldsFixFieldSpecFixEnumField @enum)
            => new () {
                Name = @enum.Key,
                Value = @enum.Value,
                //Description = @enum // todo
            };
        
        /// <summary>
        ///  Convert fields enumerated vaue to normalized fix specification value
        /// </summary>
        public Fix.Specification.Enum ToSpecification()
            => new () {
                Name = Name,
                Value = Value, 
                Description = Description
            };

        /// <summary>
        ///  Display enumerated value as string
        /// </summary>
        public override string ToString() {
            if (string.IsNullOrWhiteSpace(Description)) {
                return $"{Name} = {Value}";
            }

            return $"{Name} = {Value}, {Description}";           
        }
    }
} 