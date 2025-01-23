namespace Omi.Fix.Sbe.Optiq;
using System.Collections.Generic;

/// <summary>
///  Load Optiq SBE XML into OMI FIX intermediate specification 
/// </summary>

public static class Load
{
    /// <summary>
    ///  Load sbe xml file
    /// </summary>
    public static messageSchema XmlFrom(string xml)
        => Xml.Load.From<messageSchema>(xml);

    /// <summary>
    ///  Load fix specification document from sbe xml path
    /// </summary>
    public static Specification.Document From(string xml)
    {
        var schema = XmlFrom(xml);

        return From(schema);
    }

    /// <summary>
    ///  Load fix specification document from sbe xml
    /// </summary>
    public static Specification.Document From(messageSchema schema)
        => new ()
        {
            Information = new Specification.Information(),
            Header = new Specification.Header(),
            Trailer = new Specification.Trailer(),
            Messages = MessagesFrom(schema),
            Components = new Specification.Components(),
            Types = TypesFrom(schema)
        };

    /// <summary>
    ///  Obtain sbe fix message from xml
    /// </summary>
    public static Specification.Messages MessagesFrom(messageSchema xml)
    {
        var messages = new Specification.Messages();

        foreach (var message in xml.message ?? [])
        {
            messages.Add(From(message));
        }

        return messages;
    }

    /// <summary>
    ///  Parse message name
    /// </summary>
    public static Specification.Message From(messageSchemaMessage message)
        => new()
        {
            Name = NameFor(message),
            Type = message.id.ToString(),
            Category = CategoryFor(message),
            Fields = FieldsFor(message.field)
        };

    /// <summary>
    ///  Parse message name
    /// </summary>
    public static string NameFor(messageSchemaMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentException.ThrowIfNullOrWhiteSpace(message.name);

        return Format.UpperFirstLetter(message.name);
    }

    /// <summary>
    ///  Parse message for message category
    /// </summary>
    public static string CategoryFor(messageSchemaMessage message) 
    {
        // check negative?

        if (message.id > 100)
        {
            return "admin";
        }

        return "app";
    }

    /// <summary>
    ///  Obtain Specification types from iLink fields
    /// </summary>
    public static List<Specification.Field> FieldsFor(field[] fields)
    {
        var result = new List<Specification.Field>();

        foreach (var field in fields ?? [])
        {
            result.Add(new Specification.Field
            {
                Name = Format.UpperFirstLetter(field.name)
                //Required = p use presecence

            });
        }

        return result;
    }

    /// <summary>
    ///  Gather Optiq SBE FIX types
    /// </summary>
    public static Specification.Types TypesFrom(messageSchema xml)
    {
        var fields = new Specification.Types();
        var names = new HashSet<string>();

        foreach (var message in xml.message ?? [])
        {
            // Message fields
            foreach (var field in message.field ?? [])
            {
                var name = Format.UpperFirstLetter(field.name);

                if (names.Contains(name)) { continue; }

                names.Add(name);
                fields.Add(name, new Specification.Type
                {
                    Name = name,
                    Tag = field.id, // need to generate these
                    Description = field.name,
                    Underlying = field.type,
                });
            }

            // Repeating groups and fields  
            foreach (var group in message.group ?? [])
            {
                var name = Format.UpperFirstLetter(group.name);

                if (!names.Contains(name))
                {
                    names.Add(name);
                    fields.Add(name, new Specification.Type
                    {
                        Name = name,
                        Tag = group.id,
                        Description = name,
                        Underlying = group.dimensionType,
                    });
                }

                foreach (var type in group.field ?? [])
                {
                    var current = Format.UpperFirstLetter(type.name);

                    if (names.Contains(current)) { continue; }

                    names.Add(current);
                    fields.Add(current, new Specification.Type
                    {
                        Name = current,
                        Tag = type.id,
                        Description = type.name,
                        Underlying = type.type,
                    });
                }
            }
        }

        return fields;
    }
}