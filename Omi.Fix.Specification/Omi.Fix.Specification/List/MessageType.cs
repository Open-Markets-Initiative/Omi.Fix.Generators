namespace Omi.Fix.Specification;

/// <summary>
///  List of Message Types
/// </summary>

public class MessageType
{
    /// <summary>
    ///  Fix Message MsgType Identifier
    /// </summary>
    public string Type = string.Empty;
    
    /// <summary>
    ///  Fix field type name
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    ///  Fix field type name
    /// </summary>
    public string Category = string.Empty;

    /// <summary>
    ///  Fix field type name
    /// </summary>
    public string Description = string.Empty;

    /// <summary>
    ///  Display intermediate MsgType
    /// </summary>
    /// <returns></returns>
    public override string ToString()
        => $"{Name}: {Type}";
}