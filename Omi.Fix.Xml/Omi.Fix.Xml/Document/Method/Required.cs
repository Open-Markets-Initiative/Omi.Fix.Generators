namespace Omi.Fix.Xml;
    using System;

/// <summary>
///  Child Field Traits
/// </summary>

public static partial class Is
{

    /// <summary>
    ///  Determines requirement based on value
    /// </summary>
    public static bool Required(string value)
    {
        if (value == "Y")
        {
            return true;
        }
        if (value == "N")
        {
            return false;
        }

        throw new ArgumentOutOfRangeException(nameof(value)); // do better
    }
}
