namespace Omi.Fix.Fields {

    /// <summary>
    ///  Omi Fix Fields C# Document
    /// </summary>

    public class Document {

        /// <summary>
        ///  Fix Fields xml documention information
        /// </summary>
        public Information Information = new();

        /// <summary>
        ///  Fix fields
        /// </summary>
        public Fields Fields = new();

        /// <summary>
        ///  Construct a document from path
        /// </summary>
        public static Document From(string path) {
            var elements = Load.From(path);
            return From(elements, path);
        }

        /// <summary>
        ///  Construct a document from xml records
        /// </summary>
        public static Document From(Xml.FixFields xml, string path = default)
            => new () {
                Information = Information.From(xml, path),
                Fields = Fields.From(xml)
            };

        /// <summary>
        ///  Convert fix txt to normalized fix specification
        /// </summary>
        public Specification.Document ToSpecification()
            => new () {
                Description = Information.ToSpecification(),
                Header = new Specification.Header(),
                Trailer = new Specification.Trailer(),
                Components = new Specification.Components(),
                Types = Fields.ToSpecification()
            };

        // TODO writer

        /// <summary>
        ///  Fix Fields xml as string
        /// </summary>
        public override string ToString()
            => $"{Information} Fix Fields";
    }
}