namespace Omi.Fix.Types {

    /// <summary>
    ///  Omi Fix Types C# Document
    /// </summary>

    public class Document {

        /// <summary>
        ///  Fix types xml documention information
        /// </summary>
        public Information Information = new();

        /// <summary>
        ///  Fix types
        /// </summary>
        public Types Fields = new();

        /// <summary>
        ///  Construct a document from path to a fields xml
        /// </summary>
        public static Document From(string path) { // this one should be general
            var elements = Load.FieldsXmlFrom(path);
            return From(elements, path);
        }

        /// <summary>
        ///  Construct a document from path to a types xml
        /// </summary>
        public static Document FromTypesXml(string path) {
            var elements = Load.TypesXmlFrom(path);
            return From(elements, path);
        }

        /// <summary>
        ///  Construct a document from xml fields records
        /// </summary>
        public static Document From(Xml.FixFields xml, string path = default)
            => new () {
                Information = Information.From(xml, path),
                Fields = Types.From(xml)
            };

        /// <summary>
        ///  Construct a document from xml types records
        /// </summary>
        public static Document From(Xml.FixTypes xml, string path = default)
            => new() {
//                Information = Information.From(xml, path), TODO
//                Fields = Types.From(xml)                   TODO
            };

        /// <summary>
        ///  Convert normalized fix specification to fix fields
        /// </summary>
        public static Document From(Fix.Specification.Document specification)
          => new () {
              Information = Information.From(specification.Information),
              Fields = Types.From(specification.Types),
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
        ///  Fix Types xml as string
        /// </summary>
        public override string ToString()
            => $"{Information} Fix Types";
    }
}