namespace Omi.Fix.Sbe.iLink3;

using System.Collections.Generic;

/// <summary>
///  Normalize iLink3 Sbe Xml into Omi Fix intermediate specification 
/// </summary>

public static class Messages
{
    /// <summary>
    ///  Normalize messages in Sbe Xml
    /// </summary>
    public static Specification.Messages From(messageSchema xml)
    {
        var messages = new Specification.Messages();

        foreach (var message in xml.message ?? [])
        {
            var current = MessageFrom(message);

            messages.Add(current);
        }

        return messages;
    }

    /// <summary>
    ///  Convert iLink3 Sbe to Fix intermediate message
    /// </summary>
    public static Specification.Message MessageFrom(messageSchemaMessage message)
        => new()
        {
            Name = NameFor(message),
            Type = TypeFor(message),
            Category = CategoryFor(message),
            Fields = FieldsFor(message.field),
        };

    /// <summary>
    ///  Parse message element for message name
    /// </summary>
    public static string NameFor(messageSchemaMessage message)
    {
        // verify

        return message.description;
    }

    /// <summary>
    ///  Parse message element for message type
    /// </summary>
    public static string TypeFor(messageSchemaMessage message)
    {
        // verify

        return message.id.ToString();
    }

    /// <summary>
    ///  Parse message for message category
    /// </summary>
    public static string CategoryFor(messageSchemaMessage message)
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
    public static List<Specification.Field> FieldsFor(field[] fields)
    {
        var result = new List<Specification.Field>();

        foreach (var field in fields ?? [])
        {
            if (field != null && field.offsetSpecified)
            {
                var current = new Specification.Field
                {
                    Name = field.name
                };

                result.Add(current);
            }
        }

        // what about groups?

        return result;
    }
}