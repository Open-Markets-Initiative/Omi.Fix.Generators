namespace Omi.Fix.Specification;

/// <summary>
///  Normalized Fix Field Type Declaration
/// </summary>

public class Type
{
    /// <summary>
    ///  Fix Field Tag/Number
    /// </summary>
    public uint Tag = 0;

    public string Name = string.Empty;

    public string DataType = string.Empty;

    public string Description = string.Empty;

    public bool Required;

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
    ///  Display intermediate Fix type
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
        if (!string.IsNullOrWhiteSpace(Underlying) && Underlying != DataType)
        {
            return $"{Tag}: {Name} [{DataType}|{Underlying}]";
        }

        if (!string.IsNullOrWhiteSpace(DataType))
        {
            return $"{Tag}: {Name}";
        }

        return $"{Tag}: {Name} [{DataType}]";
    }

}