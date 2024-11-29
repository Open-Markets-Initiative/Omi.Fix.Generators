namespace Omi.Fix.Specification;
    using System;
    using System.Collections.Generic;

/// <summary>
///  Normalized Fix Specification Child Field Element
/// </summary>

public class Field
{
    public string Name = string.Empty;

    public bool Required { get; set; }

    public Kind Kind { get; set; }

    public List<Field> Children = new List<Field>();

    /// <summary>
    ///  Set field with parameter name to not required
    /// </summary>
    public void SetNotRequired(string name)
    {
        Required = false;

        foreach (var field in Children) // make recursive optional
        {
            field.SetNotRequired(name);
        }
    }


    /// <summary>
    ///  Convert normalized fix specification field to string 
    /// </summary>
    public override string ToString()
    {
        switch (Kind)
        {
            case Kind.Field:
                return $"{Name}{(Required ? " : Required" : "")}";

            case Kind.Component:
                return $"Component";

            case Kind.Group:
                return $"Group";

            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}