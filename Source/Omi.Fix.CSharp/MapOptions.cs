namespace Omi.Fix.Generate;

/// <summary>
///  Map file options
/// </summary>

public partial class MapOptions
{
    /// <summary>
    ///  Universal Fix types list
    /// </summary>
    public List<Omi.Fix.Specification.Type> Types = [];

    /// <summary>
    ///  File namespace
    /// </summary>
    public string Namespace = string.Empty;

    /// <summary>
    ///  Class 
    /// </summary>
    public string Class = "FixMap";

    /// <summary>
    ///  Class comment
    /// </summary>
    public string Comment = "Fix Tags to Names";

    /// <summary>
    ///  Dictionary declaration 
    /// </summary>
    public string Declaration = "TagsToNames";
}