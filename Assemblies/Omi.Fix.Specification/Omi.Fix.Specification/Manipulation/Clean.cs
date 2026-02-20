namespace Omi.Fix.Specification;
    using System.Collections.Generic;
    using System.Linq;

public partial class Clean
{

    /// <summary>
    ///  Remove unused types and components
    /// </summary>
    public static void Document(Document specification)
    {
        var components = Gather.RequiredComponentsIn(specification);
        Clean.Components(specification, components);

        var fields = Gather.DependentFieldsIn(specification);
        Clean.Types(specification, fields);
    }

    /// <summary>
    ///  Remove unused components in fix specification file
    /// </summary>
    public static void Components(Document specification, HashSet<string> required)
    {
        var components = new Components();

        foreach (var component in specification.Components)
        {
            if (required.Contains(component.Name))
            {
                components.Add(component);
            }
        }

        specification.Components = components;
    }

    /*
    saveFields.Add("Text");
        saveFields.Add("PutOrCall");
        saveFields.Add("CustomerOrFirm");
    */

    /// <summary>
    ///  Normalize values and remove unused types in specification
    /// </summary>
    public static void Types(Document specification, HashSet<string> required)
    {
        var types = new Types();

        foreach (var type in specification.Types.Values.OrderBy(fix => fix.Tag))
        {
            if (required.Contains(type.Name))
            {
                types.Add(type.Name, type);
            }
        }

        specification.Types = types;
    }
}