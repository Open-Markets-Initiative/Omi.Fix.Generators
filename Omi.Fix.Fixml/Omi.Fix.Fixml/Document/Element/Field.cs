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
    public void ToXml(XmlDocument doc,XmlElement parent) 
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
            DataType = DataTypeFor(Type),
            Underlying = Type,
            Enums = Enums.ToSpecification(),
            Description = Description,
            Required = Required,
            Version = Version
        };

    /// <summary>
    ///  Convert Fixml field to Omi Fix intermediate datatype
    /// </summary>
    public static Omi.Fix.Specification.DataType DataTypeFor(string type)
    {
        switch (type.Trim())
        {
            case "STRING":
            case "String":
            case "string":
                return Omi.Fix.Specification.DataType.String;

            case "COUNTRY":
            case "Country":
                return Omi.Fix.Specification.DataType.Country;

            case "CURRENCY":
            case "Currency":
                return Omi.Fix.Specification.DataType.Currency;

            case "EXCHANGE":
            case "Exchange":
                return Omi.Fix.Specification.DataType.String;

            case "LOCALMKTDATE":
            case "LocalMktDate":
                return Omi.Fix.Specification.DataType.LocalMktDate;

            case "MONTHYEAR":
            case "MonthYear":
                return Omi.Fix.Specification.DataType.MonthYear;

            case "MULTIPLEVALUESTRING":
            case "MultipleValueString":
                return Omi.Fix.Specification.DataType.MultipleValueString;

            case "UTCDATE":
            case "UTCDate":
            case "UtcDate":
                return Omi.Fix.Specification.DataType.UtcDate;

            case "UTCDATEONLY":
            case "UTCDateOnly":
            case "UtcDateOnly":
                return Omi.Fix.Specification.DataType.UtcDateOnly;

            case "UTCTIMEONLY":
            case "UTCTimeOnly":
            case "UtcTimeOnly":
                return Omi.Fix.Specification.DataType.UtcTimeOnly;

            case "UTCTIMESTAMP":
            case "UtcTimestamp":
            case "UTCTimestamp":
                return Omi.Fix.Specification.DataType.UtcTimestamp;

            case "CHAR":
            case "Char":
            case "char":
                return Omi.Fix.Specification.DataType.Char;

            case "BOOLEAN":
            case "Boolean":
                return Omi.Fix.Specification.DataType.Boolean;

            case "DATA":
            case "Data":
            case "data":
                return Omi.Fix.Specification.DataType.Data;

            case "FLOAT":
            case "Float":
            case "float":
                return Omi.Fix.Specification.DataType.Float;

            case "AMT":
            case "Amt":
                return Omi.Fix.Specification.DataType.Amt;

            case "PERCENTAGE":
            case "Percentage":
                return Omi.Fix.Specification.DataType.Percentage;

            case "PRICE":
            case "Price":
                return Omi.Fix.Specification.DataType.Price;

            case "PRICEOFFSET":
            case "PriceOffset":
                return Omi.Fix.Specification.DataType.PriceOffset;

            case "QTY":
            case "Qty":
                return Omi.Fix.Specification.DataType.Qty;

            case "INT":
            case "Int":
            case "int":
                return Omi.Fix.Specification.DataType.Int;

            case "DAYOFMONTH":
            case "DayOfMonth":
                return Omi.Fix.Specification.DataType.DayOfMonth;

            case "LENGTH":
            case "Length":
                return Omi.Fix.Specification.DataType.Length;

            case "NUMINGROUP":
            case "NumInGroup":
                return Omi.Fix.Specification.DataType.NumInGroup;

            case "SEQNUM":
            case "SeqNum":
                return Omi.Fix.Specification.DataType.SeqNum;

            case "TAGNUM":
            case "TagNum":
                return Omi.Fix.Specification.DataType.TagNum;

            default:
                throw new NotImplementedException($"Unknown Fixml type: {type}");
        }
    }

    /// <summary>
    /// Display Fixml Field as string
    /// </summary>
    public override string ToString()
        => $"{Number} {Name} : {Type}"; // need enums
}
