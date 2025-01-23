namespace Omi.Fix.Sbe;

/// <summary>
///  Formatting methods
/// </summary>

public static class Format
{
    /// <summary>
    ///  Make first letter uppercase
    /// </summary>
    public static string ToUpperFirstLetter(this string source)
        => UpperFirstLetter(source);

    /// <summary>
    ///  Make first letter uppercase
    /// </summary>
    public static string UpperFirstLetter(string source)
    {
        if (string.IsNullOrEmpty(source))
        {
            return string.Empty;
        }

        var letters = source.ToCharArray();

        letters[0] = char.ToUpper(letters[0]);

        return new string(letters);
    }
}