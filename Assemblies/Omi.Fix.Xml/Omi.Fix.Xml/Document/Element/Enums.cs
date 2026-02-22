namespace Omi.Fix.Xml;
    using System.Collections.Generic;
    using System.Linq;

/// <summary>
///  List of enum values for a Fixml field
/// </summary>

public class Enums : List<Enum>
{

    /// <summary>
    ///  Default constructor
    /// </summary>
    public Enums(){ }

    /// <summary>
    /// Constructs enums from an IEnumerable
    /// </summary>
    public Enums(IEnumerable<Enum> enums)
    {
        AddRange(enums);
    }

    /// <summary>
    ///  Gather enum values from fixml xml field
    /// </summary>
    public static Enums From(Xml.fixField field)
        => new(ListFrom(field).Select(Enum.From));

    /// <summary>
    ///  Gather enum xml elements from fixml
    /// </summary>
    public static Xml.fixFieldValue[] ListFrom(Xml.fixField field)
        => field.value ?? Array.Empty<Xml.fixFieldValue>();

}
