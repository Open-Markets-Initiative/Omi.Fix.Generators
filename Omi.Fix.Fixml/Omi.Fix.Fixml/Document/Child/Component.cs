namespace Omi.Fixml.Child;
    using Omi.Fix.Specification;

/// <summary>
///  Fix Xml Component Element
/// </summary>

public class Component : IChild
{
    /// <summary>
    ///  Fixml component name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///  Fixml component parent
    /// </summary>
    public required IParent Parent { get; set; } // how to deal with this

    /// <summary>
    ///  Component depth in element tree
    /// </summary>
    public int Depth()
        => Omi.Fixml.Depth.Of(this);

    /// <summary>
    ///  Convert xml child component element to fixml document element 
    /// </summary>
    public static Component From(Xml.fixChildComponent element, IParent parent)
    {
        // Verify values

        return new Component
        {
            Name = element.name,
            Parent = parent
        };
    }

    /// <summary>
    ///  Convert xml normalized fix specification to fixml document element 
    /// </summary>
    public static Component From(Fix.Specification.Field element, IParent parent)
        => new()
        {
            Name = element.Name,
            Parent = parent
        };

    /// <summary>
    ///  Convert fixml component to normalized specification component
    /// </summary>
    public Fix.Specification.Field ToSpecification()
        => new()
        {
            Kind = Kind.Component,
            Name = Name,
        };

    /// <summary>
    ///  Write fixml component to stream
    /// </summary>
    public void Write(StreamWriter stream, Indent indent)
    {
        stream.WriteLine($"{indent}<component name=\"{Name}\"/>");
    }

    /// <summary>
    ///  Verify fixml component element
    /// </summary>
    public void Verify(Fields fields, Fixml.Components components)
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new Exception("Component name is missing");
        }

        if (!components.ContainsKey(Name))
        {
            throw new Exception($"{Name}: Component is missing from dictionary");
        }
    }

    /// <summary>
    ///  Report erroneous fixml component element
    /// </summary>
    public void Error(Fields fields, Fixml.Components components, List<string> Errors)
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            Errors.Add("Component name is missing");
        }

        if (!components.ContainsKey(Name))
        {
            Errors.Add($"{Name}: Component is missing from dictionary");
        }
    }

    /// <summary>
    ///  Display fixml component element as string
    /// </summary>
    public override string ToString()
        => $"{Name} [Component]";
}