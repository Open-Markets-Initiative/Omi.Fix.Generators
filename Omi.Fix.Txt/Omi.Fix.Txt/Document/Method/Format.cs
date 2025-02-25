namespace Omi.Fix.Txt;

using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

/// <summary>
///  Formatting methods
/// </summary>

public static class Format
{
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

    /// <summary>
    ///  Decapitalize consecutive capital letters assuming next word is upper case
    /// </summary>
    public static string DecapitalizeAbbreviationsBeforeWordsIn(string text)
    {
        // Figure out
        if (string.IsNullOrWhiteSpace(text)) { return string.Empty; }

        var result = new StringBuilder(text);

        // Locate first letter that is a letter
        var position = 0;
        while (!char.IsLetter(text[position]))
        {
            ++position;
        }
        if (position == text.Length) { return result.ToString(); } // check this

        result[position] = char.ToUpper(text[position]);

        var capitalized = true;
        for (var index = position + 1; index < result.Length; ++index)
        {
            // Get case of current letter
            var capital = char.IsUpper(text[index]);

            // Check if abbreviation is done
            if (capitalized && !capital && !char.IsWhiteSpace(text[index]))
            {
                result[index - 1] = char.ToUpper(text[index - 1]);
            }

            // If in an abbreviation set to lower
            if (capitalized)
            {
                result[index] = char.ToLower(text[index]);
            }
            else
            {
                result[index] = text[index];
            }

            capitalized = capital;
        }

        return result.ToString();
    }

    /// <summary>
    ///  Normalize name
    /// </summary>
    public static string Name(string text)
    {
        var textInfo = new CultureInfo("en-US", false).TextInfo;

        var first = text.Replace("-", " ").Replace("_", " ").Replace(".", " ").Replace("/", " or ");
        var second = DecapitalizeAbbreviationsBeforeWordsIn(first);
        var third = Regex.Replace(second, @"\([^)]*\)", string.Empty);
        var fourth = Regex.Replace(third, "[A-Z]", " $0");
        var fifth = textInfo.ToTitleCase(fourth);
        var result = Regex.Replace(fifth, @"\s+", "");

        return result;
    }
}