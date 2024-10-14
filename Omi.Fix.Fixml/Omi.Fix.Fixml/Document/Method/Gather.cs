namespace Omi.Fixml;

/// <summary>
///  FIXML gather methods
/// </summary>

public static class Gather
{
    /// <summary>
    /// Recursively gather set of included component identifiers
    /// </summary>
    public static void ComponentsIn(IChild element, Components components, HashSet<string> set)
    {
        switch (element)
        {
            case Child.Group group:
                foreach (var child in group.Elements)
                {
                    ComponentsIn(child, components, set);
                }
                break;

            case Child.Component component:
                if (components.TryGetValue(component.Name, out var current))
                {
                    set.Add(component.Name);

                    foreach (var child in current.Elements)
                    {
                        ComponentsIn(child, components, set);
                    }
                }
                break;
        }
    }

    /// <summary>
    ///  Recursively gather set of included field identifiers
    /// </summary>
    public static void FieldsIn(IChild element, Components components, HashSet<string> set)
    {
        switch (element)
        {
            case Child.Field field:
                set.Add(field.Name);
                break;

            case Child.Group group:
                set.Add(group.Name);

                foreach (var child in group.Elements)
                {
                    FieldsIn(child, components, set);
                }
                break;

            case Child.Component component:
                if (components.TryGetValue(component.Name, out var current))
                {
                    foreach (var child in current.Elements)
                    {
                        FieldsIn(child, components, set);
                    }
                }
                break;
        }
    }
}
