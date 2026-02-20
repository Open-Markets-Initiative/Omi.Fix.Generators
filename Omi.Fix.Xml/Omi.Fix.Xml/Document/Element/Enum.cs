using System.Xml;

namespace Omi.Fix.Xml;

/// <summary>
///  Fixml Enumerated Value
/// </summary>

public class Enum
{

    /// <summary>
    ///  Fixml Enumerated value (enum attribute)
    /// </summary>
    public string Value = string.Empty;

    /// <summary>
    ///  Fixml Enumerated value Name (description attribute)
    /// </summary>
    public string Description = string.Empty;

    /// <summary>
    ///  Convert xml enum to fixml enum
    /// </summary>
    public static Enum From(Xml.fixFieldValue @enum)
        => new()
        {
            Value = @enum.@enum,
            Description = @enum.description
        };

    /// <summary>
    /// Convert fixml enum from a fixml element
    /// </summary>
    public static Enum From(Fix.Specification.Enum @enum)
        => new()
        {
            Value = @enum.Value,
            Description = @enum.Name
        };

    /// <summary>
    /// Appends XmlElement from Enum to parent
    /// </summary>
    public void GenerateXml(XmlDocument doc,XmlElement parent) 
        {
        var enumElement = doc.CreateElement("value");

        //Appends enum attribute to enumElement
        var enumAtr = doc.CreateAttribute("enum");
        enumAtr.Value = Value;
        enumElement.Attributes.Append(enumAtr);

        //Appends description attribute to enumElement
        var descAtr = doc.CreateAttribute("description");
        descAtr.Value = Description;
        enumElement.Attributes.Append(descAtr);

        parent.AppendChild(enumElement);
    }

    /// <summary>
    ///  Convert to normalized fix specification enum
    /// </summary>
    public Fix.Specification.Enum ToSpecification()
        => new()
        {
            Value = Value,
            Name = Description
        };

    /// <summary>
    ///  Display enumerated value as string
    /// </summary>
    public override string ToString()
       => $"{Value} = {Description}";
}
