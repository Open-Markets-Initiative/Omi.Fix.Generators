namespace Omi.Fix.Specification;

/// <summary>
///  Normalized Fix intermedaite specification message types dictionary
/// </summary>

public class MessageTypes : Dictionary<string, MessageType>
{
    /// <summary>
    ///  Add types 
    /// </summary>
    public void Add(Specification.Document specification)
    {
        foreach (var message in specification.Messages)
        {
            Add(message);
        }
    }

    /// <summary>
    ///  Add/Overwrite type
    /// </summary>
    public void Add(Message message, string category = "")
    {
        this[message.Type] = new MessageType()
        {
            Type = message.Type,
            Name = message.Name,
            Category = category
        };
    }

    /*

    /// <summary>
    ///  Convert Dictionary of types to Specification
    /// </summary>
    public static Types ToTypes(Dictionary<string, Type> type)
    {
        var types = new Types();

        foreach (var pair in type)
        {
            types.Add(pair.Key, pair.Value);
        }

        return types;
    }
*/
    /// <summary>
    ///  Return types as ordered list
    /// </summary>
    public List<MessageType> ToList()
        => Values.OrderBy(field => field.Name).ToList();
}