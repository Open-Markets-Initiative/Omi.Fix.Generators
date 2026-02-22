namespace Omi.Fix.Xml;
    using System.Xml;

/// <summary>
///  Financial Information eXchange FIXML C# Document Object Model
/// </summary>

public class Document
{
    /// <summary>
    ///  FIXML document information
    /// </summary>
    public Information Information = new();

    /// <summary>
    ///  FIXML header fields
    /// </summary>
    public Header Header = new();

    /// <summary>
    /// Fixml Trailer Fields
    /// </summary>
    public Trailer Trailer = new();

    /// <summary>
    /// FIXML messages
    /// </summary>
    public Messages Messages = new();

    /// <summary>
    /// FIXML components
    /// </summary>
    public Components Components = new();

    /// <summary>
    /// FIXML Fields
    /// </summary>
    public Fields Fields = new();

    /// <summary>
    /// FIXML Errors
    /// </summary>
    public List<string> Errors
    {
        get
        {
            var errors = new List<string>();

            Information.Error(Fields, Components, errors);
            Header.Error(Fields, Components, errors);
            Trailer.Error(Fields, Components, errors);

            // verify that all elements in Messages
            foreach (var message in Messages)
            {
                message.Error(Fields, Components, errors, Messages);
            }

            return errors;
        }
    }

    /// <summary>
    ///  Apply filter (predicate) to messages and normalize
    /// </summary>
    public Document Filter(Predicate<Message> predicate)
    {
        // Filter messages
        Messages.RemoveAll(message => !predicate(message));

        // Reduce to included messages
        var msgtypes = Messages.Types();
        Fields.ReduceMsgTypesTo(msgtypes);

        // Reduce to included components
        var components = GatherComponents();
        Components.ReduceTo(components);

        // Reduce to included fields
        var fields = GatherFields();
        Fields.ReduceTo(fields);

        return this;
    }

    /// <summary>
    ///  Gather set of included component identifiers in in FIXML document
    /// </summary>
    public HashSet<string> GatherComponents()
    {
        var set = new HashSet<string>();

        // Gather included components in header
        foreach (var element in Header.Elements)
        {
            Gather.ComponentsIn(element, Components, set);
        }

        // Gather included components in trailer
        foreach (var element in Trailer.Elements)
        {
            Gather.ComponentsIn(element, Components, set);
        }

        // Gather included components in messages
        foreach (var message in Messages)
        {
            foreach (var element in message.Elements)
            {
                Gather.ComponentsIn(element, Components, set);
            }
        }

        return set;
    }

    /// <summary>
    ///  Gather set of included field identifiers in FIXML document
    /// </summary>
    public HashSet<string> GatherFields()
    {
        var set = new HashSet<string>();

        // Gather included fields in header
        foreach (var header in Header.Elements)
        {
            Gather.FieldsIn(header, Components, set);
        }

        // Gather included fields in trailer
        foreach (var trailer in Trailer.Elements)
        {
            Gather.FieldsIn(trailer, Components, set);
        }

        // Gather included fields in messages
        foreach (var message in Messages)
        {
            foreach (var element in message.Elements)
            {
                Gather.FieldsIn(element, Components, set);
            }
        }

        return set;
    }

    /// <summary>
    ///  Load FIXML document from XML file 
    /// </summary>
    public static Document From(Xml.fix xml)
        => new()
        {
            Information = Information.From(xml),
            Header = Header.From(xml),
            Trailer = Trailer.From(xml),
            Messages = Messages.From(xml),
            Components = Components.From(xml),
            Fields = Fields.From(xml)
        };

    /// <summary>
    ///  Load FIXML file from path 
    /// </summary>
    public static Document From(string path)
    {
        var xml = Load.From(path);

        return From(xml);
    }

    /// <summary>
    ///  Convert to XML Document
    /// </summary>
    public XmlDocument ToXml()
    {
        var document = new XmlDocument();

        Information.ToXml(document);
        Header.ToXml(document);
        Trailer.ToXml(document);
        Messages.ToXml(document);
        Components.ToXml(document);
        Fields.ToXml(document);

        return document;
    }

    /// <summary>
    ///  Write Xml with default settings
    /// </summary>
    public void WriteTo(string path) 
    {
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
    public void WriteTo(string path, XmlWriterSettings settings) 
    {
        var xml = ToXml();

        using var writer = XmlWriter.Create(path, settings);

        xml.WriteTo(writer);
    }

    /// <summary>
    ///  Verify fixml
    /// </summary>
    public void Verify()
    {
        // fixmls require version information
        if (string.IsNullOrWhiteSpace(Information.Major))
        {
            throw new Exception("Missing Information");
        }

        // verify that all elements in messages
        foreach (var message in Messages)
        {
            message.Verify(Fields, Components);
        }
    }

    /// <summary>
    ///  FIXML as string
    /// </summary>
    public override string ToString()
        => $"{Information} Fixml";
}