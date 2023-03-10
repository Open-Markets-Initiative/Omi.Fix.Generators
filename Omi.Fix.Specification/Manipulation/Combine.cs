namespace Omi.Fix.Specification {

    /// <summary>
    ///  Merge 
    /// </summary>

    public static class Merge {

        /// <summary>
        /// Combine a list of specifications
        /// </summary>
        public static Document All(IEnumerable<Document> specifications) {
            var merged = new Document();
            foreach (var specification in specifications) {
                merged.Add(specification);
            }

            return merged;
        }

        /// <summary>
        /// Add a fix specification to a another
        /// </summary>
        public static void Add(this Document merged, Document specification) { // this can be better
            merged.Components.AddRange(specification.Components.Where(component => !merged.Components.Contains(component)));
            merged.Header.AddRange(specification.Header.Where(header => !merged.Header.Contains(header)));
            merged.Trailer.AddRange(specification.Trailer.Where(trailer => !merged.Trailer.Contains(trailer)));
            merged.Messages.AddRange(specification.Messages.Where(message => !merged.Messages.Select(message => message.Name).Contains(message.Name)));
            merged.Types = Specification.Types.ToTypes(merged.Types.Concat(specification.Types.Where(field => !merged.Types.Contains(field))));
        }
    }
}