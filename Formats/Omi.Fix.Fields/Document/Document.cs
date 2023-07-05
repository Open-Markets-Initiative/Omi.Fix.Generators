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
        ///  Convert normalized fix specification to fix fields
        /// </summary>
        public static Document From(Fix.Specification.Document specification)
          => new () {
              Information = Information.From(specification.Information),
              Fields = Fields.From(specification.Types),
          };

        /// <summary>
        ///  Convert fix fields document to normalized fix specification
        /// </summary>
        public Specification.Document ToSpecification()
            => new () {
                Information = Information.ToSpecification(),
                Header = new Specification.Header(),
                Trailer = new Specification.Trailer(),
                Messages = new Specification.Messages(),
                Components = new Specification.Components(),
                Types = Fields.ToSpecification()
            };

        /// <summary>
        ///  Write fix types xml to stream
        /// </summary>
        public void WriteTo(StreamWriter stream) {
            Fields.Write(stream);
        }

        /// <summary>
        ///  Write fix types xml to path
        /// </summary>
        public string WriteTo(string path) {
            using var file = File.Create(path);
            using var stream = new StreamWriter(file);

            WriteTo(stream);

            return file.Name;
        }

        // TODO writer

        /// <summary>
        ///  Fix Fields xml as string
        /// </summary>
        public override string ToString()
            => $"{Information} Fix Fields";
    }
}