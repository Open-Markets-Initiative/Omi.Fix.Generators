using System.Xml;

namespace Omi.Fix.Xml;

/// <summary>
///  List of fixml messsages
/// </summary>

public class Messages : List<Message>
{
    /// <summary>
    ///  Default constructor
    /// </summary>
    public Messages(){ }

    /// <summary>
    ///  Construct messages from IEnumerable
    /// </summary>
    public Messages(IEnumerable<Message> messages)
    {
        AddRange(messages);
    }

    /// <summary>
    ///  Errors in the Messages
    /// </summary>
    public List<string> Errors = new List<string>();

    /// <summary>
    ///  Gather messages from fixml xml
    /// </summary>
    public static Messages From(Xml.fix xml)
        => new(ListFrom(xml).Select(Message.From));

    /// <summary>
    ///  Gather message xml elements from fixml
    /// </summary>
    public static Xml.fixMessage[] ListFrom(Xml.fix xml)
        => xml.messages ?? [];

    /// <summary>
    ///  Gather msgtypes
    /// </summary>
    public HashSet<string> Types() 
    {
        var msgtypes = new HashSet<string>();

        foreach (var message in this)
        {
            msgtypes.Add(message.Type);
        }

        return msgtypes;
    }

    /// <summary>
    ///  Gather fixml components list from normalized fix specification 
    /// </summary>
    public static Messages From(Fix.Specification.Messages messages)
        => new Messages(messages.Select(Message.From));


    /// <summary>
    ///  Append as XML element
    /// </summary>
    public void ToXml(XmlDocument document)
    {
        var root = document.FirstChild;

        if (root != null)
        {
            var element = document.CreateElement("messages");
            root.AppendChild(element);

            foreach (var message in this)
            {
                message.ToXml(document, element);
            }
        }
    }

    /// <summary>
    ///  Convert fixml messages list to normalized fix specification message
    /// </summary>
    public Fix.Specification.Messages ToSpecification()
    {
        var messages = new Fix.Specification.Messages();

        foreach (var message in this)
        {
            messages.Add(message.ToSpecification());
        }

        return messages;
    }
}