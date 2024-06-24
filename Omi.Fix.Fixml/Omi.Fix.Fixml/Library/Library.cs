﻿namespace Omi.Fixml;

/// <summary>
///  Fixml File Library
/// </summary>

public static class Library
{

    // Todo: universal seperators

    /// <summary>
    ///  Standard Fix 4.2 fixml
    /// </summary>
    public static Document Fix42
        => Load("Fix.v4.2.xml");

    /// <summary>
    ///  Standard Fix 4.2 fixml admin messages only
    /// </summary>
    public static Document Fix42Admin
        => Load("Fix.v4.2.xml").Filter(Is.Admin);

    /// <summary>
    ///  Standard Fix 4.4 fixml
    /// </summary>
    public static Document Fix44
        => Load("Fix.v4.4.xml");

    /// <summary>
    ///  Standard Fix 4.4 fixml admin messages only
    /// </summary>
    public static Document Fix44Admin
        => Load("Fix.v4.4.xml").Filter(Is.Admin);

    /// <summary>
    ///  Standard Fix 5.0.SP2 fixml
    /// </summary>
    public static Document Fix50
        => Load("Fix.v5.0.sp2.xml");

    /// <summary>
    ///  Load Library file into Fixml Document
    /// </summary>
    public static Document Load(string file)
        => Document.From($"Library\\Fixml\\{file}"); // need general seperator

    /// <summary>
    ///  Gather Fixml files in library
    /// </summary>
    public static string[] Files()
    {
        var directory = Path.Combine(Directory.GetCurrentDirectory(), "Library\\Fixml");

        return Directory.GetFiles(directory, "*.xml");
    }

    /// <summary>
    ///  Gather library fixmls in object classes
    /// </summary>
    public static List<Xml.fix> Xmls()
    {
        var files = Files();

        var xmls = new List<Xml.fix>();

        foreach (var file in files ?? Array.Empty<string>())
        {
            xmls.Add(Fixml.Load.From(file));
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