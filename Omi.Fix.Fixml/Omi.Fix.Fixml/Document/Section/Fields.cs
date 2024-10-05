namespace Omi.Fixml;
    using System.Collections.Generic;
    using System.Linq;

/// <summary>
///  Fixml Fields (Fields Section)
/// </summary>

public class Fields : Dictionary<string, Field>
{
    /// <summary>
    ///  Load fields in fixml
    /// </summary>
    public static Fields From(Xml.fix xml)
    {
        var section = new Fields();

        foreach (var field in xml.fields)
        { // need ?? 
          // Verify field name exists // format
            section[field.name] = new Field
            {
                Name = field.name,
                Number = field.number,
                Type = field.type,
                Enums = Enums.From(field),
            };
        }

        return section;
    }

    /// <summary>
    ///  Errors in the Fields Section
    /// </summary>
    public List<string> Errors = new List<string>();

    /// <summary>
    /// Convert from specification Types to Xml Fields
    /// </summary>
    public static Fields From(Fix.Specification.Types fields)
    {
        var section = new Fields();

        foreach (var field in fields.Values)
        {
            // Verify field name exists // format
            section[field.Name] = new Field
            {
                Name = field.Name,
                Number = field.Tag,
                Type = field.Underlying,
                Enums = Enums.From(field),
                Description = field.Description,
                Required = field.Required,
                Version = field.Version,
            };
        }

        return section;
    }

    /// <summary>
    ///  Remove unused fields
    /// </summary>
    public void ReduceTo(HashSet<string> required)
    {
        foreach (var field in Values)
        {
            if (!required.Contains(field.Name))
            {
                Remove(field.Name);
            }
        }
    }

    /// <summary>
    /// Write fields to stream
    /// </summary>
    public void Write(StreamWriter stream, Indent indent)
    {
        if (Values.Any())
        {
            stream.WriteLine($"{indent}<fields>");

            foreach (var field in Values)
            {
                field.Write(stream);
            }

            stream.WriteLine($"{indent}</fields>");
        }
        else
        {
            stream.WriteLine($"{indent}<fields/>");
        }
    }

    /// <summary>
    ///  Convert fixml field declarations to normalized fix specification types
    /// </summary>
    public Fix.Specification.Types ToSpecification()
    {
        var types = new Fix.Specification.Types();

        var fields = this.Select(f => f.Value).ToList();

        foreach (var pair in fields)
        {
            types.Add(pair.Name, pair.ToSpecification());
        }

        return types;
    }
}
