namespace Omi.Fix.Sbe.Optiq;

/// <summary>
///  Normalize Optiq Sbe Xml into Omi Fix intermediate specification types
/// </summary>

public static class Types
{
    /// <summary>
    ///  Normalize Optiq Sbe types
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
    ///  Gather Optiq types in Sbe message element 
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
    ///  Convert message field to normalized Fix intermediate type
    /// </summary>
    public static void Process(field field, messageSchema xml, Specification.Types types)
    {
        // should verify field values
        var name = NameFor(field);

        if (types.ContainsKey(name)) { return; }

        var type = new Specification.Type ()
        {
            Name = name,
            Tag = field.id, // need to generate these
            Description = field.name,
            Underlying = field.type,
            Enums = EnumsFor(field.type, xml)
        };

        types.Add(type);
    }

    /// <summary>
    ///  Parse field element for field name
    /// </summary>
    public static string NameFor(field field)
    {
        // verify

        return Format.UpperFirstLetter(field.name);
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
            Description = name,
            Underlying = group.dimensionType
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
        // should verify field values
        var name = NameFor(field);

        if (types.ContainsKey(name)) { return; }

        var type = new Specification.Type()
        {
            Name = name,
            Tag = field.id,
            Description = field.name,
            Underlying = field.type,
            Enums = EnumsFor(field.type, xml)
        };

        types.Add(type);
    }

    /// <summary>
    ///  Parse field element for field name
    /// </summary>
    public static string NameFor(groupField field)
    {
        // verify

        return field.name;
    }

    /// <summary>
    ///  Norm
    /// </summary>
    public static Specification.Enums EnumsFor(string type, messageSchema xml)
    {
        var enums = new Specification.Enums();

        var @enum = xml.types?.@enum.FirstOrDefault(@enum => @enum.name == type);

        if (@enum != null)
        {
            foreach (var value in @enum.validValue)
            {
                var current = new Specification.Enum
                {
                    Name = value.name,
                    Value = value.Value,
                    Description = value.name,
                };

                enums.Add(current);
            }
        }

        return enums;
    }
}