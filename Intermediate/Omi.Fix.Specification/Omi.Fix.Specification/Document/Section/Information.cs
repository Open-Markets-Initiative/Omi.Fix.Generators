namespace Omi.Fix.Specification;

/// <summary>
///  Normalized Fix Specification Information
/// </summary>

public class Information
{

    #region Properties
    ///////////////////////////////////////////////////////

    // Need to add a bunch more (organization, category, etc)

    /// <summary>
    ///  Normalized Fix Specification Organization
    /// </summary>
    public string Organization = string.Empty;

    /// <summary>
    ///  Normalized Fix Specification Major Version
    /// </summary>
    public string Major = string.Empty;

    /// <summary>
    ///  Normalized Fix Specification Minor Version
    /// </summary>
    public string Minor = string.Empty;

    /// <summary>
    ///  Normalized Fix Specification Source File
    /// </summary>
    public string Source = string.Empty;

    #endregion

    #region Implementation
    ///////////////////////////////////////////////////////

    /// <summary>
    ///  Display Fix Specification Information
    /// </summary>
    public override string ToString()
    {
        var result = "";

        if (!string.IsNullOrWhiteSpace(Organization))
        {
            result += Organization;
        }

        if (!string.IsNullOrWhiteSpace(Major))
        {
            if (!string.IsNullOrWhiteSpace(result))
            {
                result += " ";
            }

            result += $"v{Major}";

            if (!string.IsNullOrWhiteSpace(Minor))
            {
                result += $".{Minor}";
            }

            // need to add service pack
        }

        return result;
    }

    #endregion
}