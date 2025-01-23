namespace Omi.Fix.Sbe.iLink3;
using System;
using System.Collections.Generic;

/// <summary>
///  Load iLink3 SBE XML into OMI FIX intermediate specification 
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
            Types = FieldsFrom(schema)
        };

    /// <summary>
    ///  Obtain sbe fix message from xml
    /// </summary>
    public static Specification.Messages MessagesFrom(messageSchema xml)
    {
        var messages = new Specification.Messages();

        foreach (var message in xml.message ?? Array.Empty<messageSchemaMessage>())
        {
            messages.Add(new Specification.Message
            {
                Name = message.description, // make a method for this
                Type = message.id.ToString(),
                Category = CategoryFrom(message),
                Fields = FieldsFrom(message.field),
            });
        }

        return messages;
    }

    /// <summary>
    ///  Parse message for message category
    /// </summary>
    public static string CategoryFrom(messageSchemaMessage message)
    {
        if (message.id < 513)
        {
            return "admin";
        }

        return "app";
    }

    /// <summary>
    ///  Obtain Specification types from iLink fields
    /// </summary>
    public static List<Specification.Field> FieldsFrom(field[] fields)
    {
        var result = new List<Specification.Field>();

        foreach (var field in fields ?? [])
        {
            if (field != null && field.offsetSpecified)
            {
                result.Add(new Specification.Field
                {
                    Name = field.name
                });
            }
        }

        return result;
    }

    /// <summary>
    ///  Load fields from file
    /// </summary>
    public static Specification.Types FieldsFrom(messageSchema xml)
    {
        var fields = new Specification.Types();
        var ids = new HashSet<int>();

        // Pull fields from messages
        foreach (var message in xml.message ?? Array.Empty<messageSchemaMessage>())
        {
            foreach (var field in message.field ?? [])
            {
                if (!ids.Contains(field.id))
                {
                    ids.Add(field.id);
                    fields.Add(field.name, new Specification.Type
                    {
                        Name = field.name,
                        Tag = field.id,
                        Description = field.description,
                        Underlying = field.semanticType,
                    });

                }

                // Repeating group fields  
                if (message.group != null)
                {
                    foreach (var group in message.group ?? Array.Empty<group>())
                    {
                        if (!ids.Contains(group.id))
                        {
                            ids.Add(group.id);
                            fields.Add(group.name, new Specification.Type
                            {
                                Name = group.name,
                                Tag = group.id,
                                Description = group.description,
                                Underlying = group.dimensionType,
                            });
                        }

                        foreach (var subfield in group.field ?? Array.Empty<groupField>())
                        {
                            if (!ids.Contains(subfield.id))
                            {
                                ids.Add(subfield.id);
                                fields.Add(subfield.name, new Specification.Type
                                {
                                    Name = subfield.name,
                                    Tag = subfield.id,
                                    Description = subfield.description,
                                    Underlying = subfield.semanticType,
                                }); ;
                            }
                        }
                    }
                }
            }
        }

        return fields;
    }
}