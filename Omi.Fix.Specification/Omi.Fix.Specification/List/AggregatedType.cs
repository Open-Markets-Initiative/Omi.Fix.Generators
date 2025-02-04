namespace Omi.Fix.Specification;

/// <summary>
///  List of types with the same name
/// </summary>

public class AggregatedType
{

    /// <summary>
    /// 
    /// </summary>
    public AggregatedType(Type first)
    {
        Types.Add(first);
    }

    // List of Types
    public List<Type> Types = [];

    /// <summary>
    ///  Fix Field Type Tag/Number
    /// </summary>
    public uint Tag 
        => Types.First().Tag;
    
    /// <summary>
    ///  Fix field type name
    /// </summary>
    public string Name
        => Types.First().Name;

    /// <summary>
    ///  Fix field type name
    /// </summary>
    public DataType DataType
        => Types.First().DataType;

    /// <summary>
    ///  Fix field type name
    /// </summary>
    public string Description = string.Empty; // need to handle

    /// <summary>
    ///  Fix field type versions list
    /// </summary>
    public string Versions
        => string.Join(", ", from type in Types select type.Version);

    /// <summary>
    ///  Aggregated Enums
    /// </summary>
    public Enums Enums = new Enums();

    /// <summary>
    ///  Display intermediate Fix type
    /// </summary>
    public void Add(Type type)
    {
        // check that name is the same

        Types.Add(type);

        // update various fields

        if (string.IsNullOrEmpty(Description)) 
        { 
            Description = type.Description;
        }
        // handle enums here
    }


    /// <summary>
    ///  Display intermediate Fix type
    /// </summary>
    /// <returns></returns>
    public override string ToString()
        => $"{Tag}: {Name} [{DataType}], Count:{Types.Count}";
}