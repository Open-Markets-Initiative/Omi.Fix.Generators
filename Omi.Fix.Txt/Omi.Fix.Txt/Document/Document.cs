using Omi.Fix.Specification;

namespace Omi.Fix.Txt;

using System.IO;

/// <summary>
///  Omi Fix Text C# Document
/// </summary>

public class Document
{
    /// <summary>
    ///  Fix txt documention information
    /// </summary>
    public Information Information = new();

    /// <summary>
    ///  Fix txt fields
    /// </summary>
    public Fields Fields = new();

    /// <summary>
    ///  Fix txt enum values
    /// </summary>
    public Enums Enums = new();

    /// <summary>
    ///  Fix txt messages
    /// </summary>
    public Messages Messages = new();

    /// <summary>
    ///  Fix Txt document from path
    /// </summary>
    public static Document From(string path)
    {
        var lines = File.ReadLines(path);

        return From(lines);
    }

    /// <summary>
    ///  Fix Txt document from records
    /// </summary>
    public static Document From(IEnumerable<string> lines)
    {
        var enums = Enums.From(lines);

        // need to parse these in order 

        return new()
        {
            Information = Information.From(lines),
            Enums = enums,
            Fields = Fields.From(lines, enums),
            Messages = Messages.From(lines)
        };
    }

    /// <summary>
    ///  Convert fix txt to normalized fix specification
    /// </summary>
    public Specification.Document ToSpecification()
        => new()
        {
            Information = Information.ToSpecification(),
            Messages = Messages.ToSpecification(),
            Types = Fields.ToSpecification(Enums),
        };

    /// <summary>
    ///  Convert fix txt to normalized fix specification
    /// </summary>
    public Specification.Document ToSpecificationEnumsAsTypes()
        => new()
        {
            Information = Information.ToSpecification(),
            Messages = Messages.ToSpecification(),
            Types = Enums.ToSpecificationAsTypes()
        };

    /// <summary>
    ///  Fix Txt description as string
    /// </summary>
    public override string ToString()
        => $"{Information} FIX txt";
}
