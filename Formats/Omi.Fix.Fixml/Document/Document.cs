namespace Omi.Fixml {
    using System.IO;

    /// <summary>
    ///  Financial Information eXchange Fixml C# Document
    /// </summary>

    public class Document {

        /// <summary>
        ///  Fixml Document Information
        /// </summary>
        public Information Information = new ();

        /// <summary>
        ///  Fixml Header Fields
        /// </summary>
        public Header Header = new ();

        /// <summary>
        /// Fixml Trailer Fields
        /// </summary>
        public Trailer Trailer = new ();

        /// <summary>
        /// Fixml Messages
        /// </summary>
        public Messages Messages = new ();

        /// <summary>
        /// Fixml components
        /// </summary>
        public Components Components = new ();

        /// <summary>
        /// Fixml Fields
        /// </summary>
        public Fields Fields = new ();

        /// <summary>
        ///  Convert fixml document from specification document
        /// </summary>
        public static Document From(Fix.Specification.Document specification)
          => new () {
                Information = Information.From(specification.Description),
                Header = Header.From(specification.Header),
                Trailer = Trailer.From(specification.Trailer),
                Messages = Messages.From(specification.Messages),
                Components = Components.From(specification.Components),
                Fields = Fields.From(specification.Types),
            };

        /// <summary>
        /// Obtain fixml document from xml file 
        /// </summary>
        public static Document From(Xml.fix xml)
            => new () {
                Information = Information.From(xml),
                Header = Header.From(xml),
                Trailer = Trailer.From(xml),
                Messages = Messages.From(xml),
                Components = Components.From(xml),
                Fields = Fields.From(xml)
            };

        /// <summary>
        ///  Load fixml file from path 
        /// </summary>
        public static Document From(string path) {
            var xml = Load.From(path);
            return From(xml);
        }

        /// <summary>
        ///  Write fixml file to stream
        /// </summary>
        public void WriteTo(StreamWriter stream) {
            Information.Write(stream);          
            Header.Write(stream); 
            Trailer.Write(stream);   
            Messages.Write(stream);    
            Components.Write(stream);        
            Fields.Write(stream);

            stream.WriteLine("</fix>");
        }

        /// <summary>
        ///  Write fixml to path
        /// </summary>
        public string WriteTo(string path) {
            using var file = File.Create(path);
            using var stream = new StreamWriter(file);

            WriteTo(stream);

            return file.Name;
        }

        /// <summary>
        ///  Convert fixml to normalized fix specification
        /// </summary>
        public Fix.Specification.Document ToSpecification()
            => new () {
                Description = Information.ToSpecification(), 
                Header = Header.ToSpecification(),
                Trailer = Trailer.ToSpecification(),
                Messages = Messages.ToSpecification(),
                Components = Components.ToSpecification(),
                Types = Fields.ToSpecification(),
            };

        /// <summary>
        ///  Verify fixml
        /// </summary>
        public void Verify() {
            // fixmls require version information
            if (string.IsNullOrWhiteSpace(Information.Major)) {
                throw new Exception("Missing Information");
            }

            // verify that all elements in Messages
            foreach (var message in Messages) {
                message.Verify(Fields, Components);
            }
        }

        /// <summary>
        ///  Fixml as string
        /// </summary>
        public override string ToString()
            => $"{Information} Fixml";
    }
}
