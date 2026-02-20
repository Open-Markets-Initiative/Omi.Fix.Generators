namespace Omi.Fix.Sbe.Optiq;
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
            messages.Add(MessageFrom(message));
        }

        return messages;
    }

    /// <summary>
    ///  Convert Optiq Sbe to Fix intermediate message
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
    ///  Parse message name
    /// </summary>
    public static string NameFor(messageSchemaMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);
        ArgumentException.ThrowIfNullOrWhiteSpace(message.name);

        return Format.UpperFirstLetter(message.name);
    }

    /// <summary>
    ///  Parse message name
    /// </summary>
    public static string TypeFor(messageSchemaMessage message)
    {
        ArgumentNullException.ThrowIfNull(message);

        return message.id.ToString();
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
}