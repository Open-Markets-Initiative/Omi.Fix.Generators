namespace Omi.Fix.Specification;

/// <summary>
///  Normalized Fix Specification Enumerated Value
/// </summary>

public class Enum
{

    /// <summary>
    ///  
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string Value = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public string Description = string.Empty;

    /// <summary>
    /// 
    /// </summary>
    public override string ToString()
    {
        if (string.IsNullOrEmpty(Description))
        {
            return $"{Name} [{Value}]";
        }

        return $"{Name} [{Value}] {Description}";
    }
}