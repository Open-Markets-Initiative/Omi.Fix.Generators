namespace Omi.Fix.Sbe.Library;

/// <summary>
///  Cme iLink3 xml file library
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
    ///  Generate normalized fix specifications for all iLink3 xml files in library sorted by version
    /// </summary>
    public static IEnumerable<Sbe.iLink3.messageSchema> SortedXmls(SortDirection direction = SortDirection.Descending)
    {
        var xmls = Xmls();

        if (direction == SortDirection.Ascending)
        {
            return xmls.OrderBy(schema => schema.id).ThenBy(schema => schema.version);
        }
        else
        {
            return xmls.OrderByDescending(schema => schema.id).ThenByDescending(schema => schema.version);
        }
    }

    /// <summary>
    ///  Convert iLink3 Sbe  specifications
    /// </summary>
    public static List<Specification.Document> Specifications(IEnumerable<Sbe.iLink3.messageSchema> schemas)
    {
        var specifications = new List<Specification.Document>();

        foreach (var schema in schemas)
        {
            var specification = Sbe.iLink3.Load.From(schema);

            specifications.Add(specification);
        }

        return specifications;
    }

    /// <summary>
    ///  Merge all iLink3 versions into a single normalized fix specification
    /// </summary>
    public static Specification.Document Combined(SortDirection direction = SortDirection.Descending)
    {
        var xmls = SortedXmls(direction);

        var specifications = Specifications(xmls);

        return Fix.Specification.Merge.All(specifications);
    }

    /// <summary>
    ///  Merge a count of iLink3 versions into a single normalized fix specification
    /// </summary>
    public static Specification.Document Last(int count, SortDirection direction = SortDirection.Descending)
    {
        var xmls = SortedXmls(direction).Take(count);

        var specifications = Specifications(xmls);

        return Fix.Specification.Merge.All(specifications);
    }

    /// <summary>
    ///  Latest 2 iLink3 protocol xmls merged into a single Omi Fix specification 
    /// </summary>
    public static Specification.Document Active()
        => Last(2);
}