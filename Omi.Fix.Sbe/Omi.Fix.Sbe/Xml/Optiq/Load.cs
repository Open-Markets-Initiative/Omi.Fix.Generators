namespace Omi.Fix.Sbe.Optiq;

/// <summary>
///  Load Optiq Sbe Xml into Omi Fix intermediate specification 
/// </summary>

public static class Load
{
    /// <summary>
    ///  Load sbe xml file
    /// </summary>
    public static messageSchema XmlFrom(string xml)
        => Xml.Load.From<messageSchema>(xml);

    /// <summary>
    ///  Load Omi Fix intermediate specification from sbe xml path
    /// </summary>
    public static Specification.Document From(string xml)
    {
        var schema = XmlFrom(xml);

        return From(schema);
    }

    /// <summary>
    ///  Load Omi Fix intermediate document from sbe xml
    /// </summary>
    public static Specification.Document From(messageSchema schema)
        => new ()
        {
            Information = new Specification.Information(),
            Messages = Messages.From(schema),
            Types = Types.From(schema)
        };
}