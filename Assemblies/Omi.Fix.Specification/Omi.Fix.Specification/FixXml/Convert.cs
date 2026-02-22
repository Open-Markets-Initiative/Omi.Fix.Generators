namespace Omi.Fix.Specification.FixXml;

/// <summary>
///  Extension methods for converting between FIX XML and FIX intermediate types
/// </summary>

public static class Convert
{
    /// <summary>
    ///  Convert specification document to fixml document
    /// </summary>
    public static Omi.Fix.Xml.Document ToXml(this Document specification)
        => new()
        {
            Information = specification.Information.ToXml(),
            Header = specification.Header.ToXml(),
            Trailer = specification.Trailer.ToXml(),
            Messages = specification.Messages.ToXml(),
            Components = specification.Components.ToXml(),
            Fields = specification.Types.ToXml(),
        };

    /// <summary>
    ///  Convert specification information to fixml information
    /// </summary>
    public static Omi.Fix.Xml.Information ToXml(this Information information)
        => new()
        {
            Major = information.Major,
            Minor = information.Minor,
        };

    /// <summary>
    ///  Convert specification header to fixml header
    /// </summary>
    public static Omi.Fix.Xml.Header ToXml(this Header header)
    {
        var section = new Omi.Fix.Xml.Header();

        foreach (var element in header)
        {
            section.Elements.Add(element.ToXmlChild(section));
        }

        return section;
    }

    /// <summary>
    ///  Convert specification trailer to fixml trailer
    /// </summary>
    public static Omi.Fix.Xml.Trailer ToXml(this Trailer trailer)
    {
        var section = new Omi.Fix.Xml.Trailer();

        foreach (var field in trailer)
        {
            section.Elements.Add(new Omi.Fix.Xml.Child.Field
            {
                Parent = section,
                Name = field.Name,
                Required = field.Required,
            });
        }

        return section;
    }

    /// <summary>
    ///  Convert specification messages to fixml messages
    /// </summary>
    public static Omi.Fix.Xml.Messages ToXml(this Messages messages)
        => new(messages.Select(m => m.ToXml()));

    /// <summary>
    ///  Convert specification message to fixml message
    /// </summary>
    public static Omi.Fix.Xml.Message ToXml(this Message message)
    {
        var result = new Omi.Fix.Xml.Message
        {
            Name = message.Name,
            Type = message.Type,
            Category = message.Category,
        };

        result.Elements = message.Fields.ToXmlElements(result);

        return result;
    }

    /// <summary>
    ///  Convert specification components to fixml components
    /// </summary>
    public static Omi.Fix.Xml.Components ToXml(this Components components)
    {
        var section = new Omi.Fix.Xml.Components();

        foreach (var element in components)
        {
            var component = element.ToXml();
            section[component.Name] = component;
        }

        return section;
    }

    /// <summary>
    ///  Convert specification component to fixml component
    /// </summary>
    public static Omi.Fix.Xml.Component ToXml(this Component component)
    {
        var result = new Omi.Fix.Xml.Component
        {
            Name = component.Name
        };

        foreach (var item in component.Fields)
        {
            result.Elements.Add(item.ToXmlChild(result));
        }

        return result;
    }

    /// <summary>
    ///  Convert specification types to fixml fields
    /// </summary>
    public static Omi.Fix.Xml.Fields ToXml(this Types types)
    {
        var section = new Omi.Fix.Xml.Fields();

        foreach (var field in types.Values)
        {
            section[field.Name] = new Omi.Fix.Xml.Field
            {
                Name = field.Name,
                Number = field.Tag,
                Type = XmlTypeFrom(field),
                Enums = field.ToXmlEnums(),
                Description = field.Description,
                Required = field.Required,
                Version = field.Version,
            };
        }

        return section;
    }

    /// <summary>
    ///  Convert specification type to fixml type string
    /// </summary>
    public static string XmlTypeFrom(Type field)
        => field.DataType.ToString().ToUpperInvariant();

    /// <summary>
    ///  Convert specification type enums to fixml enums
    /// </summary>
    public static Omi.Fix.Xml.Enums ToXmlEnums(this Type type)
    {
        var enums = new Omi.Fix.Xml.Enums();

        foreach (var @enum in type.Enums)
        {
            enums.Add(@enum.ToXml());
        }

        return enums;
    }

    /// <summary>
    ///  Convert specification enum to fixml enum
    /// </summary>
    public static Omi.Fix.Xml.Enum ToXml(this Enum @enum)
        => new()
        {
            Value = @enum.Value,
            Description = @enum.Name
        };

    /// <summary>
    ///  Convert specification field to fixml child element based on Kind
    /// </summary>
    public static Omi.Fix.Xml.IChild ToXmlChild(this Field field, Omi.Fix.Xml.IParent parent)
    {
        switch (field.Kind)
        {
            case Kind.Field:
                return new Omi.Fix.Xml.Child.Field
                {
                    Name = field.Name,
                    Required = field.Required,
                    Parent = parent
                };

            case Kind.Component:
                return new Omi.Fix.Xml.Child.Component
                {
                    Name = field.Name,
                    Parent = parent
                };

            case Kind.Group:
                return ToXmlGroup(field, parent);

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    ///  Convert specification group field to fixml group
    /// </summary>
    static Omi.Fix.Xml.Child.Group ToXmlGroup(Field element, Omi.Fix.Xml.IParent parent)
    {
        var group = new Omi.Fix.Xml.Child.Group
        {
            Name = element.Name,
            Required = element.Required,
            Parent = parent
        };

        foreach (var item in element.Children)
        {
            group.Elements.Add(item.ToXmlChild(group));
        }

        return group;
    }

    /// <summary>
    ///  Convert specification fields to fixml elements
    /// </summary>
    public static Omi.Fix.Xml.Elements ToXmlElements(this List<Field> fields, Omi.Fix.Xml.IParent parent)
    {
        var elements = new Omi.Fix.Xml.Elements();

        foreach (var element in fields)
        {
            elements.Add(element.ToXmlChild(parent));
        }

        return elements;
    }

    /// <summary>
    ///  Convert fixml document to specification document
    /// </summary>
    public static Document ToSpecification(this Omi.Fix.Xml.Document document)
        => new()
        {
            Information = document.Information.ToSpecification(),
            Header = document.Header.ToSpecification(),
            Trailer = document.Trailer.ToSpecification(),
            Messages = document.Messages.ToSpecification(),
            Components = document.Components.ToSpecification(),
            Types = document.Fields.ToSpecification(),
        };

    /// <summary>
    ///  Convert fixml information to specification information
    /// </summary>
    public static Information ToSpecification(this Omi.Fix.Xml.Information information)
        => new()
        {
            Major = information.Major,
            Minor = information.Minor,
        };

    /// <summary>
    ///  Convert fixml header to specification header
    /// </summary>
    public static Header ToSpecification(this Omi.Fix.Xml.Header header)
    {
        var result = new Header();

        foreach (var element in header.Elements)
        {
            result.Add(element.ToSpecification());
        }

        return result;
    }

    /// <summary>
    ///  Convert fixml trailer to specification trailer
    /// </summary>
    public static Trailer ToSpecification(this Omi.Fix.Xml.Trailer trailer)
    {
        var result = new Trailer();

        foreach (var element in trailer.Elements)
        {
            result.Add(element.ToSpecification());
        }

        return result;
    }

    /// <summary>
    ///  Convert fixml messages to specification messages
    /// </summary>
    public static Messages ToSpecification(this Omi.Fix.Xml.Messages messages)
    {
        var result = new Messages();

        foreach (var message in messages)
        {
            result.Add(message.ToSpecification());
        }

        return result;
    }

    /// <summary>
    ///  Convert fixml message to specification message
    /// </summary>
    public static Message ToSpecification(this Omi.Fix.Xml.Message message)
        => new()
        {
            Type = message.Type,
            Name = message.Name,
            Category = message.Category,
            Fields = message.Elements.ToSpecification()
        };

    /// <summary>
    ///  Convert fixml components to specification components
    /// </summary>
    public static Components ToSpecification(this Omi.Fix.Xml.Components components)
    {
        var result = new Components();

        foreach (var component in components.Values)
        {
            result.Add(component.ToSpecification());
        }

        return result;
    }

    /// <summary>
    ///  Convert fixml component to specification component
    /// </summary>
    public static Component ToSpecification(this Omi.Fix.Xml.Component component)
        => new()
        {
            Name = component.Name,
            Fields = component.Elements.ToSpecification()
        };

    /// <summary>
    ///  Convert fixml fields to specification types
    /// </summary>
    public static Types ToSpecification(this Omi.Fix.Xml.Fields fields)
    {
        var types = new Types();

        var list = fields.Select(f => f.Value).ToList();

        foreach (var field in list)
        {
            types.Add(field.Name, field.ToSpecification());
        }

        return types;
    }

    /// <summary>
    ///  Convert fixml field to specification type
    /// </summary>
    public static Type ToSpecification(this Omi.Fix.Xml.Field field)
        => new()
        {
            Tag = field.Number,
            Name = field.Name,
            DataType = DataTypeFor(field.Type),
            Underlying = field.Type,
            Enums = field.Enums.ToSpecification(),
            Description = field.Description,
            Required = field.Required,
            Version = field.Version
        };

    /// <summary>
    ///  Convert fixml elements to specification fields
    /// </summary>
    public static List<Field> ToSpecification(this Omi.Fix.Xml.Elements elements)
    {
        var fields = new List<Field>();

        foreach (var child in elements)
        {
            fields.Add(child.ToSpecification());
        }

        return fields;
    }

    /// <summary>
    ///  Convert fixml child element to specification field
    /// </summary>
    public static Field ToSpecification(this Omi.Fix.Xml.IChild child)
        => child switch
        {
            Omi.Fix.Xml.Child.Field f => new Field { Kind = Kind.Field, Name = f.Name, Required = f.Required },
            Omi.Fix.Xml.Child.Group g => ToSpecificationGroup(g),
            Omi.Fix.Xml.Child.Component c => new Field { Kind = Kind.Component, Name = c.Name },
            _ => throw new ArgumentOutOfRangeException(nameof(child))
        };

    /// <summary>
    ///  Convert fixml group to specification field
    /// </summary>
    static Field ToSpecificationGroup(Omi.Fix.Xml.Child.Group group)
    {
        var result = new Field
        {
            Kind = Kind.Group,
            Name = group.Name,
            Required = group.Required,
        };

        foreach (var child in group.Elements)
        {
            result.Children.Add(child.ToSpecification());
        }

        return result;
    }

    /// <summary>
    ///  Convert fixml enums to specification enums
    /// </summary>
    public static Enums ToSpecification(this Omi.Fix.Xml.Enums enums)
    {
        var result = new Enums();

        foreach (var @enum in enums)
        {
            result.Add(@enum.ToSpecification());
        }

        return result;
    }

    /// <summary>
    ///  Convert fixml enum to specification enum
    /// </summary>
    public static Enum ToSpecification(this Omi.Fix.Xml.Enum @enum)
        => new()
        {
            Value = @enum.Value,
            Name = @enum.Description
        };

    /// <summary>
    ///  Convert Fixml field type string to specification DataType
    /// </summary>
    public static DataType DataTypeFor(string type)
    {
        switch (type.Trim())
        {
            case "STRING":
            case "String":
            case "string":
                return DataType.String;

            case "COUNTRY":
            case "Country":
                return DataType.Country;

            case "CURRENCY":
            case "Currency":
                return DataType.Currency;

            case "EXCHANGE":
            case "Exchange":
                return DataType.String;

            case "LOCALMKTDATE":
            case "LocalMktDate":
                return DataType.LocalMktDate;

            case "MONTHYEAR":
            case "MonthYear":
                return DataType.MonthYear;

            case "MULTIPLECHARVALUE":
            case "MultipleCharValue":
                return DataType.MultipleCharValue;

            case "MULTIPLESTRINGVALUE":
            case "MULTIPLEVALUESTRING":
            case "MultipleStringValue":
            case "MultipleValueString":
                return DataType.MultipleValueString;

            case "UTCDATE":
            case "UTCDate":
            case "UtcDate":
                return DataType.UtcDate;

            case "UTCDATEONLY":
            case "UTCDateOnly":
            case "UtcDateOnly":
                return DataType.UtcDateOnly;

            case "UTCTIMEONLY":
            case "UTCTimeOnly":
            case "UtcTimeOnly":
                return DataType.UtcTimeOnly;

            case "UTCTIMESTAMP":
            case "UtcTimestamp":
            case "UTCTimestamp":
                return DataType.UtcTimestamp;

            case "TZTIMEONLY":
            case "TZTimeOnly":
                return DataType.TzTimeOnly;

            case "TZTIMESTAMP":
            case "TZTimestamp":
                return DataType.TzTimestamp;

            case "CHAR":
            case "Char":
            case "char":
                return DataType.Char;

            case "BOOLEAN":
            case "Boolean":
                return DataType.Boolean;

            case "DATA":
            case "Data":
            case "data":
                return DataType.Data;

            case "FLOAT":
            case "Float":
            case "float":
                return DataType.Float;

            case "AMT":
            case "Amt":
                return DataType.Amt;

            case "PERCENTAGE":
            case "Percentage":
                return DataType.Percentage;

            case "LANGUAGE":
            case "Language":
                return DataType.Language;

            case "PRICE":
            case "Price":
                return DataType.Price;

            case "PRICEOFFSET":
            case "PriceOffset":
                return DataType.PriceOffset;

            case "QTY":
            case "Qty":
                return DataType.Qty;

            case "INT":
            case "Int":
            case "int":
                return DataType.Int;

            case "DAYOFMONTH":
            case "DayOfMonth":
                return DataType.DayOfMonth;

            case "LENGTH":
            case "Length":
                return DataType.Length;

            case "NUMINGROUP":
            case "NumInGroup":
                return DataType.NumInGroup;

            case "SEQNUM":
            case "SeqNum":
                return DataType.SeqNum;

            case "TAGNUM":
            case "TagNum":
                return DataType.TagNum;

            case "XMLDATA":
            case "XMLData":
                return DataType.XmlData;

            default:
                throw new NotImplementedException($"Unknown Fixml type: {type}");
        }
    }

    /// <summary>
    ///  Gather normalized specifications for all xml files in library
    /// </summary>
    public static List<Document> XmlSpecifications()
    {
        var xmls = Omi.Fix.Xml.Library.Xmls();

        var specifications = new List<Document>();

        foreach (var xml in xmls)
        {
            var fixml = Omi.Fix.Xml.Document.From(xml);
            specifications.Add(fixml.ToSpecification());
        }

        return specifications;
    }
}
