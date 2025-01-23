namespace Omi.Fix.Sbe.Library;

/// <summary>
///  Euronext Optiq OrderEntryGateway xml file library
/// </summary>

public static class OptiqOrderEntry
{
    /// <summary>
    ///  Gather all Euronext Optiq OrderEntry sbe xmls in library
    /// </summary>
    public static string[] Files()
    {
        var directory = Path.Combine(Directory.GetCurrentDirectory(), "Library", "Euronext.Optiq");

        return Directory.GetFiles(directory, "*.xml");
    }

    /// <summary>
    ///  Gather iLink3 Sbe xmls
    /// </summary>
    public static List<Sbe.Optiq.messageSchema> Xmls()
    {
        var xmls = new List<Sbe.Optiq.messageSchema>();

        var files = Files();

        foreach (var file in files)
        {
            var current = Sbe.Optiq.Load.XmlFrom(file);

            xmls.Add(current);
        }

        return xmls;
    }

    /// <summary>
    ///  Sort iLink3 message schemas
    /// </summary>
    public static List<Sbe.Optiq.messageSchema> Sort(List<Sbe.Optiq.messageSchema> xmls, SortDirection sort = SortDirection.Descending)
    {
        if (sort == SortDirection.Ascending)
        {
            return xmls.OrderBy(schema => schema.id).ThenBy(schema => schema.version).ToList();
        }
        else
        {
            return xmls.OrderByDescending(schema => schema.id).ThenByDescending(schema => schema.version).ToList();
        }
    }

    /// <summary>
    ///  Generate normalized fix specifications for all Optiq xml files in library sorted by version
    /// </summary>
    public static List<Specification.Document> Specifications(SortDirection sort = SortDirection.Descending)
    {
        var xmls = Xmls();
        var schemas = Sort(xmls, sort);

        var specifications = new List<Specification.Document>();

        foreach (var schema in schemas)
        {
            specifications.Add(Sbe.Optiq.Load.From(schema));
        }

        return specifications;
    }

    /// <summary>
    ///  Merge all iLink3 versions into a single normalized fix specification
    /// </summary>
    public static Specification.Document Combined()
    {
        var specifications = Specifications();

        return Fix.Specification.Merge.All(specifications);
    }
}