namespace Omi.Fix.T7.Xml;

using System.Text;

public static partial class Format 
{
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
}
