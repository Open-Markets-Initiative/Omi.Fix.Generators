namespace Omi.Fix.Types;

using System.Xml;

/// <summary>
///  Fix Type Enumerated Value
/// </summary>

public class Enum
{
    /// <summary>
    ///  Enum name
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    ///  Enum value
    /// </summary>
    public string Value = string.Empty;

    /// <summary>
    ///  Enum description
    /// </summary>
    public string Description = string.Empty;

    /// <summary>
    ///  Convert field value
    /// </summary>
    public static Enum From(Xml.FixFieldsFixFieldSpecFixEnumField @enum)
        => new()
        {
            Name = @enum.Key,
            Value = @enum.Value,
            //Description = @enum // todo
        };

    /// <summary>
    ///  Convert type value
    /// </summary>
    public static Enum From(Xml.FixTypesFixTypeEnum @enum)
        => new()
        {
            Name = @enum.Name,
            Value = @enum.Value,
            //Description = @enum // todo
        };

    /// <summary>
    ///  Convert normalized enum value to fields enum
    /// </summary>
    public static Enum From(Fix.Specification.Enum @enum)
        => new()
        {
            Name = @enum.Name,
            Value = @enum.Value,
            Description = @enum.Description
        };

    /// <summary>
    ///  Convert fields enumerated value to normalized fix specification value
    /// </summary>
    public Fix.Specification.Enum ToSpecification()
        => new()
        {
            Name = Name,
            Value = Value,
            Description = Description
        };

    /// <summary>
    /// Appends Xml Element from Enum to parent
    /// </summary>
    public void ToXml(XmlDocument document, XmlElement parent) 
    {
        var enumElement = document.CreateElement("Enum");
        parent.AppendChild(enumElement);

        //Initialize and append name element to enum element
        var nameElement = document.CreateElement("Name");
        nameElement.InnerText = Name;
        enumElement.AppendChild(nameElement);

        //Initialize and append value element to enum element
        var valueElement = document.CreateElement("Value");
        valueElement.InnerText = Value;
        enumElement.AppendChild(valueElement);

        //Initialize and append description element to enum element if not empty
        if (!string.IsNullOrEmpty(Description)) {
            var descElement = document.CreateElement("Description");
            descElement.InnerText = Description;
            enumElement.AppendChild(descElement);
        }
    }

    /// <summary>
    ///  Display enumerated value as string
    /// </summary>
    public override string ToString()
    {
        if (string.IsNullOrWhiteSpace(Description))
        {
            return $"{Name} = {Value}";
        }

        return $"{Name} = {Value}, {Description}";
    }
}