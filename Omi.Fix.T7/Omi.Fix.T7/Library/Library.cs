namespace Omi.Fix.T7.Library;

/// <summary>
///  Eurex T7 File Library
/// </summary>

public static class Eti
{
    /// <summary>
    ///  Gather all Eurex Eti xmls in library
    /// </summary>
    public static string[] Files()
    {
        var directory = Path.Combine(Directory.GetCurrentDirectory(), "Library", "Eurex.Eti");

        return Directory.GetFiles(directory, "*.xml");
    }

    /// <summary>
    ///  Gather all Eurex Eti Xmls
    /// </summary>
    public static List<Xml.Model> Xmls()
    {
        var files = Files();

        var xmls = new List<Xml.Model>();

        foreach (var file in files ?? [])
        {
            var current = Xml.Load.T7XmlFrom(file);

            xmls.Add(current);
        }

        return xmls;
    }

    /// <summary>
    ///  Generate normalized fix specifications for all Eti xml files in library sorted by version
    /// </summary>
    public static List<Specification.Document> Specifications(SortDirection sort = SortDirection.Descending)
    {
        var xmls = Xmls();

        // sort schemas
        var schemas = new List<Xml.Model>();

        if (sort == SortDirection.Ascending)
        {
            schemas = xmls.OrderBy(schema => schema.version).ToList();
        }
        else
        {
            schemas = xmls.OrderByDescending(schema => schema.version).ToList();
        }

        var specifications = new List<Specification.Document>();

        foreach (var model in xmls)
        {
            var current = Xml.Load.From(model);

            specifications.Add(current);
        }

        return specifications;
    }

    /// <summary>
    ///  Merge all Eti T7 versions into a single normalized fix specification
    /// </summary>
    public static Specification.Document Combined()
    {
        var specifications = Specifications();

        return Specification.Merge.All(specifications);
    }
}