namespace Omi.Fix.Types;

using System.Xml;

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
        => new ()
        {
            Name = type.Name,
            Tag = type.Tag,
            DataType = TypeFor(type.DataType),
            Description = type.Description,
            Version = type.Version,
            Enums = Enums.From(type)
        };

    /// <summary>
    ///  Convert normalized fix type to xml field type
    /// </summary>
    public static string TypeFor(Fix.Specification.DataType type)
    {
        return type.ToString();
    }

    /// <summary>
    ///  Convert Xml field element to specification type
    /// </summary>
    public Specification.Type ToSpecification()
        => new()
        {
            Name = Name,
            Tag = Tag,
            DataType = TypeFor(DataType),
            Description = Description,
            Version = Version,
            Underlying = Description.Contains("Valid values") ? "Enum" : "", // hack for now
            Enums = Enums.ToSpecification()
        };

    /// <summary>
    ///  Convert Fix type field to Omi Fix intermediate type
    /// </summary>
    public static Omi.Fix.Specification.DataType TypeFor(string type)
    {
        switch (type.Trim())
        {
            case "char":
                return Specification.DataType.Char;

            case "Boolean":
            case "bool":
                return Specification.DataType.Boolean;

            case "data":
                return Specification.DataType.Data;

            case "float":
                return Specification.DataType.Float;

            case "Amt":
                return Specification.DataType.Amt;

            case "Price":
            case "price":
                return Specification.DataType.Price;

            case "PriceOffset":
                return Specification.DataType.PriceOffset;

            case "Qty":
            case "qty":
                return Specification.DataType.Qty;

            case "Int":
            case "int":
            case "long":
                return Specification.DataType.Int;

            case "day-of-month":
            case "dayofmonth":
            case "DayOfMonth":
                return Specification.DataType.DayOfMonth;

            case "String":
            case "string":
                return Specification.DataType.String;

            case "Currency":
                return Specification.DataType.Currency;

            case "Exchange":
            case "exchange":
                return Specification.DataType.String;

            case "LocalMktDate":
                return Specification.DataType.LocalMktDate;

            case "MonthYear":
            case "month - year":
            case "monthyear":
                return Specification.DataType.MonthYear;

            case "MultipleValueString":
                return Specification.DataType.MultipleValueString;

            case "UTCDate":
            case "UtcDate":
            case "utcdate":
            case "date":
                return Specification.DataType.UtcDate;

            case "UTCTimeOnly":
            case "UtcTimeOnly":
            case "utctime":
            case "time":
                return Specification.DataType.UtcTimeOnly;

            case "UTCTimestamp":
            case "datetime":
                return Specification.DataType.UtcTimestamp;

            default:
                throw new NotImplementedException($"Unknown Fix text type: {type}");
        }
    }

    /// <summary>
    /// Write field type to XML
    /// </summary>
    public void ToXml(XmlDocument document) 
    {
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

        return $"{Name} : {Tag}, {Description}"; // add if enum
    }
}