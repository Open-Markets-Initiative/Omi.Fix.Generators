namespace Omi.Fixml {

    /// <summary>
    ///  Fixml File Library
    /// </summary>

    public static class Library
    {
        /// <summary>
        ///  Gather Fixml files in library
        /// </summary>
        public static string[] Files() {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Library\\Fixml");

            return Directory.GetFiles(directory, "*.xml");
        }

        /// <summary>
        ///  Gather library fixmls in object classes
        /// </summary>
        public static List<Xml.fix> Xmls() {
            var files = Files();

            var xmls = new List<Xml.fix>();
            foreach (var file in files ?? Array.Empty<string>()) {
                xmls.Add(Load.From(file));
            }

            return xmls;
        }

        /// <summary>
        ///  Gather normalized specifications for all xml files in library
        /// </summary>
        public static List<Fix.Specification.Document> Specifications() {
            var xmls = Xmls();

            var specifications = new List<Fix.Specification.Document>();
            foreach (var xml in xmls)
            {
                var fixml = Document.From(xml);
                specifications.Add(fixml.ToSpecification());
            }

            return specifications;
        }
    }
}
