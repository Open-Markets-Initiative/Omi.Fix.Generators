namespace Omi.Fix.Xml;

public partial class Is
{

    /// <summary>
    ///  Only include admin messages
    /// </summary>
    public static bool Admin(Omi.Fix.Xml.Message message)
        => message.Category == "admin";
}
