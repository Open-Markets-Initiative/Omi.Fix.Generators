namespace Omi.Fix.Types;

#pragma warning disable CS8618

/// <summary>
///  Load fixml field elements into generated object classes
/// </summary>
public static class Load
{
    /// <summary>
    ///  Load fields xml from file path
    /// </summary>
    public static Omi.Fix.Types.Xml.FixFields FieldsXmlFrom(string xml)
        => Fix.Load.From<Xml.FixFields>(xml);

    /// <summary>
    ///  Load fix types from file path
    /// </summary>
    public static Omi.Fix.Types.Xml.FixTypes TypesXmlFrom(string xml)
        => Fix.Load.From<Xml.FixTypes>(xml);
}