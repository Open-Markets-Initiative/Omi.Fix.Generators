namespace Omi.Fixml {
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// 
    /// </summary>

    public class Enum
    {
        public string Value;

        public string Description;

        public static Enum From(Xml.fixFieldValue @enum)
            => new Enum {
                Value = @enum.@enum,
                Description = @enum.description
            };
        

        /// <summary>
        /// 
        /// </summary>
        public Fix.Specification.Enum ToSpecification()
            => new Fix.Specification.Enum {
                Value = Value, 
                Description = Description
            };
    }
}