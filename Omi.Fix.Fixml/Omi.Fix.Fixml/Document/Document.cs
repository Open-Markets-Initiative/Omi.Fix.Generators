﻿namespace Omi.Fixml;
    using System.IO;

/// <summary>
///  Financial Information eXchange FIXML C# Document Object Model
/// </summary>

public class Document
{
    /// <summary>
    ///  FIXML document information
    /// </summary>
    public Information Information = new();

    /// <summary>
    ///  FIXML header fields
    /// </summary>
    public Header Header = new();

    /// <summary>
    /// Fixml Trailer Fields
    /// </summary>
    public Trailer Trailer = new();

    /// <summary>
    /// FIXML messages
    /// </summary>
    public Messages Messages = new();

    /// <summary>
    /// FIXML components
    /// </summary>
    public Components Components = new();

    /// <summary>
    /// FIXML Fields
    /// </summary>
    public Fields Fields = new();

    /// <summary>
    /// FIXML Errors
    /// </summary>
    public List<string> Errors
    {
        get
        {
            var errors = new List<string>();

            Information.Error(Fields, Components, errors);
            Header.Error(Fields, Components, errors);
            Trailer.Error(Fields, Components, errors);

            // verify that all elements in Messages
            foreach (var message in Messages)
            {
                message.Error(Fields, Components, errors, Messages);
            }

            return errors;
        }
    }

    /// <summary>
    ///  Apply filter (predicate) to messages and normalize
    /// </summary>
    public Document Filter(Predicate<Message> predicate)
    {
        // Filter messages
        Messages.RemoveAll(message => !predicate(message));

        // Reduce to included messages
        var msgtypes = Messages.Types();
        Fields.ReduceMsgTypesto(msgtypes);

        // Reduce to included components
        var components = GatherComponents();
        Components.ReduceTo(components);

        // Reduce to included fields
        var fields = GatherFields();
        Fields.ReduceTo(fields);

        return this;
    }

    /// <summary>
    ///  Gather set of included component identifiers in in FIXML document
    /// </summary>
    public HashSet<string> GatherComponents()
    {
        var set = new HashSet<string>();

        // Gather included components in header
        foreach (var element in Header.Elements)
        {
            Gather.ComponentsIn(element, Components, set);
        }

        // Gather included components in trailer
        foreach (var element in Trailer.Elements)
        {
            Gather.ComponentsIn(element, Components, set);
        }

        // Gather included components in messages
        foreach (var message in Messages)
        {
            foreach (var element in message.Elements)
            {
                Gather.ComponentsIn(element, Components, set);
            }
        }

        return set;
    }

    /// <summary>
    ///  Gather set of included field identifiers in FIXML document
    /// </summary>
    public HashSet<string> GatherFields()
    {
        var set = new HashSet<string>();

        // Gather included fields in header
        foreach (var header in Header.Elements)
        {
            Gather.FieldsIn(header, Components, set);
        }

        // Gather included fields in trailer
        foreach (var trailer in Trailer.Elements)
        {
            Gather.FieldsIn(trailer, Components, set);
        }

        // Gather included fields in messages
        foreach (var message in Messages)
        {
            foreach (var element in message.Elements)
            {
                Gather.FieldsIn(element, Components, set);
            }
        }

        return set;
    }

    /// <summary>
    ///  Convert fixml document from specification document
    /// </summary>
    public static Document From(Fix.Specification.Document specification)
      => new()
      {
          Information = Information.From(specification.Information),
          Header = Header.From(specification.Header),
          Trailer = Trailer.From(specification.Trailer),
          Messages = Messages.From(specification.Messages),
          Components = Components.From(specification.Components),
          Fields = Fields.From(specification.Types),
      };

    /// <summary>
    ///  Load FIXML document from XML file 
    /// </summary>
    public static Document From(Xml.fix xml)
        => new()
        {
            Information = Information.From(xml),
            Header = Header.From(xml),
            Trailer = Trailer.From(xml),
            Messages = Messages.From(xml),
            Components = Components.From(xml),
            Fields = Fields.From(xml)
        };

    /// <summary>
    ///  Load FIXML file from path 
    /// </summary>
    public static Document From(string path)
    {
        var xml = Load.From(path);

        return From(xml);
    }

    /// <summary>
    ///  Write fixml file to stream
    /// </summary>
    public void WriteTo(StreamWriter stream)
        => WriteTo(stream, new Indent { });

    /// <summary>
    ///  Write fixml file to stream
    /// </summary>
    public void WriteTo(StreamWriter stream, Indent indent)
    {
        Information.Write(stream);
        Header.Write(stream, indent);
        Trailer.Write(stream, indent);
        Messages.Write(stream, indent);
        Components.Write(stream, indent);
        Fields.Write(stream, indent);

        stream.WriteLine("</fix>");
    }

    /// <summary>
    ///  Write fixml to path
    /// </summary>
    public string WriteTo(string path)
    {
        using var file = File.Create(path);
        using var stream = new StreamWriter(file);

        WriteTo(stream);

        return file.Name;
    }

    /// <summary>
    ///  Convert fixml to normalized fix specification
    /// </summary>
    public Fix.Specification.Document ToSpecification()
        => new()
        {
            Information = Information.ToSpecification(),
            Header = Header.ToSpecification(),
            Trailer = Trailer.ToSpecification(),
            Messages = Messages.ToSpecification(),
            Components = Components.ToSpecification(),
            Types = Fields.ToSpecification(),
        };

    /// <summary>
    ///  Verify fixml
    /// </summary>
    public void Verify()
    {
        // fixmls require version information
        if (string.IsNullOrWhiteSpace(Information.Major))
        {
            throw new Exception("Missing Information");
        }

        // verify that all elements in messages
        foreach (var message in Messages)
        {
            message.Verify(Fields, Components);
        }
    }

    /// <summary>
    ///  FIXML as string
    /// </summary>
    public override string ToString()
        => $"{Information} Fixml";
}