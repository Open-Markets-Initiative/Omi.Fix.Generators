namespace Omi.Fixml {

    /// <summary>
    ///  Fixml Specification Information
    /// </summary>

    public class Information {

        /// <summary>
        ///  Fixml Major Version
        /// </summary>
        public string Major = string.Empty;

        /// <summary>
        ///  Fixml Minor Version
        /// </summary>
        public string Minor = string.Empty;

        /// <summary>
        ///  Obtain description from xml
        /// </summary>
        public static Information From(Xml.fix xml)
            => new () { // need more checks, defaults
                Major = xml.major.ToString(),
                Minor = xml.minor.ToString(),
            };

        /// <summary>
        /// Convert from specification Types to Xml Fields
        /// </summary>
        public static Information From(Fix.Specification.Description description)
            => new () {
                Major = description.Major,
                Minor = description.Minor,
            };

        /// <summary>
        ///  Write components out to Fixml
        /// </summary>
        public void Write(StreamWriter stream) {
            stream.WriteLine($"<fix major=\"{Major}\" minor=\"{Minor}\">"); // sp, null, etc
        }

        /// <summary>
        ///  Convert fixml field declarations to normalized fix specification description
        /// </summary>
        public Fix.Specification.Description ToSpecification()
            => new () {
                Major = Major,
                Minor = Minor,
            };
    }
}