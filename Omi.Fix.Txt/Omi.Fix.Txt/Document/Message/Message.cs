namespace Omi.Fix.Txt;

using System.Linq;

/// <summary>
/// Types of FIX messages in text file
/// </summary>
public class Message
{
    /// <summary>
    ///  Fix txt message name
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    ///  Fix txt message type
    /// </summary>
    public string Type = string.Empty;

    public string Category = string.Empty;

    public Groups Elements = new Groups();

    /// <summary>
    /// Message contructor from properties
    /// </summary>
    public static Message From(string name, string type, string category, Groups elements)
        => new Message
        {
            Name = name,
            Type = type,
            Category = category,
            Elements = elements
        };

    /// <summary>
    /// Message contructor from string
    /// </summary>
    public static Message From(string line)
    {
        var message = new Message();

        // Check for validitry and trim line
        if (line.Contains("#"))
        {
            var cutString = line.Substring(0, line.IndexOf("#"));
            line = String.Concat(cutString.Where(c => !Char.IsWhiteSpace(c)));
        }

        // Split line by colon and obtain properties
        var msgarray = line.Split(':');

        var name = msgarray[0];
        var category = msgarray[1];
        var type = msgarray[2];
        var elements = Groups.From(msgarray[3]);

        return From(name, category, type, elements);
    }

    /// <summary>
    ///  Obtain Fix specification for message from text
    /// </summary>
    public Specification.Message ToSpecification()
        => new()
        {
            Name = Name,
            Type = Type,
            Category = Category,
            Fields = this.Elements.ToSpecification()
        };

    /// <summary>
    ///  Fix Txt message as string
    /// </summary>
    public override string ToString()
        => $"{Name} => {Type}, {Category}";
}