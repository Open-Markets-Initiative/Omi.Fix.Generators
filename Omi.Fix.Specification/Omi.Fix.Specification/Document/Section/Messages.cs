namespace Omi.Fix.Specification;

/// <summary>
///  Normalized FIX specification messages list
/// </summary>

public class Messages : List<Message>
{
    /// <summary>
    ///  Get message by name
    /// </summary>
    public bool TryGetByName(string name, out Message message) {
        foreach( var current in this)
        {
            if (current.Name == name)
            {
                message = current;

                return true;
            }
        }

        message = new();

        return false;
    }
}