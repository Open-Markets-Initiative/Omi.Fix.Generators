namespace Omi.Fix.Specification;

/// <summary>
///  Normalized Fix Field Type Declaration
/// </summary>

public class Type
{
    /// <summary>
    ///  Fix Field Type Tag/Number
    /// </summary>
    public uint Tag = 0;

    /// <summary>
    ///  Fix field type name
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    ///  Fix field type name
    /// </summary>
    public DataType DataType = DataType.None;

    /// <summary>
    ///  Fix intermediate field type description
    /// </summary>
    public string Description = string.Empty;

    public bool Required;

    public bool IsHeader;

    public string Version = string.Empty;

    public string Underlying = string.Empty;

    public Enums Enums = new Enums();

    /// <summary>
    ///  Convert type to field
    /// </summary>
    public Field ToField()
        => new()
        {
            Name = Name,
            Kind = Kind.Field,
            Required = Required
        };

    /// <summary>
    ///  Clone
    /// </summary>
    public Type Clone()
        => new()
        {
            Name = Name,
            Tag = Tag,
            DataType = DataType,
            Description = Description,
            Version = Version,
            Underlying = Underlying,
            Required = Required,
            IsHeader = IsHeader,
            Enums = Enums.Clone()
        };

    /// <summary>
    ///  Display intermediate Fix type
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        if (!string.IsNullOrWhiteSpace(Underlying))
        {
            return $"{Tag}: {Name} [{DataType}|{Underlying}]";
        }

        if (DataType != DataType.None)
        {
            return $"{Tag}: {Name}";
        }

        return $"{Tag}: {Name} [{DataType}]";
    }
}