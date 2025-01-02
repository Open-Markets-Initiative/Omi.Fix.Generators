namespace Omi.Fixml.Child;
    using System;
using System.Reflection.PortableExecutable;
using System.Xml;
using Omi.Fix.Specification;

/// <summary>
///  Fix Xml Field Element
/// </summary>

public class Field : IChild
{

    /// <summary>
    ///  Fixml field name
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    ///  Is Fixml field required?
    /// </summary>
    public bool Required { get; set; }

    /// <summary>
    ///  Fixml field parent
    /// </summary>
    public required IParent Parent { get; set; } // how to deal with this

    /// <summary>
    ///  Component depth in element tree
    /// </summary>
    public int Depth()
        => Omi.Fixml.Depth.Of(this);

    /// <summary>
    ///  Convert xml child element to fixml document element
    /// </summary>
    public static IChild From(object item, IParent parent)
    {
        switch (item)
        {
            case Xml.fixChildField field:
                return Field.From(field, parent);

            case Xml.fixChildGroup group:
                return Group.From(group, parent);

            case Xml.fixChildComponent component:
                return Component.From(component, parent);

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    ///  Convert normalized fix specification field to fixml element
    /// </summary>
    public static IChild From(Fix.Specification.Field field, IParent parent)
    {
        switch (field.Kind)
        {
            case Kind.Field:
                return new Field
                {
                    Name = field.Name,
                    Required = field.Required,
                    Parent = parent
                };

            case Kind.Component:
                return Component.From(field, parent);

            case Kind.Group:
                return Group.From(field, parent);

            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    /// <summary>
    ///  Convert xml child field element to fixml document element 
    /// </summary>
    public static Field From(Xml.fixChildField field, IParent parent)
    {
        // verify values
        return new Field
        {
            Name = field.name,
            Required = Is.Required(field.required),
            Parent = parent
        };
    }

    /// <summary>
    /// Appends XmlElement from Field to parent
    /// </summary>
    public void ToXml(XmlDocument doc,XmlElement parent) 
        {
        var fieldElement = doc.CreateElement("field");

        //Append name attribute to fieldElement
        var nameAtr = doc.CreateAttribute("name");
        nameAtr.Value = Name;
        fieldElement.Attributes.Append(nameAtr);

        //Append required attribute to fieldElement
        var reqAtr = doc.CreateAttribute("required");
        reqAtr.Value = Required ? "Y" : "N";
        fieldElement.Attributes.Append(reqAtr);

        //Append fieldElement to parent
        parent.AppendChild(fieldElement);
    }

    /// <summary>
    ///  Convert fixml field to normalized fix specification field
    /// </summary>
    public Fix.Specification.Field ToSpecification()
        => new() { Kind = Kind.Field, Name = Name, Required = Required };

    /// <summary>
    ///  Verify fixml field element
    /// </summary>
    public void Verify(Fields fields, Fixml.Components components)
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            throw new Exception("Field name is missing");
        }

        if (!fields.ContainsKey(Name))
        {
            throw new Exception($"{Name}: Field is missing from dictionary");
        }
    }

    /// <summary>
    ///  Report erroneous fixml field element
    /// </summary>
    public void Error(Fields fields, Fixml.Components components, List<string> Errors)
    {
        if (string.IsNullOrWhiteSpace(Name))
        {
            Errors.Add("Field name is missing");

            fields.Errors.Add("Field name is missing");
        }

        if (!fields.ContainsKey(Name))
        {
            Errors.Add($"{Name}: Field is missing from dictionary");

            fields.Errors.Add($"{Name}: Field is missing from dictionary");
        }

    }

    /// <summary>
    ///  Display fixml field as string
    /// </summary>
    public override string ToString()
        => $"{Name} [Field]";
}
