namespace Omi.Fixml;

public partial class Is
{

    /// <summary>
    ///  Only include admin messages
    /// </summary>
    public static bool Admin(Omi.Fixml.Message message)
        => message.Category == "admin";
}
