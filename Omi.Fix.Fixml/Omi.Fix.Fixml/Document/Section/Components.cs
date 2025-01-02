namespace Omi.Fixml;
    using System.Collections.Generic;
    using System.Xml;

/// <summary>
///  Fixml Components (Components Section)
/// </summary>

public class Components : Dictionary<string, Component>
{
    /// <summary>
    ///  Default constructor
    /// </summary>
    public Components() { }

    /// <summary>
    ///  Load components in xml
    /// </summary>
    public Components(Xml.fix xml)
    {
        foreach (var element in ListFrom(xml))
        {
            var component = Component.From(element);
            this[component.Name] = component;
        }
    }

    /// <summary>
    ///  Load components in xml classes
    /// </summary>
    public static Components From(Xml.fix xml)
        => new(xml);

    /// <summary>
    ///  Errors in the components section
    /// </summary>
    public List<string> Errors = [];

    /// <summary>
    /// Fix Component from xml file
    /// </summary>
    public static Xml.fixComponent[] ListFrom(Xml.fix xml)
        => xml.components ?? [];

    /// <summary>
    ///  Convert normalized fix specification components to fixml components 
    /// </summary>
    public static Components From(Fix.Specification.Components components)
    {  // make this a dictionary also
        var section = new Components();

        foreach (var element in components)
        {
            var component = Component.From(element);
            section[component.Name] = component;
        }

        return section;
    }

    /// <summary>
    ///  Remove unused components
    /// </summary>
    public void ReduceTo(HashSet<string> required)
    {
        foreach (var component in Values)
        {
            if (!required.Contains(component.Name))
            {
                Remove(component.Name);
            }
        }
    }

    /// <summary>
    ///  Append as XML element
    /// </summary>
    public void ToXml(XmlDocument document)
    {
        var root = document.FirstChild;

        if (root != null)
        {
            var element = document.CreateElement("components");
            root.AppendChild(element);

            foreach (var component in Values)
            {
                component.ToXml(document, element);
            }
        }
    }

    /// <summary>
    ///  Convert FIXML components section to normalized FIX specification components
    /// </summary>
    public Fix.Specification.Components ToSpecification()
    {
        var components = new Fix.Specification.Components();

        foreach (var component in Values)
        {
            components.Add(component.ToSpecification());
        }

        return components;
    }
}
