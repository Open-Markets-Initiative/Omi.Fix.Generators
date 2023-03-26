namespace Omi.Fix.Fields {

    /// <summary>
    ///  Fix Fields Specification Information
    /// </summary>

    public class Information {
        /// <summary>
        ///  Fixml Major Version
        /// </summary>
        public string Source = string.Empty;

        /// <summary>
        ///  Obtain description from xml
        /// </summary>
        public static Information From(Xml.FixFields xml)
            => new () { // need more checks, defaults
            };

        /// <summary>
        /// Convert from specification Types to Xml Fields
        /// </summary>
        public static Information From(Fix.Specification.Description description)
            => new () {
                // what to do here?
            };

        /// <summary>
        ///  Convert fix field declarations to normalized fix specification description
        /// </summary>
        public Fix.Specification.Description ToSpecification()
            => new Fix.Specification.Description {
                // what to do here
                };
    }
}