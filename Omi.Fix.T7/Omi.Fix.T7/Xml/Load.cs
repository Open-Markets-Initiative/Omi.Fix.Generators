namespace Omi.Fix.T7.Xml;

using System;
using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml;
using System.Text.RegularExpressions;

/// <summary>
///  Load T7 xml elements into generated object classes
/// </summary>

public static class Load
{
    /// <summary>
    ///  Load T7 xml file
    /// </summary>
    public static Model T7XmlFrom(string xml)
        => Load.From<Model>(xml);

    /// <summary>
    ///  Load fix specification document from T7 xml path
    /// </summary>
    public static Specification.Document From(string xml)
    {
        var model = T7XmlFrom(xml);

        return From(model);
    }

    /// <summary>
    ///  Load intermediate FIX representation from Eti xml
    /// </summary>
    public static Specification.Document From(Model model)
        => new ()
        {
            Information = new Specification.Information(),
            Messages = MessagesFrom(model),
            Types = TypesFrom(model)
        };

    /// <summary>
    ///  Load intermediate FIX message from Eti xml
    /// </summary>
    public static Specification.Messages MessagesFrom(Model xml)
    {
        var messages = new Specification.Messages();

        foreach (var message in xml.Structures.Where(structure => structure.type.Equals("Message")))
        {
            var current = new Specification.Message
            {
                Name = message.name,
                Type = message.numericID.ToString(),
                Category = CategoryFrom(message),
                Fields = FieldsFrom(message),
            };

            messages.Add(current);
        }

        return messages;
    }

    /// <summary>
    ///  Parse message for message category
    /// </summary>
    public static string CategoryFrom(ModelStructure message)
    {
        if (message.numericID < 10100 || message.numericID >= 10900) 
        {
            return "admin";
        }

        return "app"; // make intermediate versions of these?
    }

    /// <summary>
    ///  Load fields 
    /// </summary>
    public static List<Specification.Field> FieldsFrom(ModelStructure message)
    {
        var fields = new List<Specification.Field>();

        foreach (var field in message.Member ?? [])
        {
            var current = new Specification.Field
            {
                Name = field.name,
                Required = false
                // need kind?
            };

            fields.Add(current);
        }

        return fields;
    }

    /// <summary>
    ///  Normalize Fix Specification types from T7 DataTypes
    /// </summary>
    public static Specification.Types TypesFrom(Model model)
    {
        var types = new Specification.Types();

        var etitypes = (model.DataTypes ?? []).Where(type => type.numericIDSpecified);

        foreach (var type in etitypes)
        {
            var current = TypeFrom(type);

            types.Add(type.name, current);
        }

        return types;
    }

    /// <summary>
    ///  Normalize T7 DataType to Fix intern
    /// </summary>
    public static Specification.Type TypeFrom(ModelDataType type)
    {
        var current = new Specification.Type
        {
            Name = type.name,
            Tag = type.numericID,
            Description = type.description,
            DataType = DataTypeFrom(type),
            Underlying = type.type,
        };

        if (type.ValidValue != null && type.ValidValue.Length > 0)
        {
            var enums = new Specification.Enums();

            foreach (var value in type.ValidValue)
            {
                var @enum = new Specification.Enum
                {
                    Name = NameFrom(value),
                    Value = value.value,
                    Description = DescriptionFrom(value, enums)
                };

                enums.Add(@enum);
            }

            current.Enums = enums;
        }

        return current;
    }

    /// <summary>
    ///  Convert Eti type to FixType
    /// </summary>
    public static Specification.DataType DataTypeFrom(ModelDataType model)
    {
        var type = model.type.Trim();

        switch (type)
        {
            case "char":
                return Specification.DataType.Char;

            case "data":
                return Specification.DataType.Data;

            case "float":
            case "floatDecimal4":
            case "floatDecimal6":
            case "floatDecimal7":
                return Specification.DataType.Float;

            case "percentage":
                return Specification.DataType.Percentage;

            case "PriceType":
            case "price":
                return Specification.DataType.Price;

            case "Qty":
                return Specification.DataType.Qty;

            case "int":
                return Specification.DataType.Int;

            case "length":
                return Specification.DataType.Length;

            case "Counter":
                return Specification.DataType.NumInGroup;

            case "SeqNum":
                return Specification.DataType.SeqNum;

            case "String":
            case "ISIN":
            case "AlphaNumeric":
            case "Freetext":
                return Specification.DataType.String;

            case "CurrencyType":
                return Specification.DataType.Currency;

            case "LocalMktDate":
                return Specification.DataType.LocalMktDate;

            case "LocalMonthYearCod":
                return Specification.DataType.MonthYear;

            case "UTCTimestamp":
                return Specification.DataType.UtcTimestamp;

            default:
                throw new Exception($"Unknown Eti Fix type: {type}");
        }
    }

    /// <summary>
    ///  Normalize enum value
    /// </summary>
    public static string NameFrom(ModelDataTypeValidValue value)
    {
        // throw exception if value is missing

        return Format.Name(value.name);
    }

    /// <summary>
    ///  Process the original description
    /// </summary>
    public static string DescriptionFrom(ModelDataTypeValidValue value, Specification.Enums enums)
    {
        var description = value.description;

        if(description == string.Empty || description.Length > 35 || enums.Any(e => e.Description == description))
        {
            description = value.name;
        }

        string result = description.Replace("-", " ").Replace("_", " ").Replace(".", " ").Replace("/", " or ");

        result = Regex.Replace(result, @"\([^)]*\)", string.Empty).Trim();

        return result;
    }

    /// <summary>
    ///  Load classes from file path
    /// </summary>
    public static T From<T>(string xml)
    {
        using var reader = XmlReader.Create(xml);

        var serializer = XmlSerializer.FromTypes([typeof(T)])[0];
        if (serializer == null)
        {
            throw new Exception();
        }

        var classes = serializer.Deserialize(reader);
        if (classes == null)
        {
            throw new Exception();
        }

        return (T)classes;
    }

    /// <summary>
    ///  Load classes from file info
    /// </summary>
    public static T From<T>(FileInfo info)
    {
        using var reader = info.OpenRead();

        var serializer = XmlSerializer.FromTypes([typeof(T)])[0];
        if (serializer == null)
        {
            throw new Exception();
        }

        var classes = serializer.Deserialize(reader);
        if (classes == null)
        {
            throw new Exception();
        }

        return (T)classes;
    }
}