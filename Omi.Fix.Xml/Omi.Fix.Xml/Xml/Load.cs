namespace Omi.Fix.Xml;
    using System.IO;
    using System.Xml;
    using System.Xml.Serialization;

/// <summary>
///  Load xml elements into generated object classes
/// </summary>

public static class Load
{
    /// <summary>
    ///  Load classes from file path
    /// </summary>
    public static T From<T>(string xml)
    {
        using var reader = XmlReader.Create(xml);

        var serializer = XmlSerializer.FromTypes([typeof(T)])[0];
        if (serializer == null)
        {
            throw new Exception();
        }

        var classes = serializer.Deserialize(reader);
        if (classes == null)
        {
            throw new Exception();
        }

        return (T)classes;
    }

    /// <summary>
    ///  Load classes from file info
    /// </summary>
    public static T From<T>(FileInfo info)
    {
        using var reader = info.OpenRead();

        var serializer = XmlSerializer.FromTypes([typeof(T)])[0];
        if (serializer == null)
        {
            throw new Exception();
        }

        var classes = serializer.Deserialize(reader);
        if (classes == null)
        {
            throw new Exception();
        }

        return (T)classes;
    }

    /// <summary>
    ///  Load fixml xml into classes from file path
    /// </summary>
    public static Xml.fix From(string xml)
        => From<Xml.fix>(xml);
}