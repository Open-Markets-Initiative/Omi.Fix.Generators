﻿namespace Omi.Fix.Sbe.iLink3;

/// <summary>
///  Normalize iLink3 Sbe Xml into Omi Fix intermediate specification types
/// </summary>

public static class Types
{
    /// <summary>
    ///  Normalize iLink3 Sbe types
    /// </summary>
    public static Specification.Types From(messageSchema xml)
    {
        var types = new Specification.Types();

        foreach (var message in xml.message ?? [])
        {
            Process(message, xml, types);
        }

        return types;
    }

    /// <summary>
    ///  Normalize iLink3 Sbe types
    /// </summary>
    public static void Process(messageSchemaMessage message, messageSchema xml, Specification.Types types)
    {
        // message fields
        foreach (var field in message.field ?? [])
        {
            Process(field, xml, types);
        }

        // repeating groups
        foreach (var group in message.group ?? [])
        {
            Process(group, xml, types);

            foreach (var field in group.field ?? [])
            {
                Process(field, xml, types);
            }
        }

        // data types?
    }

    /// <summary>
    ///  Convert message field to normalized Omi Fix intermediate type
    /// </summary>
    public static void Process(field field, messageSchema xml, Specification.Types types)
    {
        var name = NameFor(field);

        if (types.ContainsKey(name)) { return; }

        // TODO: verify field values

        var type = new Specification.Type()
        {
            Name = name,
            Tag = field.id,
            Description = field.description,
            Underlying = UnderlyingTypeFor(field.semanticType, xml),
            DataType = DataTypeFor(field.semanticType),
            Enums = EnumsFor(field.name, field.type, xml)
        };

        types.Add(type);
    }

    /// <summary>
    ///  Parse field element for field name
    /// </summary>
    public static string NameFor(field field)
    {
        ArgumentNullException.ThrowIfNull(field);
        ArgumentException.ThrowIfNullOrWhiteSpace(field.name);

        return Format.Name(field.name);
    }

    /// <summary>
    ///  Convert message field to normalized Fix intermediate type
    /// </summary>
    public static void Process(group group, messageSchema xml, Specification.Types types)
    {
        var name = NameFor(group);

        if (types.ContainsKey(name)) { return; }

        var type = new Specification.Type()
        {
            Name = name,
            Tag = group.id,
            Description = group.description,
            Underlying = group.dimensionType,
            DataType = Specification.DataType.NumInGroup
            // Is this num in Group?
        };

        types.Add(type);
    }

    /// <summary>
    ///  Parse field element for field name
    /// </summary>
    public static string NameFor(group group)
    {
        // verify

        return group.name;
    }

    /// <summary>
    ///  Convert message field to normalized Fix intermediate type
    /// </summary>
    public static void Process(groupField field, messageSchema xml, Specification.Types types)
    {
        var name = NameFor(field);

        if (types.ContainsKey(name)) { return; }

        // should verify field values

        var type = new Specification.Type()
        {
            Name = NameFor(field),
            Tag = field.id,
            Description = field.description,
            Underlying = field.semanticType,
            DataType = DataTypeFor(field.semanticType),
            Enums = EnumsFor(field.name, field.type, xml)
        };

        types.Add(type);
    }

    /// <summary>
    ///  Parse field element for field name
    /// </summary>
    public static string NameFor(groupField field)
    {
        ArgumentNullException.ThrowIfNull(field);
        ArgumentException.ThrowIfNullOrWhiteSpace(field.name);

        return Format.Name(field.name);
    }

    /// <summary>
    ///  Normalize underlying iLink3 Type
    /// </summary>
    public static string UnderlyingTypeFor(string type, messageSchema xml)
    {
        // TODO: search for correct type

        return type;
    }

    /// <summary>
    ///  Convert iLink3 type to FixType
    /// </summary>
    public static Specification.DataType DataTypeFor(string type)
    {
        switch (type)
        {
            case "char":
                return Specification.DataType.Char;

            case "data":
                return Specification.DataType.Data;

            case "float":
                return Specification.DataType.Float;

            case "Price":
                return Specification.DataType.Price;

            case "Qty":
                return Specification.DataType.Qty;

            case "int":
                return Specification.DataType.Int;

            case "String":
                return Specification.DataType.String;

            case "LocalMktDate":
                return Specification.DataType.LocalMktDate;

            case "MonthYear":
                return Specification.DataType.MonthYear;

            case "UTCTimestamp":
                return Specification.DataType.UtcTimestamp;

            case "MultipleCharValue":
                return Specification.DataType.MultipleValueString;

            default:
                throw new Exception($"Unknown ILink3 Fix type: {type}");
        }
    }

    /// <summary>
    ///  Normalize enum values 
    /// </summary>
    public static Specification.Enums EnumsFor(string name, string type, messageSchema xml)
    {
        var enums = new Specification.Enums();

        // first try name, then try type
        var @enum = (xml.types?.@enum.FirstOrDefault(@enum => @enum.name == name))
                 ?? (xml.types?.@enum.FirstOrDefault(@enum => @enum.name == type));

        if (@enum != null)
        {
            foreach (var value in @enum.validValue)
            {
                var current = new Specification.Enum
                {
                    Name = EnumNameFor(value),
                    Value = EnumValueFor(value),
                    Description = value.description
                };

                enums.Add(current);
            }
        }

        return enums;
    }

    /// <summary>
    ///  Parse value element for enum value name
    /// </summary>
    public static string EnumNameFor(typesEnumValidValue value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value.description);

        if (value.name == "False")
        {
            return "False";
        }
        if (value.name == "True")
        {
            return "True";
        }

        return Format.Name(value.description);
    }

    /// <summary>
    ///  Parse value element for enum value
    /// </summary>
    public static string EnumValueFor(typesEnumValidValue value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value.Value);

        return value.Value;
    }

    //
}