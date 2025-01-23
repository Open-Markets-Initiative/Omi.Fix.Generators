namespace Omi.Fix.Sbe.Library;

/// <summary>
///  Cme ilink3 xml file library
/// </summary>

public static class iLink3
{
    /// <summary>
    ///  Gather all Cme ilink3 sbe xmls in library
    /// </summary>
    public static string[] Files()
    {
        var directory = Path.Combine(Directory.GetCurrentDirectory(), "Library", "Cme.iLink3");

        return Directory.GetFiles(directory, "*.xml");
    }

    /// <summary>
    ///  Gather iLink3 Sbe xmls
    /// </summary>
    public static List<Sbe.iLink3.messageSchema> Xmls()
    {
        var xmls = new List<Sbe.iLink3.messageSchema>();

        var files = Files();

        foreach (var file in files)
        {
            var current = Sbe.iLink3.Load.XmlFrom(file);

            xmls.Add(current);
        }

        return xmls;
    }

    /// <summary>
    ///  Sort iLink3 message schemas
    /// </summary>
    public static List<Sbe.iLink3.messageSchema> Sort(List<Sbe.iLink3.messageSchema> xmls, SortDirection sort = SortDirection.Descending)
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
    ///  Generate normalized fix specifications for all ilink3 xml files in library sorted by version
    /// </summary>
    public static List<Specification.Document> Specifications(SortDirection sort = SortDirection.Descending)
    {
        var xmls = Xmls();
        var schemas = Sort(xmls, sort);

        var specifications = new List<Specification.Document>();

        foreach (var schema in schemas)
        {
            specifications.Add(Sbe.iLink3.Load.From(schema));
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