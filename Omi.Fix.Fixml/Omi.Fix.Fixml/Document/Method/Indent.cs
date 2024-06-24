namespace Omi.Fixml;
    using System.Text;

/// <summary>
///  Fixml indent information
/// </summary>

public class Indent
{

    /// <summary>
    ///  Indent Text
    /// </summary>
    public string Text = "  ";

    /// <summary>
    ///  Number of indents to apply
    /// </summary>
    public int Count = 1;

    /// <summary>
    ///  Increment indent count
    /// </summary>
    public Indent Increment()
        => new() { Text = Text, Count = Count + 1 };

    /// <summary>
    ///  fix this
    /// </summary>
    public override string ToString()
        => new StringBuilder(Text.Length * Count).Insert(0, Text, Count).ToString();
}
