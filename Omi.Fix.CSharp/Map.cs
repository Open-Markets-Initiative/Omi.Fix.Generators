namespace Omi.Fix.Generate;

using System.Text;

/// <summary>
///  Generate CSharp Fix Tags To Names Dictionary
/// </summary>

public static partial class CSharp
{
    /// <summary>
    ///  Generate C# Fix tags to field names map
    /// </summary>
    public static StringBuilder FixFieldTagsToNames(MapOptions options) 
    {  
        var file = new StringBuilder();

        if (!string.IsNullOrWhiteSpace(options.Namespace)) 
        {
            file.AppendLine($"{options.Namespace};");
            file.AppendLine();
        }

        if (!string.IsNullOrWhiteSpace(options.Class))
        {
            file.AppendLine($"{options.Class}");
            file.AppendLine("{");
        }

        if (!string.IsNullOrWhiteSpace(options.Comment))
        {
            file.AppendLine($"    /// <summary>");
            file.AppendLine($"    ///  {options.Comment}");
            file.AppendLine($"    /// </summary>");
        }


        file.AppendLine($"    public void new Dictionary<ushort, string>{options.Declaration} = ");
        file.AppendLine("    {");
        
        foreach (var type in options.Types) 
        {
     //       file.Append($"{{{type.Tag}, ,");
        }

        return file; 
    }
}