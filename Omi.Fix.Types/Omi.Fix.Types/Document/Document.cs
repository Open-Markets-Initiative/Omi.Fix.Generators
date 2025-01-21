using System.Xml;

namespace Omi.Fix.Types;

/// <summary>
///  Omi Fix Types C# Document
/// </summary>

public class Document
{

    /// <summary>
    ///  Fix types xml documention information
    /// </summary>
    public Information Information = new();

    /// <summary>
    ///  Fix types
    /// </summary>
    public Types Fields = new();

    /// <summary>
    ///  Construct a document from path to a fields xml
    /// </summary>
    public static Document From(string path)
    { // this one should be general
        var elements = Load.FieldsXmlFrom(path);
        return From(elements, path);
    }

    /// <summary>
    ///  Construct a document from path to a types xml
    /// </summary>
    public static Document FromTypesXml(string path)
    {
        var elements = Load.TypesXmlFrom(path);
        return From(elements, path);
    }

    /// <summary>
    ///  Construct a document from xml fields records
    /// </summary>
    public static Document From(Xml.FixFields xml, string? path = default)
        => new()
        {
            Information = Information.From(xml, path),
            Fields = Types.From(xml)
        };

    /// <summary>
    ///  Construct a document from xml types records
    /// </summary>
    public static Document From(Xml.FixTypes xml, string? path = default)
        => new()
        {
            Information = Information.From(xml, path),
            Fields = Types.From(xml)
        };

    /// <summary>
    ///  Convert normalized fix specification to fix fields
    /// </summary>
    public static Document From(Fix.Specification.Document specification)
    {

        var document = new Document();

        document.Information = Information.From(specification.Information);
        document.Fields = Types.From(specification.Types);

        foreach (var pair in document.Fields)
        {
            if (String.IsNullOrWhiteSpace(pair.Value.Version))
            {
                pair.Value.Version = $"FIX{specification.Information.Major}{specification.Information.Minor}";
            }
        }

        return document;
    }

    /// <summary>
    ///  Convert fix fields document to normalized fix specification
    /// </summary>
    public Specification.Document ToSpecification()
        => new()
        {
            Information = Information.ToSpecification(),
            Header = new Specification.Header(),
            Trailer = new Specification.Trailer(),
            Messages = new Specification.Messages(),
            Components = new Specification.Components(),
            Types = Fields.ToSpecification()
        };

    /// <summary>
    ///  Convert to XML Document
    /// </summary>
    public XmlDocument ToXml() {
        var document = new XmlDocument();

        Fields.ToXml(document);

        return document;
    }

    /// <summary>
    ///  Write Xml with default settings
    /// </summary>
    public void WriteTo(string path) {
        var settings = new XmlWriterSettings
        {
            Indent = true,
            IndentChars = "  ",                  // Use two spaces for indentation
            NewLineChars = Environment.NewLine,
            OmitXmlDeclaration = true,           // Exclude the XML declaration
            Encoding = System.Text.Encoding.UTF8 // Use UTF-8 encoding
        };

        WriteTo(path, settings);
    }

    /// <summary>
    ///  Write XML with settings
    /// </summary>
    public void WriteTo(string path, XmlWriterSettings settings) {
        var xml = ToXml();

        using var writer = XmlWriter.Create(path, settings);

        xml.WriteTo(writer);
    }

    /// <summary>
    ///  Fix Types xml as string
    /// </summary>
    public override string ToString()
        => $"{Information} Fix Types";
}