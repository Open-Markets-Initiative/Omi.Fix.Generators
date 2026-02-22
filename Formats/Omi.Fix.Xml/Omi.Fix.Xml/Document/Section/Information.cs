namespace Omi.Fix.Xml;
    using System.Xml;

/// <summary>
///  FIXML information
/// </summary>

public class Information
{
    /// <summary>
    ///  Fixml Major Version
    /// </summary>
    public string Major = string.Empty;

    /// <summary>
    ///  Fixml Minor Version
    /// </summary>
    public string Minor = string.Empty;

    // TODO: Add Service pack

    /// <summary>
    ///  Errors in the Information
    /// </summary>
    public List<string> Errors = [];

    /// <summary>
    ///  Convert XML attributes to FIXML document information
    /// </summary>
    public static Information From(Xml.fix xml)
        => new()
        { // need more checks, defaults
            Major = xml.major.ToString(),
            Minor = xml.minor.ToString(),
        };

    /// <summary>
    ///  Create root Xml element for Information
    /// </summary>
    public XmlElement ToXml(XmlDocument document)
    {
        var root = document.CreateElement("fix");

        // Append major attribute to fix element
        var major = document.CreateAttribute("major");
        major.Value = Major;
        root.Attributes.Append(major);

        // Append minor attribute to fix element
        var minor = document.CreateAttribute("minor");
        minor.Value = Minor;
        root.Attributes.Append(minor);

        // Append fix element to document
        document.AppendChild(root);

        return root;
    }

    /// <summary>
    ///  Verify fixml information
    /// </summary>
    public void Verify()
    {
        if (string.IsNullOrWhiteSpace(Major))
        {
            throw new Exception("Missing Major Version");
        }
    }

    /// <summary>
    ///  Report errors in FIXML information
    /// </summary>
    public void Error(Fields fields, Components components, List<string> Errors)
    {
        if (string.IsNullOrWhiteSpace(Major))
        {
            Errors.Add("Missing Major Version");

            this.Errors.Add("Missing Major Version");
        }
        if (string.IsNullOrWhiteSpace(Minor))
        {
            Errors.Add("Missing Minor Version");

            this.Errors.Add("Missing Minor Version");
        }
    }

    /// <summary>
    ///  Display FIXML version information as string
    /// </summary>
    public override string ToString()
    {
        if (!string.IsNullOrWhiteSpace(Minor))
        {
            return $"{Major}.{Minor}";
        }
        if (string.IsNullOrWhiteSpace(Major))
        {
            return $"{Major}";
        }

        return "UNSPECIFIED";
    }
}