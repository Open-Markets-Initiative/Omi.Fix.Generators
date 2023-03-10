namespace Omi.Fixml {
    using System.IO;

    /// <summary>
    ///  Fixml C# Document
    /// </summary>

    public class Document {

        /// <summary>
        ///  Fixml Major Version
        /// </summary>
        public string Major;

        /// <summary>
        ///  Fixml Minor Version
        /// </summary>
        public string Minor;

        /// <summary>
        ///  Fixml Header Element/Section
        /// </summary>
        public Header Header = new Header();

        /// <summary>
        /// Fixml Trailer 
        /// </summary>
        public Trailer Trailer = new Trailer();

        /// <summary>
        /// Fixml Messages
        /// </summary>
        public Messages Messages = new Messages();

        /// <summary>
        /// Fixml components
        /// </summary>
        public Components Components = new Components();

        /// <summary>
        /// Fixml Fields
        /// </summary>
        public Fields Fields = new Fields();

        /// <summary>
        /// Obtain fixml document from specification document
        /// </summary>
        public static Document From(Fix.Specification.Document specification)
          => new Document {
                Header = Fixml.Header.From(specification.Header),
                Trailer = Fixml.Trailer.From(specification.Trailer),
                Messages = Fixml.Messages.From(specification.Messages),
                Components = Fixml.Components.From(specification.Components),
                Fields = Fixml.Fields.From(specification.Types),
            };

        /// <summary>
        /// Obtain fixml document from xml file 
        /// </summary>
        public static Document From(Xml.fix xml)
          => new Document {
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
        public void Write(StreamWriter stream) {
            stream.WriteLine($"<fix major=\"{Major}\" minor=\"{Minor}\">"); // sp etc
            
            Header.Write(stream); 
            Trailer.Write(stream);   
            Messages.Write(stream);    
            Components.Write(stream);        
            Fields.Write(stream);

            stream.WriteLine("</fix>");
        }

        /// <summary>
        /// Write document to stream
        /// </summary>
        public void WriteTo(string path) {
            using var file = File.Create(path);
            using var stream = new StreamWriter(file);

            Write(stream);
        }

        /// <summary>
        ///  Convert fixml to normalized fix specification
        /// </summary>
        public Fix.Specification.Document ToSpecification()
            => new Fix.Specification.Document {
                Description = {Major = Major, Minor = Minor}, 
                Header = Header.ToSpecification(),
                Trailer = Trailer.ToSpecification(),
                Messages = Messages.ToSpecification(),
                Components = Components.ToSpecification(),
                Types = Fields.ToSpecification(),
            };
    }
}
