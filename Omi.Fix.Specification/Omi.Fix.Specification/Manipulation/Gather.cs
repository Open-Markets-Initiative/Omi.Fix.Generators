namespace Omi.Fix.Specification;
    using System.Collections.Generic;
    using System.Linq;

public partial class Gather
{

    /// <summary>
    ///  Obtain a list of the components which are found in the messages
    /// </summary>
    public static HashSet<string> RequiredComponentsIn(Document specification)
    {
        var set = new HashSet<string>();

        // Add all headers
        foreach (var header in specification.Header)
        {
            RequiredComponentsIn(header, set);
        }

        // Add all trailers
        foreach (var trailer in specification.Trailer)
        {
            RequiredComponentsIn(trailer, set);
        }

        // Add components in messages
        foreach (var message in specification.Messages)
        {
            foreach (var field in message.Fields)
            {
                RequiredComponentsIn(field, set);
            }
        }

        var required = set.ToHashSet();

        // Add components in components
        foreach (var component in specification.Components)
        {
            if (required.Contains(component.Name))
            {
                foreach (var field in component.Fields)
                {
                    RequiredComponentsIn(field, set);
                }
            }
        }

        return set;
    }

    /// <summary>
    ///  Recursively check for components
    /// </summary>
    public static void RequiredComponentsIn(Field field, HashSet<string> set)
    {
        // gather 
        if (field.Kind == Kind.Component && field.Required == true)
        {
            set.Add(field.Name);
        }

        foreach (var child in field.Children)
        {
            RequiredComponentsIn(child, set);
        }
    }

    /// <summary>
    ///  Obtain a list of the fields which are found in the messages
    /// </summary>
    public static HashSet<string> RequiredFieldsIn(Document specification)
    {
        var set = new HashSet<string>();

        // add required header
        foreach (var header in specification.Header)
        {
            RequiredFieldsIn(header, set);
        }

        // add required trailer
        foreach (var trailer in specification.Trailer)
        {
            RequiredFieldsIn(trailer, set); ;
        }

        // add fields in messages
        foreach (var message in specification.Messages)
        {
            foreach (var field in message.Fields)
            {
                RequiredFieldsIn(field, set);
            }
        }

        // add fields in components
        foreach (var component in specification.Components)
        {
            foreach (var field in component.Fields)
            {
                RequiredFieldsIn(field, set);
            }
        }

        return set;
    }

    /// <summary>
    ///  Recursively gather required fields
    /// </summary>
    public static void RequiredFieldsIn(Field field, HashSet<string> set)
    {
        // fields and group count fields are required
        if (field.Kind == Kind.Field || field.Kind == Kind.Group)
        {
            set.Add(field.Name);
        }

        foreach (var child in field.Children)
        {
            RequiredFieldsIn(child, set);
        }
    }
}