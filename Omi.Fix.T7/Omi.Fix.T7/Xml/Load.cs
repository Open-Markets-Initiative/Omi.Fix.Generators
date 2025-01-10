namespace Omi.Fix.T7.Xml;
    using System;
    using System.Collections.Generic;
    using System.Xml.Serialization;
    using System.Xml;
    using System.Text.RegularExpressions;

/// <summary>
///  Load T7 xml elements into generated object classes
/// </summary>

public static class Load
{
    /// <summary>
    ///  Load T7 xml file
    /// </summary>
    public static Model T7XmlFrom(string xml)
        => Load.From<Model>(xml);

    /// <summary>
    ///  Load fix specification document from T7 xml path
    /// </summary>
    public static Specification.Document From(string xml)
    {
        var model = T7XmlFrom(xml);

        return From(model);
    }

    /// <summary>
    ///  Load intermediate FIX representation from Eti xml
    /// </summary>
    public static Specification.Document From(Model model)
        => new ()
        {
            Information = new Specification.Information(),
            Header = new Specification.Header(),
            Trailer = new Specification.Trailer(),
            Messages = MessagesFrom(model),
            Components = new Specification.Components(),
            Types = TypesFrom(model)
        };

    /// <summary>
    ///  Load intermediate FIX message from Eti xml
    /// </summary>
    public static Specification.Messages MessagesFrom(Model xml)
    {
        var messages = new Specification.Messages();

        foreach (var message in xml.Structures.Where(structure => structure.type.Equals("Message")))
        {
            messages.Add(new Specification.Message
            {
                Name = message.name,
                Type = message.numericID.ToString(),
                Category = CategoryFrom(message),
                Fields = FieldsFrom(message),         
            });
        }

        return messages;
    }

    /// <summary>
    ///  Parse message for message category
    /// </summary>
    public static string CategoryFrom(ModelStructure message)
    {
        if (message.numericID < 10100 || message.numericID >= 10900) 
        {
            return "admin";
        }

        return "app"; // make intermediate versions of these?
    }

    /// <summary>
    ///  Load fields 
    /// </summary>
    public static List<Specification.Field> FieldsFrom(ModelStructure message)
    {
        var fields = new List<Specification.Field>();

        foreach (var field in message.Member ?? [])
        {
            var current = new Specification.Field
            {
                Name = field.name,
                Required = false
                // need kind?
            };

            fields.Add(current);
        }

        return fields;
    }

    /// <summary>
    ///  Obtain Specification types from T7 DataTypes
    /// </summary>
    public static Specification.Types TypesFrom(Model model)
    {
        var types = new Specification.Types();

        foreach (var type in model.DataTypes ?? [])
        {
            var current = new Specification.Type
            {
                Name = type.name,
                Tag = type.numericID,
                Description = type.description,
                Underlying = type.type, 
            };

            if (type.ValidValue != null && type.ValidValue.Length > 0)
            {
                var enums = new Specification.Enums();

                foreach (var value in type.ValidValue)
                {
                    enums.Add(new Specification.Enum { 
                        Name = value.name,
                        Value = value.value,
                        Description = ProcessDescription(value, enums)
                    });
                }

                current.Enums = enums;
            }

            types.Add(type.name, current);
        }

        return types;
    }

    /// <summary>
    ///  Process the original description
    /// </summary>
    public static string ProcessDescription(ModelDataTypeValidValue value, Specification.Enums enums)
    {
        var description = value.description;

        if(description == string.Empty || description.Length > 35 || enums.Any(e => e.Description == description))
        {
            description = value.name;
        }

        string result = description.Replace("-", " ").Replace("_", " ").Replace(".", " ").Replace("/", " or ");

        result = Regex.Replace(result, @"\([^)]*\)", string.Empty).Trim();

        return result;
    }

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
}