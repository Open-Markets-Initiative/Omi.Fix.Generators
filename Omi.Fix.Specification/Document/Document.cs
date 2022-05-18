namespace Omi.Fix.Specification {

    /// <summary>
    ///  Normalized Fix Specification
    /// </summary>

    public class Document {

        /// <summary>
        ///  Fix Specification Headers
        /// </summary>
        public Description Description = new Description();

        /// <summary>
        ///  Fix Specification Header fields
        /// </summary>
        public Header Header = new Header();

        /// <summary>
        ///  Fix Specification Trailers
        /// </summary>
        public Trailer Trailer = new Trailer();

        /// <summary>
        ///  Fix Specification Messages
        /// </summary>
        public Messages Messages = new Messages();

        /// <summary>
        ///  Fix Specification Components
        /// </summary>
        public Components Components = new Components();

        /// <summary>
        ///  Fix Specification Field Types
        /// </summary>
        public Types Fields = new Types();

        /// <summary>
        ///  Display Fix Specification Information
        /// </summary>
        public override string ToString()
            => $"{Description}";
    }
}
