using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;
using System.Xml;

namespace Omi.Fix.Types;

/// <summary>
///  Fix Field (Type) Element
/// </summary>

public class Type
{

    /// <summary>
    ///  Fix Field Type Tag/Number
    /// </summary>
    public uint Tag = 0;

    /// <summary>
    ///  Fix Field Type Name
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    ///  Fix Field Type Value Type
    /// </summary>
    public string DataType = string.Empty;

    /// <summary>
    ///  Fix Field Type Version
    /// </summary>
    public string Version = string.Empty; // Maybe should be list

    /// <summary>
    ///  Fix Field Type Description
    /// </summary>
    public string Description = string.Empty;

    /// <summary>
    ///  Fix Field Type Note
    /// </summary>
    public string Note = string.Empty;

    /// <summary>
    ///  Fix Field Enumerated Values
    /// </summary>
    public Enums Enums = new();

    /// <summary>
    ///  Is Field an Enum?
    /// </summary>
    public bool IsEnum => Enums.Any();

    /// <summary>
    ///  Convert Xml field element to document field
    /// </summary>
    public static Type From(Xml.FixFieldsFixFieldSpec field)
    {

        // verify values
        return new Type
        {
            Name = field.Name,
            Tag = field.Tag,
            DataType = field.DataType,
            Description = field.Description,
            Version = field.Version,
            Enums = Enums.From(field)
        };
    }

    /// <summary>
    ///  Convert Xml type element to document field
    /// </summary>
    public static Type From(Xml.FixTypesFixType field)
    {
        // verify values
        return new Type
        {
            Name = field.Name,
            Tag = field.Tag,
            DataType = field.Type,
            Description = field.Description,
            Version = field.Version,
            Enums = Enums.From(field)
        };
    }

    /// <summary>
    ///  Convert normalized fix type to xml field
    /// </summary>
    public static Type From(Fix.Specification.Type type)
    {
        var dataType = type.DataType;

        if (String.IsNullOrWhiteSpace(type.DataType))
        {
            dataType = type.Underlying;
        }

        return new Type
        {
            Name = type.Name,
            Tag = type.Tag,
            DataType = dataType,
            Description = type.Description,
            Version = type.Version,
            Enums = Enums.From(type)
        };
    }

    /// <summary>
    ///  Convert Xml field element to specification type
    /// </summary>
    public Specification.Type ToSpecification()
        => new()
        {
            Name = Name,
            Tag = Tag,
            DataType = DataType,
            Description = Description,
            Version = Version,
            Underlying = Description.Contains("Valid values") ? "Enum" : "", // hack for now
            Enums = Enums.ToSpecification()
        };

    /// <summary>
    /// Write field type to XML
    /// </summary>
    public void ToXml(XmlDocument document) {
        var root = document.DocumentElement;
        var parent = document.CreateElement("FixType");
        root.AppendChild(parent);

        //Initialize and append name
        var nameElement = document.CreateElement("Name");
        nameElement.InnerText = Name;
        parent.AppendChild(nameElement);

        //Initialize and append tag
        var tagElement = document.CreateElement("Tag");
        tagElement.InnerText = Tag.ToString();
        parent.AppendChild(tagElement);

        //Initialize and append type
        var typeElement = document.CreateElement("Type");
        typeElement.InnerText = DataType;
        parent.AppendChild(typeElement);

        //Initialize and append description
        var descElement = document.CreateElement("Description");
        descElement.InnerText = Description;
        parent.AppendChild(descElement);

        //Initialize and append Note if not empty
        if (!String.IsNullOrWhiteSpace(Note)) {
            var noteElement = document.CreateElement("Description");
            noteElement.InnerText = Note;
            parent.AppendChild(noteElement);
        }

        //Initialize and append version
        var versionElement = document.CreateElement("Version");
        versionElement.InnerText = Version;
        parent.AppendChild(versionElement);

        if (IsEnum) {
            foreach (var @enum in Enums) {
                @enum.ToXml(document, parent);
            }
        }
    }

    /// <summary>
    ///  Display Fix field as string
    /// </summary>
    public override string ToString()
    {
        if (string.IsNullOrWhiteSpace(Description))
        {
            return $"{Name} : {Tag}";
        }

        return $"{Name} : {Tag}, {Description}"; // add if if enum
    }
}