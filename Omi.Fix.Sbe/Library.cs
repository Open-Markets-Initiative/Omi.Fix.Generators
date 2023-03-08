namespace Omi.Fix.Sbe {

    /// <summary>
    ///  Sbe File Library
    /// </summary>

    public static class Library
    {
        /// <summary>
        /// 
        /// </summary>
        public static string[] iLink3Files() {
            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Cme.iLink3");

            return Directory.GetFiles(directory, "*.xml");
        }

        /// <summary>
        /// 
        /// </summary>
        public static List<Xml.messageSchema> iLink3Xmls() {
            var files = iLink3Files();

            var xmls = new List<Xml.messageSchema>();
            foreach (var file in files ?? Array.Empty<string>()) {
                xmls.Add(Load.SbeXmlFrom(file));
            }

            return xmls;
        }

        /// <summary>
        ///  Generate normalized fix specifications for all ilink3 xml files in library sorted by version
        /// </summary>
        public static List<Specification.Document> iLink3Specifications(SortDirection sort = SortDirection.Descending) {
            var xmls = Library.iLink3Xmls();

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
            foreach (var schema in schemas)
            {
                specifications.Add(Load.From(schema));
            }

            return specifications;
        }


        /// <summary>
        /// Combine a fix specification from all available iLink versions
        /// </summary>
        public static Specification.Document iLink3Combined()
        {
            var iLinkSpecs = Library.iLink3Specifications();

            var merged = new Specification.Document();

            foreach (var specification in iLinkSpecs) { //move to merged
                merged.Components.AddRange(specification.Components.Where(component => !merged.Components.Contains(component)));
                merged.Header.AddRange(specification.Header.Where(header => !merged.Header.Contains(header)));
                merged.Trailer.AddRange(specification.Trailer.Where(trailer => !merged.Trailer.Contains(trailer)));
                merged.Messages.AddRange(specification.Messages.Where(message => !merged.Messages.Select(message => message.Name).Contains(message.Name)));
                merged.Fields = Specification.Types.ToTypes(merged.Fields.Concat(specification.Fields.Where(field => !merged.Fields.Contains(field))));
            }

            return merged;
        }
    }
}
