namespace Omi.Fix.Sbe.iLink3;

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
    ///  Convert message field to normalized Fix intermediate type
    /// </summary>
    public static void Process(field field, messageSchema xml, Specification.Types types)
    {
        // should verify field values
        var name = NameFor(field);

        if (types.ContainsKey(name)) { return; }

        var type = new Specification.Type ()
        {
            Name = NameFor(field),
            Tag = field.id,
            Description = field.description,
            Underlying = field.semanticType,
            Enums = EnumsFor(field.name, xml)
        };

        types.Add(type);
    }

    /// <summary>
    ///  Parse field element for field name
    /// </summary>
    public static string NameFor(field field)
    {
        // verify

        return field.name;
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
            Name = NameFor(field),
            Tag = field.id,
            Description = field.description,
            Underlying = field.semanticType,
            Enums = EnumsFor(field.name, xml)
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
    public static Specification.Enums EnumsFor(string name, messageSchema xml)
    {
        var enums = new Specification.Enums();

        var @enum = xml.types?.@enum.FirstOrDefault(@enum => @enum.name == name);

        if (@enum != null)
        {
            foreach (var value in @enum.validValue)
            {
                var current = new Specification.Enum
                {
                    Name = value.name,
                    Value = value.Value,
                    Description = value.description
                };

                enums.Add(current);
            }
        }

        return enums;
    }
}