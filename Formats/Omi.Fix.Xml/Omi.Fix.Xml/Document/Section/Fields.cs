namespace Omi.Fix.Xml;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml;

/// <summary>
///  FIXML Fields (Fields Section)
/// </summary>

public class Fields : Dictionary<string, Field>
{
    /// <summary>
    ///  Load fields in FIXML
    /// </summary>
    public static Fields From(Xml.fix xml)
    {
        var section = new Fields();

        foreach (var field in xml.fields)
        { // need ?? 
          // Verify field name exists // format
            section[field.name] = new Field
            {
                Name = field.name,
                Number = field.number,
                Type = field.type,
                Enums = Enums.From(field),
            };
        }

        return section;
    }

    /// <summary>
    ///  Errors in the Fields Section
    /// </summary>
    public List<string> Errors = [];

    /// <summary>
    ///  Remove unused fields
    /// </summary>
    public void ReduceTo(HashSet<string> included)
    {
        foreach (var field in Values)
        {
            if (!included.Contains(field.Name))
            {
                Remove(field.Name);
            }
        }
    }

    /// <summary>
    ///  Normalize MsgTypes
    /// </summary>
    public void ReduceMsgTypesTo(HashSet<string> included)
    {
        // what if msgtypes doesn't exist?

        // filter message types
        if (TryGetValue("MsgType", out var msgtype))
        {
            var enums = new Enums();

            foreach (var value in msgtype.Enums)
            {
                if (included.Contains(value.Value))
                {
                    enums.Add(value);
                }
            }

            msgtype.Enums = enums;
        }
    }

    /// <summary>
    ///  Append as XML element
    /// </summary>
    public void ToXml(XmlDocument document)
    {
        var root = document.FirstChild;

        if (root != null)
        {
            var element = document.CreateElement("fields");
            root.AppendChild(element);

            foreach (var field in Values)
            {
                field.ToXml(document, element);
            }
        }
    }

}
