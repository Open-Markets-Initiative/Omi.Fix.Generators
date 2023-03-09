namespace Omi.Fix.Specification {

    /// <summary>
    ///  Normalized Fix Specification
    /// </summary>

    public class Document {

        /// <summary>
        ///  Normalized Fix Specification Identifing Information
        /// </summary>
        public Description Description = new Description();

        /// <summary>
        ///  Normalized Fix Specification Header fields
        /// </summary>
        public Header Header = new Header();

        /// <summary>
        ///  Normalized Fix Specification Trailers
        /// </summary>
        public Trailer Trailer = new Trailer();

        /// <summary>
        ///  Normalized Fix Specification Messages
        /// </summary>
        public Messages Messages = new Messages();

        /// <summary>
        ///  Normalized Fix Specification Components
        /// </summary>
        public Components Components = new Components();

        /// <summary>
        ///  Normalized Fix Specification Field Types
        /// </summary>
        public Types Fields = new Types();

        /// <summary>
        ///  Display Fix Specification Information
        /// </summary>
        public override string ToString()
            => $"{Description}";
    }
}
