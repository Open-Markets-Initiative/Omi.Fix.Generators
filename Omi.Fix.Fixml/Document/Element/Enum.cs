namespace Omi.Fixml {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Contains value and data for a fix enumerator
    /// </summary>
    public class Enum
    {
        public string Value;

        public string Description;

        /// <summary>
        /// Constructs an enum from a field value
        /// </summary>
        public static Enum From(Xml.fixFieldValue @enum)
            => new Enum {
                Value = @enum.@enum,
                Description = @enum.description
            };
        

        /// <summary>
        /// Places Enum in specification format
        /// </summary>
        public Fix.Specification.Enum ToSpecification()
            => new Fix.Specification.Enum {
                Value = Value, 
                Description = Description
            };

        public override string ToString()
           => $"{Value} = {Description}";
    }
}