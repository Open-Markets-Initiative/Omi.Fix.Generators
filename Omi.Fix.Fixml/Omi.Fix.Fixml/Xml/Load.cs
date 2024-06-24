namespace Omi.Fixml;

/// <summary>
///  Load fixml elements into generated object classes
/// </summary>

public static class Load
{

    /// <summary>
    ///  Load fixml xml into classes from file path
    /// </summary>
    public static Xml.fix From(string xml)
        => Fix.Load.From<Xml.fix>(xml);
}