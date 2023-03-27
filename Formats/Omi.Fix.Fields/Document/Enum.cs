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
            => new Enum {
                Name = @enum.Key,
                Value = @enum.Value,
                //Description = @enum.
            };
        
        /// <summary>
        ///  Places Enum in specification format
        /// </summary>
        public Fix.Specification.Enum ToSpecification()
            => new () {
                Name = Name,
                Value = Value, 
                Description = Description
            };

        /// <summary>
        ///  Display as string
        /// </summary>
        public override string ToString()
           => $"{Value} = {Description}";
    }
} 