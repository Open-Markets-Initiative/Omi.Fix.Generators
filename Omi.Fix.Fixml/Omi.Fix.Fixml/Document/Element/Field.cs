namespace Omi.Fixml;
    using System.Linq;
using System.Xml;

/// <summary>
///  Fix Field Declaration (Type)
/// </summary>

public class Field
{

    /// <summary>
    ///  Fix Field Tag/Number
    /// </summary>
    public uint Number;

    /// <summary>
    ///  Fix Field Name (PascalCase)
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    ///  Fix Field Underlying Type (int/string/etc)
    /// </summary>
    public string Type = string.Empty;

    /// <summary>
    ///  Enum Values for this fix field type
    /// </summary>
    public Enums Enums = new();

    /// <summary>
    /// Description of field 
    /// </summary>
    public string Description = string.Empty;

    /// <summary>
    /// Is field required?
    /// </summary>
    public bool Required;

    /// <summary>
    /// Fix version of associated field
    /// </summary>
    public string Version = string.Empty;

    /// <summary>
    /// Appends XmlElement from Field to parent
    /// </summary>
    public void GenerateXml(XmlDocument doc,XmlElement parent) 
        {
        var fieldElement = doc.CreateElement("field");

        //Appends number attribute to fieldElement
        var numberAtr = doc.CreateAttribute("number");
        numberAtr.Value = Number.ToString();
        fieldElement.Attributes.Append(numberAtr);

        //Appends name attribute to fieldElement
        var nameAtr = doc.CreateAttribute("name");
        nameAtr.Value = Name;
        fieldElement.Attributes.Append(nameAtr);

        //Appends type attribute to fieldElement
        var typeAtr = doc.CreateAttribute("type");
        typeAtr.Value = Type;
        fieldElement.Attributes.Append(typeAtr);

        parent.AppendChild(fieldElement);

        foreach (var element in Enums) 
        {
            //Append XmlElement from enum to fieldElement
            element.GenerateXml(doc, fieldElement);
        }
    }

    /// <summary>
    ///  Is field type an enum?
    /// </summary>
    public bool IsEnum
        => Enums.Any();

    /// <summary>
    ///  Convert fixml Field to specification Type
    /// </summary>
    public Fix.Specification.Type ToSpecification()
        => new()
        {
            Tag = Number,
            Name = Name,
            Underlying = Type,
            Enums = Enums.ToSpecification(),
            Description = Description,
            Required = Required,
            Version = Version
        };

    /// <summary>
    /// Display Fixml Field as string
    /// </summary>
    public override string ToString()
        => $"{Number} {Name} : {Type}"; // need enums
}
