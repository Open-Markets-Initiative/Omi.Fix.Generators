namespace Omi.Fix.Sbe.Library {

    /// <summary>
    ///  Cme ilink3 File Library
    /// </summary>

    public static class iLink3 {

        /// <summary>
        ///  Gather all Cme ilink3 sbe xmls in library
        /// </summary>
        public static string[] Files() {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Library\\Cme.iLink3");

            return Directory.GetFiles(directory, "*.xml");
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<Xml.messageSchema> Xmls() {
            var files = Files();

            var xmls = new List<Xml.messageSchema>();
            foreach (var file in files ?? Array.Empty<string>()) {
                xmls.Add(Xml.Load.SbeXmlFrom(file));
            }

            return xmls;
        }

        /// <summary>
        ///  Generate normalized fix specifications for all ilink3 xml files in library sorted by version
        /// </summary>
        public static List<Specification.Document> Specifications(SortDirection sort = SortDirection.Descending) {
            var xmls = Xmls();

            // sort schemas
            var schemas = new List<Xml.messageSchema>();
            if (sort == SortDirection.Ascending)
            {
                schemas = xmls.OrderBy(schema => schema.id).ThenBy(schema => schema.version).ToList();
            }
            else
            {
                schemas = xmls.OrderByDescending(schema => schema.id).ThenByDescending(schema => schema.version).ToList();
            }

            var specifications = new List<Specification.Document>();
            foreach (var schema in schemas) {
                specifications.Add(Xml.Load.From(schema));
            }

            return specifications;
        }

        /// <summary>
        ///  Merge all iLink3 versions into one normalized fix specification
        /// </summary>
        public static Specification.Document Combined() {
            var specifications = Specifications();
            return Fix.Specification.Merge.All(specifications);
        }
    }
}
