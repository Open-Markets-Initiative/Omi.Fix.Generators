namespace Omi.Fix.Txt;

using System.Linq;

/// <summary>
/// Name and data of corresponing enum
/// </summary>

public class Value
{
    /// <summary>
    /// Name of value
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    /// Data or symbol for associated Name
    /// </summary>
    public string Data = string.Empty;

    /// <summary>
    /// Contains Value from properties
    /// </summary>
    public static Value From(string name, string data)
        => new()
        {
            Name = name,
            Data = data
        };

    /// <summary>
    /// Contains Value from string
    /// </summary>
    public static Value From(string pair)
    {
        // need to rewrite this

        // Check valid input
        if (string.IsNullOrWhiteSpace(pair))
        {
            throw new ArgumentException(nameof(pair));
        }

        var index = pair.IndexOf("=");

        if (index < 0)
        {
            throw new ArgumentException(nameof(pair));
        }

        // Trim whitespace from string and find where name and data are split
        var current = String.Concat(pair.Where(c => !Char.IsWhiteSpace(c)));
        var token = pair.Substring(0, current.IndexOf("="));
        var name = Format.Name(token);

        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException(nameof(pair));
        }

        var data = current.Substring(current.IndexOf("=") + 1);

        return From(name, data);
    }

    /// <summary>
    ///  Display enumerated value
    /// </summary>
    public override string ToString()
        => $"{Data} => {Name}";
}