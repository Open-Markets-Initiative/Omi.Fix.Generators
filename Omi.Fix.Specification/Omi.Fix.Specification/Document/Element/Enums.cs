namespace Omi.Fix.Specification;

using System.Collections.Generic;
using System.Linq;

/// <summary>
///  Normalized Fix Specification Enum List
/// </summary>

public class Enums : List<Enum>
{
    /// <summary>
    ///  Does fix type have any enumerated values
    /// </summary>
    public bool Exist
        => this.Any();

    /// <summary>
    ///  Does fix type have any enumerated values
    /// </summary>
    public IEnumerable<string> Values()
        => from @enum in this 
           select @enum.Value;

    /// <summary>
    ///  Does fix type have any enumerated values
    /// </summary>
    public Enums Clone()
    {
        var clone = new Enums(); // make another constructor

        clone.AddRange(this);

        return clone;
    }

    /// <summary>
    ///  
    /// </summary>
    public void Merge(Enums enums)
    {
        var intersection = new HashSet<string>(Values().Intersect(enums.Values()));
        AddRange(enums.Where(@enum => !intersection.Contains(@enum.Value)));
    }
}