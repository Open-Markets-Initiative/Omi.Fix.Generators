namespace Omi.Fixml;
    using System.Linq;
using System.Xml;

/// <summary>
///  Fixml rrailers (Trailer section)
/// </summary>

public class Trailer : IParent
{
    /// <summary>
    ///  Fixml trailer child elements list (fields, groups, components)
    /// </summary>
    public Elements Elements { get; set; } = [];

    /// <summary>
    ///  Does fixml trailer have elements?
    /// </summary>
    public bool HasFields
        => Elements.Any();

    /// <summary>
    ///  Errors in the Trailer
    /// </summary>
    public List<string> Errors = [];

    /// <summary>
    ///  Convert xml file elements to fixml trailer
    /// </summary>
    public static Trailer From(Xml.fix xml)
    {
        var section = new Trailer();

        foreach (var item in ElementsIn(xml))
        {
            section.Elements.Add(Child.Field.From(item, section));
        }

        return section;
    }

    /// <summary>
    ///  Array of trailer elements in fixml
    /// </summary>
    public static object[] ElementsIn(Xml.fix xml)
        => xml?.trailer.Items ?? Array.Empty<object>();

    /// <summary>
    ///  Convert normalized specification trailer to fixml trailer
    /// </summary>
    public static Trailer From(Fix.Specification.Trailer trailer)
    {
        var section = new Trailer();

        foreach (var field in trailer)
        {
            // Verify format
            section.Elements.Add(new Child.Field
            {
                Parent = section,
                Name = field.Name,
                Required = field.Required,
            });
        }

        return section;
    }

    /// <summary>
    ///  Appends XmlElement from Trailer to root
    /// </summary>
    public void ToXml(XmlDocument document, XmlElement root) 
    {
        var trailer = document.CreateElement("trailer");
        root.AppendChild(trailer);

        Elements.ToXml(document, trailer);
    }

    /// <summary>
    ///  Report erroneous fixml trailer properties
    /// </summary>
    public void Error(Fields fields, Components components, List<string> Errors)
    {
        var repeats = Elements.GroupBy(x => x.Name)
          .Where(g => g.Count() > 1)
          .Select(y => y.Key)
          .ToList();

        if (repeats.Any())
        {
            foreach (var repeat in repeats)
            {
                Errors.Add($"{repeat} : Tag occurs more than once in trailer");

                this.Errors.Add($"{repeat} : Tag occurs more than once in trailer");
            }
        }

        Elements.Error(fields, components, Errors);
    }

    /// <summary>
    ///  Convert fixml trailer to normalized fix specification trailer
    /// </summary>
    public Fix.Specification.Trailer ToSpecification()
    {
        var trailer = new Fix.Specification.Trailer();

        foreach (var element in Elements)
        {
            trailer.Add(element.ToSpecification());
        }

        return trailer;
    }

    /// <summary>
    ///  Display trailer as string
    /// </summary>
    public override string ToString()
       => $"Count = {Elements.Count}";
}