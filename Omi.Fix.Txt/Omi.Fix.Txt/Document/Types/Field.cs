namespace Omi.Fix.Txt;

using System;
using System.Linq;

/// <summary>
///  Fix Txt Type
/// </summary>

public class Field
{
    /// <summary>
    ///  Fix Field Tag/Number
    /// </summary>
    public string Number = string.Empty;

    /// <summary>
    ///  Fix Field Name
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    ///  Fix Field Underlying Type (int/string/etc)
    /// </summary>
    public string Type = string.Empty;

    /// <summary>
    ///  Parse fix field (type) from string
    /// </summary>
    public static Field From(string line)
    { // add line index
      // validate field record
        if (!IsValidLine(line))
        {
            throw new ArgumentException($"Invalid line: {line}");
        }

        var tokens = TrimLine(line).Split(':');

        if (InvalidSplit(tokens))
        {
            throw new ArgumentException($"Invalid field record: {line}");
        }

        // parse type elements
        if (!TryParseTag(tokens, out var tag))
        {
            throw new ArgumentException($"Invalid record, tag: {line}");
        }

        if (!TryParseName(tokens, out var name))
        {
            throw new ArgumentException($"Invalid record, name: {line}");
        }

        if (!TryParseType(tokens, out var type))
        {
            throw new ArgumentException($"Invalid record, type: {line}");
        }

        return From(tag, name, type);
    }

    /// <summary>
    /// Returns fix field from properties
    /// </summary>
    public static Field From(string number, string name, string type)
     => new()
     {
         Number = number,
         Name = name,
         Type = type,
     };

    /// <summary>
    ///  Try parse Fix tag from tokenized record
    /// </summary>
    public static bool TryParseTag(string[] tokens, out string tag)
    {
        tag = tokens[0];

        return true;
    }


    /// <summary>
    ///  Try parse Fix field name from tokenized record
    /// </summary>
    public static bool TryParseName(string[] tokens, out string name)
    {
        name = tokens[1];

        return true;
    }

    /// <summary>
    ///  Try parse Fix field name from tokenized record
    /// </summary>
    public static bool TryParseType(string[] tokens, out string type)
    {
        type = tokens[2]; // could make this default to string

        return true;
    }

    ///<summary>
    ///  Removes comments and white space from field record
    /// </summary>
    public static string TrimLine(string line)
    {
        var index = line.IndexOf('#');

        if (index > 0)
        {
            line = String.Concat(line[..index].Where(c => !Char.IsWhiteSpace(c)));
        }

        return line;
    }

    ///<summary>
    /// Checks that string array is valid
    ///</summary>
    public static bool InvalidSplit(string[] split)
    {
        if (split.Length != 3)
        {
            return true;
        }

        foreach (string field in split)
        {
            if (string.IsNullOrWhiteSpace(field))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Check that line contains field properties
    /// </summary>
    public static bool IsValidLine(string line)
    {
        // Verify Line is not empty
        if (string.IsNullOrWhiteSpace(line))
        {
            throw new ArgumentException(nameof(line));
        }

        var index = line.IndexOf(":enum:");

        // Verify line is an enum
        if (index > 0)
        {
            throw new ArgumentException(nameof(line));
        }

        // Line is a comment
        if (line[0].Equals("#"))
        {
            throw new ArgumentException(nameof(line));
        }

        return true;
    }

    /// <summary>
    ///  Normalize to FIx intermediate specification type
    /// </summary>
    public Specification.Type ToSpecification(Enums enums)
        => new()
        {
            Tag = NormalizeTag(Number),
            Name = Name, // trim?
            DataType = NormalizeType(Name, Type, enums),
            Underlying = NormalizeUnderlying(Type),
            Enums = enums.ToSpecification(Name, Type)
        };

    /// <summary>
    ///  Normalize tag
    /// </summary>
    public static uint NormalizeTag(string text)
        => uint.Parse(text);

    /// <summary>
    ///  Normalize type
    /// </summary>
    public static Specification.DataType NormalizeType(string name, string type, Enums enums)
    {
        // enum declarations contain type

        if (enums.TryGetType(name, out var first))
        {
            type = first;
        }
        else if (enums.TryGetType(type, out var second))
        {
            type = second;
        }

        return ConvertType(type);
    }

    /// <summary>
    ///  Check that type is valid fix 
    /// </summary>
    public static Omi.Fix.Specification.DataType ConvertType(string type)
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
    ///  Underlying custom types
    /// </summary>
    public static string NormalizeUnderlying(string text)
    {
        var type = text.Trim();

        switch (type)
        {
            case "long": // allow overrides of some types
            case "string":
            case "int":
            case "char":
            case "hexlong":
            case "data":
            case "datalen":
                return type;

            default:
                return "";
        }
    }

    /// <summary>
    /// Display fix txt type
    /// </summary>
    public override string ToString()
        => $"{Number} => {Name}, {Type}";
}