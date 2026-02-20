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
    ///  Gather Optiq Sbe xmls
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
    ///  Generate normalized fix specifications for all Optiq xml files in library sorted by version
    /// </summary>
    public static IEnumerable<Optiq.messageSchema> SortedXmls(SortDirection direction = SortDirection.Descending)
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
    ///  Convert Optiq Sbe  specifications
    /// </summary>
    public static List<Specification.Document> Specifications(IEnumerable<Optiq.messageSchema> schemas)
    {
        var specifications = new List<Specification.Document>();

        foreach (var schema in schemas)
        {
            var specification = Optiq.Load.From(schema);

            specifications.Add(specification);
        }

        return specifications;
    }

    /// <summary>
    ///  Merge all Optiq versions into a single normalized fix specification
    /// </summary>
    public static Specification.Document Combined(SortDirection direction = SortDirection.Descending)
    {
        var xmls = SortedXmls(direction);

        var specifications = Specifications(xmls);

        return Fix.Specification.Merge.All(specifications);
    }

    /// <summary>
    ///  Merge a count of Optiq versions into a single normalized fix specification
    /// </summary>
    public static Specification.Document Last(int count, SortDirection direction = SortDirection.Descending)
    {
        var xmls = SortedXmls(direction).Take(count);

        var specifications = Specifications(xmls);

        return Fix.Specification.Merge.All(specifications);
    }

    /// <summary>
    ///  Latest 2 Optiq protocol xmls merged into a single Omi Fix specification 
    /// </summary>
    public static Specification.Document Active()
        => Last(2);
}