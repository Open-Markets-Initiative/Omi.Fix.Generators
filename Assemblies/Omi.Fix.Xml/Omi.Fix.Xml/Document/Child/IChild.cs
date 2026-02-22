namespace Omi.Fix.Xml;
    using System.Xml;

/// <summary>
///  Fixml Child Element
/// </summary>

public interface IChild
{
    /// <summary>
    ///  Element name
    /// </summary>
    string Name { get; }

    /// <summary>
    ///  Element parent
    /// </summary>
    IParent Parent { get; }

    /// <summary>
    ///  Verify fixml child element properties
    /// </summary>
    void Verify(Fields fields, Components components);

    /// <summary>
    ///  Report erroneous fixml child element properties
    /// </summary>
    void Error(Fields fields, Components components, List<string> Errors);

    /// <summary>
    ///  Number of levels deep in element tree
    /// </summary>
    int Depth();

    /// <summary>
    ///  Convert to Xml Element
    /// </summary>
    void ToXml(XmlDocument doc, XmlElement parent);
}
