namespace Omi.Fix.Txt {
    using System.IO;

    /// <summary>
    ///  Omi Fix Text C# Document
    /// </summary>

    public class Document {

        /// <summary>
        ///  Fix txt documention information
        /// </summary>
        public Information Information = new Information();

        /// <summary>
        /// Fix txt fields
        /// </summary>
        public Fields Fields = new Fields();

        /// <summary>
        /// Fix txt enum values
        /// </summary>
        public Enums Enums = new Enums();

        /// <summary>
        /// Fix txt messages
        /// </summary>
        public Messages Messages = new Messages();

        /// <summary>
        /// Returns a document from path to text file
        /// </summary>
        public static Document From(string path) {
            var lines = File.ReadLines(path);
            return From(lines);
        }

        /// <summary>
        ///  Returns a document from records
        /// </summary>
        public static Document From(IEnumerable<string> lines)  // remove this...make a merge
            => new () {
                Information = Information.From(lines),
                Enums = Enums.From(lines),
                Fields = Fields.From(lines),
                Messages = Messages.From(lines)
            };

        /// <summary>
        ///  Convert fix txt to normalized fix specification
        /// </summary>
        public Specification.Document ToSpecification()
            => new () {
                Description = Information.ToSpecification(),
                Header = new Specification.Header(),
                Trailer = new Specification.Trailer(),
                Messages = Messages.ToSpecification(),
                Components = new Specification.Components(),
                Types = Fields.ToSpecification(Enums),
            };

        /// <summary>
        ///  Fix txt description as string
        /// </summary>
        public override string ToString()
            => $"{Information} fix txt";
    }
}