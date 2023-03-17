namespace Omi.Fix.Fields {
    using System.IO;

    /// <summary>
    ///  Omi Fix Fields C# Document
    /// </summary>

    public class Document {
/*
        /// <summary>
        ///  Fix Fields xml documention information
        /// </summary>
        public Information Information = new Information();

        /// <summary>
        /// Fix fields
        /// </summary>
        public Fields Fields = new Fields();

        /// <summary>
        ///  Returns a document from records
        /// </summary>
        public static Document From(Xml.ArrayOfFixFieldSpec xml)
            => new () {
                Information = Information.From(xml),
                Enums = Enums.From(lines),
                Fields = Fields.From(lines),
            };

        /// <summary>
        ///  Convert fix txt to normalized fix specification
        /// </summary>
        public Specification.Document ToSpecification()
            => new Specification.Document {
                Description = Information.ToSpecification(),
                Header = new Specification.Header(),
                Trailer = new Specification.Trailer(),
                Messages = Messages.ToSpecification(),
                Components = new Specification.Components(),
                Types = Fields.ToSpecification(),
            };

        /// <summary>
        ///  Fix Fields xml description as string
        /// </summary>
        public override string ToString()
            => $"{Information} fix fields";
*/    }
}