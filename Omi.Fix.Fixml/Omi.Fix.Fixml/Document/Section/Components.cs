namespace Omi.Fixml;
    using System.Collections.Generic;
    using System.Linq;

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
    ///  Load components in xml
    /// </summary>
    public static Components From(Xml.fix xml)
        => new(xml);

    /// <summary>
    ///  Errors in the Components Section
    /// </summary>
    public List<string> Errors = new List<string>();

    /// <summary>
    /// Fix Component from xml file
    /// </summary>
    public static Xml.fixComponent[] ListFrom(Xml.fix xml)
        => xml.components ?? Array.Empty<Xml.fixComponent>();

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
    ///  Write components out to Fixml
    /// </summary>
    public void Write(StreamWriter stream, Indent indent)
    {
        if (this.Any())
        {
            stream.WriteLine($"{indent}<components>");

            foreach (var component in Values)
            { // should sort
                component.Write(stream, indent.Increment());
            }

            stream.WriteLine($"{indent}</components>");
        }
        else
        {
            stream.WriteLine($"{indent}<components/>");
        }
    }

    /// <summary>
    ///  Convert fixml components section to normalized fix specification components
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
