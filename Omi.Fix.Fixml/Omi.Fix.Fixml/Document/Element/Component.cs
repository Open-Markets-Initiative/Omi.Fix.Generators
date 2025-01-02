namespace Omi.Fixml;
    using System.Linq;
using System.Xml;

/// <summary>
///  Fixml Component (predefined collection of elements)
/// </summary>

public class Component : IParent
{

    /// <summary>
    ///  Fixml component name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///  Fixml component elements list (fields, groups, components)
    /// </summary>
    public Elements Elements { get; set; } = new Elements();

    /// <summary>
    ///  Does component have fields?
    /// </summary>
    public bool HasFields
        => Elements.Any();

    /// <summary>
    ///  Convert xml component to fixml component
    /// </summary>
    public static Component From(Xml.fixComponent element)
    {
        // Verify values
        var component = new Component
        {
            Name = element.name
        };

        foreach (var item in element.Items)
        { // need ??
            component.Elements.Add(Child.Field.From(item, component));
        }

        return component;
    }

    /// <summary>
    /// Obtain fixml component from specification
    /// </summary>
    public static Component From(Fix.Specification.Component element)
    {
        // Verify values?
        var component = new Component
        {
            Name = element.Name
        };

        foreach (var item in element.Fields)
        {  // need ?? 
            component.Elements.Add(Child.Field.From(item, component));
        }

        return component;
    }

    /// <summary>
    /// Appends XmlElement from Component to parent
    /// </summary>
    public void ToXml(XmlDocument doc,XmlElement parent) 
        {
        var componentElement = doc.CreateElement("component");

        //Append name attribute to componentElement
        var nameAtr = doc.CreateAttribute("name");
        nameAtr.Value = Name;
        componentElement.Attributes.Append(nameAtr);

        parent.AppendChild(componentElement);

        //Append XmlElement from Elements to componentElement
        Elements.ToXml(doc, componentElement);
    }

    /// <summary>
    ///  Convert to standardized specification component
    /// </summary>
    public Fix.Specification.Component ToSpecification()
        => new()
        {
            Name = Name,
            Fields = Elements.ToSpecification()
        };

    /// <summary>
    ///  Display fixml component as string
    /// </summary>
    public override string ToString()
        => $"{Name} [{Elements.Count}]";
}