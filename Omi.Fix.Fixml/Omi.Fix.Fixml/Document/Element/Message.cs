namespace Omi.Fixml;
    using System.Linq;
using System.Xml;

/// <summary>
///  Fixml Message
/// </summary>

public class Message : IParent
{

    /// <summary>
    ///  Fixml message name
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    ///  Fixml message type
    /// </summary>
    public string Type = string.Empty;

    /// <summary>
    ///  Fixml message category
    /// </summary>
    public string Category = string.Empty;

    /// <summary>
    ///  Fixml message child elements list (fields, groups, components)
    /// </summary>
    public Elements Elements { get; set; } = new Elements();

    /// <summary>
    ///  Convert xml element to fixml message 
    /// </summary>
    public static Message From(Xml.fixMessage element)
    {
        var message = new Message()
        {
            Name = element.name,
            Type = element.msgtype,
            Category = element.msgcat,
        };

        message.Elements = Elements.From(element.Items, message); // need ??

        return message;
    }

    /// <summary>
    ///  Convert normalized specification messages to fixml messages 
    /// </summary>
    public static Message From(Fix.Specification.Message element)
    {
        var message = new Message()
        {
            Name = element.Name,
            Type = element.Type,
            Category = element.Category,
        };

        message.Elements = Elements.From(element.Fields, message);

        return message;
    }

    /// <summary>
    /// Appends XmlElement from Message to parent
    /// </summary>
    public void GenerateXml(XmlDocument doc,XmlElement parent) 
        {
        var messageElement = doc.CreateElement("message");

        //Append name attribute to messageElement
        var nameAtr = doc.CreateAttribute("name");
        nameAtr.Value = Name;
        messageElement.Attributes.Append(nameAtr);

        //Append message type attribute to messageElement
        var msgtypeAtr = doc.CreateAttribute("msgtype");
        msgtypeAtr.Value = Type;
        messageElement.Attributes.Append(msgtypeAtr);

        //Appends message category to messageElement
        var msgcatAtr = doc.CreateAttribute("msgcat");
        msgcatAtr.Value = Category;
        messageElement.Attributes.Append(msgcatAtr);

        parent.AppendChild(messageElement);

        //Append XmlElements from Elements to messageElement
        Elements.GenerateXml(doc, messageElement);
    }

    /// <summary>
    ///  Does message have fields?
    /// </summary>
    public bool HasFields
        => Elements.Any();

    /// <summary>
    ///  Convert to normalized fix specification message
    /// </summary>
    public Fix.Specification.Message ToSpecification()
        => new()
        {
            Type = Type,
            Name = Name,
            Category = Category,
            Fields = Elements.ToSpecification()
        };

    /// <summary>
    ///  Verify fixml message properties
    /// </summary>
    public void Verify(Fields fields, Components components)
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new Exception("Message name is missing");
        }

        if (string.IsNullOrWhiteSpace(Type))
        {
            throw new Exception("Message type is missing");
        }

        Elements.Verify(fields, components);
    }

    /// <summary>
    ///  Report erroneous fixml message properties
    /// </summary>
    public void Error(Fields fields, Components components, List<string> Errors, Messages Messages)
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            Errors.Add("Message name is missing");

            Messages.Errors.Add("Message name is missing");
        }

        if (string.IsNullOrWhiteSpace(Type))
        {
            Errors.Add("Message type is missing");

            Messages.Errors.Add("Message type is missing");
        }

        var repeats = Elements.GroupBy(x => x.Name)
          .Where(g => g.Count() > 1)
          .Select(y => y.Key)
          .ToList();

        if (repeats.Any())
        {
            foreach (var repeat in repeats)
            {
                Errors.Add($"{repeat} : Tag occurs more than once in message");

                Messages.Errors.Add($"{repeat} : Tag occurs more than once in message");
            }
        }

        Elements.Error(fields, components, Errors);
    }

    /// <summary>
    ///  Display fixml message as string
    /// </summary>
    public override string ToString() // need to update this for missing stuff
        => $"{Name}, {Type}, Fields: {Elements.Count}]";
}
