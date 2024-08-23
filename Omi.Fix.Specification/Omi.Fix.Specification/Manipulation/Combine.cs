using System.Net.NetworkInformation;
using System.Numerics;

namespace Omi.Fix.Specification;

/// <summary>
///  Merge 
/// </summary>

public static class Merge
{

    /// <summary>
    /// Combine a list of specifications. Uses field in duplicates set if available to remove duplicates. Uses name in updatedNames if available.
    /// </summary>
    public static Document AllClean(IEnumerable<Document> specifications, HashSet<string> duplicates, Dictionary<string, string> updatedNames)
    {
        var merged = new Document();

        foreach (var specification in specifications)
        {
            merged.AddClean(specification, duplicates, updatedNames);
        }

        return merged;
    }

    /// <summary>
    /// Add a fix specification to a another, making sure to not add duplicates from duplicates HashSet
    /// </summary>
    public static void AddClean(this Document merged, Document specification, HashSet<string> duplicates, Dictionary<string, string> updatedNames)
    { // this can be better
        merged.Components.AddRange(specification.Components.Where(component => !merged.Components.Contains(component)));
        merged.Header.AddRange(specification.Header.Where(header => !merged.Header.Contains(header)));
        merged.Trailer.AddRange(specification.Trailer.Where(trailer => !merged.Trailer.Contains(trailer)));
        merged.Messages.AddRange(specification.Messages.Where(message => !merged.Messages.Select(message => message.Name).Contains(message.Name)));
        merged.Types = Specification.Types.ToTypes(merged.Types.Concat(specification.Types.Where(field => !merged.Types.Contains(field) && !duplicates.Contains(field.Key))), updatedNames);
    }

    /// <summary>
    /// Combine a list of specifications
    /// </summary>
    public static Document All(IEnumerable<Document> specifications)
    {
        var merged = new Document();

        foreach (var specification in specifications)
        {
            merged.Add(specification);
        }

        return merged;
    }

    /// <summary>
    /// Add a fix specification to a another
    /// </summary>
    public static void Add(this Document merged, Document specification)
    { // this can be better
        merged.Components.AddRange(specification.Components.Where(component => !merged.Components.Contains(component)));
        merged.Header.AddRange(specification.Header.Where(header => !merged.Header.Contains(header)));
        merged.Trailer.AddRange(specification.Trailer.Where(trailer => !merged.Trailer.Contains(trailer)));
        merged.Messages.AddRange(specification.Messages.Where(message => !merged.Messages.Select(message => message.Name).Contains(message.Name)));
        merged.Types = Specification.Types.ToTypes(merged.Types.Concat(specification.Types.Where(field => !merged.Types.Contains(field))));
    }


    /// <summary>
    /// Add a fix specification to a another
    /// </summary>
    public static Document Combine(Document merged, Document specification)
    { // this can be better
        merged.Add(specification);

        return merged;
    }
}