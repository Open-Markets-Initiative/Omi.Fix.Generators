﻿namespace Omi.Fix.Types;

/// <summary>
///  Fields Xml Library
/// </summary>

public static class Library
{

    /// <summary>
    ///  Standard Fix 4.2 fields
    /// </summary>
    public static Document Fix42
        => Document.From("Library\\Fields\\Fix42.Fields.xml");

    /// <summary>
    ///  Gather Fixml files in library
    /// </summary>
    public static string[] Files()
    {
        var directory = Path.Combine(Directory.GetCurrentDirectory(), "Library\\Fields");

        return Directory.GetFiles(directory, "*.xml");
    }

    /// <summary>
    ///  Gather library fixmls in object classes
    /// </summary>
    public static List<Xml.FixFields> Xmls()
    {
        var files = Files();

        var xmls = new List<Xml.FixFields>();

        foreach (var file in files ?? Array.Empty<string>())
        {
            xmls.Add(Load.FieldsXmlFrom(file));
        }

        return xmls;
    }

    /// <summary>
    ///  Gather normalized specifications for all xml files in library
    /// </summary>
    public static List<Fix.Specification.Document> Specifications()
    {
        var xmls = Xmls();

        var specifications = new List<Fix.Specification.Document>();

        foreach (var xml in xmls)
        {
            var fixml = Document.From(xml);
            specifications.Add(fixml.ToSpecification());
        }

        return specifications;
    }
}