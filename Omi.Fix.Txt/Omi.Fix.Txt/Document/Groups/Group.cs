﻿namespace Omi.Fix.Txt;

/// <summary>
///  Fix Txt Group 
/// </summary>

public class Group
{
    /// <summary>
    /// Name of group
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    /// States whether a group is required in fix message
    /// </summary>
    public bool Required;

    /// <summary>
    /// List of children associated with group
    /// </summary>
    public List<Group> Children = new List<Group>();

    /// <summary>
    /// Group from properties
    /// </summary>
    public static Group From(string name, bool required, List<Group> children)
        => new Group
        {
            Name = name,
            Required = required,
            Children = children
        };

    /// <summary>
    /// Group from string 
    /// </summary>
    public static Group From(string pair)
    {
        pair = pair.Trim();
        // If string has square bracket, children exist
        var children = new Children();

        if (pair.Contains("["))
        {
            if (!pair.Contains("]"))
            {
                throw new ArgumentException(pair, "invalid group format");
            }

            // Trim substring containing children and obtain children
            int start = pair.IndexOf("[") + 1;
            int end = pair.IndexOf("]", start);

            var childstring = pair.Substring(start, end - start);

            children = Txt.Children.From(childstring);
        }

        // Default for requirement is false
        var required = false;
        string name;

        // Check if group required, parse for name
        if (pair.Contains("("))
        {
            name = pair.Substring(0, pair.IndexOf("("));

            int start = pair.IndexOf("(") + 1;
            int end = pair.IndexOf(")", start);

            var requirestring = pair.Substring(start, end - start);
            requirestring.ToLower();

            if (requirestring.StartsWith("required"))
            {
                required = true;
            }
        }
        else
        {
            name = pair;
        }

        return From(name, required, children);
    }

    /// <summary>
    /// Obtain specification for group
    /// </summary>
    public Specification.Field ToSpecification()
    {
        var field = new Specification.Field();
        field.Name = this.Name;
        field.Required = this.Required;

        // convert each child to specification 
        var child = this.Children;
        var children = new List<Specification.Field>();

        foreach (var childelement in child)
        {
            children.Add(childelement.ToSpecification());
        }

        field.Children = children;

        return field;
    }

    public override string ToString()
        => $"{Name}, {Required}";
}