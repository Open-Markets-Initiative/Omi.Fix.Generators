namespace Omi.Fix.Types;

using System.Xml;

/// <summary>
///  Fix Field (Type) Element
/// </summary>

public class Type
{
    /// <summary>
    ///  Fix field type tag (Number)
    /// </summary>
    public uint Tag = 0;

    /// <summary>
    ///  Fix field type name
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    ///  Fix field type datatype
    /// </summary>
    public string DataType = string.Empty;

    /// <summary>
    ///  Fix field type version
    /// </summary>
    public string Version = string.Empty; // Maybe should be list

    /// <summary>
    ///  Fix field type description
    /// </summary>
    public string Description = string.Empty;

    /// <summary>
    ///  Fix field type note
    /// </summary>
    public string Note = string.Empty;

    /// <summary>
    ///  Fix field type enumerated values
    /// </summary>
    public Enums Enums = [];

    /// <summary>
    ///  Is Fix field an enum?
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
            case "Char":
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

            case "Percentage":
                return Specification.DataType.Percentage;

            case "Price":
            case "price":
                return Specification.DataType.Price;

            case "PriceOffset":
                return Specification.DataType.PriceOffset;

            case "Quantity":
            case "quantity":
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

            case "MultipleCharValue":
                return Specification.DataType.MultipleCharValue;

            case "MultipleStringValue":
            case "MultipleValueString":
                return Specification.DataType.MultipleValueString;

            case "Currency":
                return Specification.DataType.Currency;

            case "Exchange":
            case "exchange":
                return Specification.DataType.String;

            case "LocalMktDate":
                return Specification.DataType.LocalMktDate;

            case "MonthYear":
            case "month-year":
            case "month - year":
            case "monthyear":
                return Specification.DataType.MonthYear;

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

            case "NumInGroup":
                return Specification.DataType.NumInGroup;

            case "SeqNum":
                return Specification.DataType.SeqNum;

            case "Length":
                return Specification.DataType.Length;

            case "UTCDateOnly":
                return Specification.DataType.UtcDateOnly;

            case "Country":
                return Specification.DataType.Country;

            case "TZTimeOnly":
                return Specification.DataType.TzTimeOnly;

            case "TZTimestamp":
                return Specification.DataType.TzTimestamp;

            case "XMLData":
                return Specification.DataType.XmlData;

            case "Language":
                return Specification.DataType.Language;

            default:
                throw new NotImplementedException($"Unknown Fix type: {type}");
        }
    }

    /// <summary>
    /// Write field type to XML
    /// </summary>
    public void ToXml(XmlDocument document, XmlElement parent) 
    {
        if (parent != null)
        {
            var element = document.CreateElement("FixType");
            parent.AppendChild(element);

            var name = document.CreateElement("Name");
            name.InnerText = Name;
            element.AppendChild(name);

            var tag = document.CreateElement("Tag");
            tag.InnerText = Tag.ToString();
            element.AppendChild(tag);

            var type = document.CreateElement("Type");
            type.InnerText = DataType;
            element.AppendChild(type);

            var description = document.CreateElement("Description");
            description.InnerText = Description;
            element.AppendChild(description);

            if (!string.IsNullOrWhiteSpace(Note))
            {
                var note = document.CreateElement("Note");
                note.InnerText = Note;
                element.AppendChild(note);
            }

            var version = document.CreateElement("Version");
            version.InnerText = Version;
            element.AppendChild(version);

            if (IsEnum)
            {
                foreach (var @enum in Enums)
                {
                    @enum.ToXml(document, element);
                }
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