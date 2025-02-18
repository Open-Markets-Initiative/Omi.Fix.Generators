namespace Omi.Fix.T7.Library;

/// <summary>
///  Eurex T7 Eti cash xml Library
/// </summary>

public static class EtiCash
{
    /// <summary>
    ///  Gather all Eurex Eti cash xmls in library
    /// </summary>
    public static string[] Files()
    {
        var directory = Path.Combine(Directory.GetCurrentDirectory(), "Library", "Eurex.Eti.Cash");

        return Directory.GetFiles(directory, "*.xml");
    }

    /// <summary>
    ///  Gather all Eurex Eti cash xmls
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
    ///  Sorted list of all Eti cash xml files in library
    /// </summary>
    public static IEnumerable<T7.Xml.Model> SortedXmls(SortDirection direction = SortDirection.Descending)
    {
        var xmls = Xmls();

        if (direction == SortDirection.Ascending)
        {
            return xmls.OrderBy(schema => schema.version);
        }
        else
        {
            return xmls.OrderByDescending(schema => schema.version);
        }
    }

    /// <summary>
    ///  Convert Eti cash to normalized Fix models
    /// </summary>
    public static List<Specification.Document> Specifications(IEnumerable<T7.Xml.Model> models)
    {
        var specifications = new List<Specification.Document>();

        foreach (var model in models)
        {
            var current = Xml.Load.From(model);

            specifications.Add(current);
        }

        return specifications;
    }

    /// <summary>
    ///  Merge all T7 Eti derivative versions into a single normalized fix specification
    /// </summary>
    public static Specification.Document Combined(SortDirection direction = SortDirection.Descending)
    {
        var xmls = SortedXmls(direction); // need both sets here

        var specifications = Specifications(xmls);

        return Fix.Specification.Merge.All(specifications);
    }

    /// <summary>
    ///  Merge a count of T7 Eti derivative into a single normalized fix specification
    /// </summary>
    public static Specification.Document Last(int count, SortDirection direction = SortDirection.Descending)
    {
        var xmls = SortedXmls(direction).Take(count);

        var specifications = Specifications(xmls);

        return Fix.Specification.Merge.All(specifications);
    }

    /// <summary>
    ///  Latest 2 T7 Eti derivative xmls merged into a single Omi Fix specification 
    /// </summary>
    public static Specification.Document Active()
        => Last(2);
}