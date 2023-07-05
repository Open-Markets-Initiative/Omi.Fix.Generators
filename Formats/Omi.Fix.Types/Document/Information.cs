namespace Omi.Fix.Types {

    /// <summary>
    ///  Fix Fields Specification Information
    /// </summary>

    public class Information {

        /// <summary>
        ///  Source File
        /// </summary>
        public string Source = string.Empty;

        /// <summary>
        ///  Obtain description from xml
        /// </summary>
        public static Information From(Xml.FixFields xml, string path) {
            if (string.IsNullOrEmpty(path)) {
                path = string.Empty;     
            }

            return new () {
                Source = path
            };
        }

        /// <summary>
        ///  Convert normalized specification information to Xml Fields
        /// </summary>
        public static Information From(Fix.Specification.Information description)
            => new () {
                // what to do here?
            };

        /// <summary>
        ///  Convert fix field declarations to normalized fix specification description
        /// </summary>
        public Fix.Specification.Information ToSpecification()
            => new () {
                // what to do here
                };

        /// <summary>
        ///  Fix Fields inforrmation as string
        /// </summary>
        public override string ToString()
            => $"{Source}";
    }
}