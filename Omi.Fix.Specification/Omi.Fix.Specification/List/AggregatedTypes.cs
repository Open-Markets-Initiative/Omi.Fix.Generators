namespace Omi.Fix.Specification;

/// <summary>
///  Normalized Fix intermedaite specification field types dictionary
/// </summary>

public class AggregatedTypes : Dictionary<string, AggregatedType>
{
    /// <summary>
    ///  Default Constructor
    /// </summary>
    public AggregatedTypes()
    { }

    /// <summary>
    ///  Initialize from IEnumerable types 
    /// </summary>
    public AggregatedTypes(Types types)
    {
        Add(types);
    }

    /// <summary>
    ///  Add types 
    /// </summary>
    public void Add(Types types)
    {
        foreach (var type in types)
        {
            Add(type.Value);
        }
    }

    /// <summary>
    ///  Add type
    /// </summary>
    public void Add(Type type)
    {
        if (TryGetValue(type.Name, out var aggregated))
        {
            aggregated.Add(type);
        }
        else 
        {
            this[type.Name] = new AggregatedType(type);
        }
    }

    /*

    /// <summary>
    ///  Convert Dictionary of types to Specification
    /// </summary>
    public static Types ToTypes(Dictionary<string, Type> type)
    {
        var types = new Types();

        foreach (var pair in type)
        {
            types.Add(pair.Key, pair.Value);
        }

        return types;
    }
*/
    /// <summary>
    ///  Remove Enums
    /// </summary>
    public void RemoveEnumValues(string name)
    {
        if (TryGetValue(name, out var type))
        {
            type.Enums = new Enums();
        }
    }


    /// <summary>
    ///  Return types as ordered list
    /// </summary>
    public List<AggregatedType> ToList()
        => Values.OrderBy(field => field.Tag).ToList();
}