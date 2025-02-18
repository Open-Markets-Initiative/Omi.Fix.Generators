namespace Omi.Fix.Types;

using System.Collections.Generic;
using System.Xml;

/// <summary>
///  Fix Fields Xml Element (Fields Section)
/// </summary>

public class Types : Dictionary<string, Type>
{

    /// <summary>
    ///  Load fix field types from fields xml
    /// </summary>
    public static Types From(Xml.FixFields xml)
    {
        var fields = new Types();

        foreach (var element in xml.FixFieldSpec)
        {
            var field = Type.From(element);
            fields[field.Name] = field;
        }

        return fields;
    }

    /// <summary>
    ///  Load fix field types from types xml
    /// </summary>
    public static Types From(Xml.FixTypes xml)
    {
        var fields = new Types();

        foreach (var element in xml.FixType)
        {
            var field = Type.From(element);
            fields[field.Name] = field;
        }

        return fields;
    }

    /// <summary>
    ///  Load fix field types from xml
    /// </summary>
    public static Types From(Fix.Specification.Types types)
    {
        var fields = new Types();

        foreach (var element in types.Values)
        {
            var field = Type.From(element);
            fields[field.Name] = field;
        }

        return fields;
    }

    /// <summary>
    ///  Convert fix field declarations to normalized fix specification types
    /// </summary>
    public Fix.Specification.Types ToSpecification()
    {
        var types = new Fix.Specification.Types();

        var fields = this.Select(f => f.Value).ToList();

        foreach (var field in fields)
        {
            types.Add(field.Name, field.ToSpecification());
        }

        return types;
    }

    /// <summary>
    /// Write fields to XML
    /// </summary>
    public void ToXml(XmlDocument document) 
    {
        var root = document.CreateElement("FixTypes");
        document.AppendChild(root);

        foreach (var type in Values) 
        {
            type.ToXml(document, root);
        }
    }
}