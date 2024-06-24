namespace Omi.Fix.Types;

/// <summary>
///  Fix Type Enumerated Value
/// </summary>

public class Enum
{

    /// <summary>
    ///  Enum name
    /// </summary>
    public string Name = string.Empty;

    /// <summary>
    ///  Enum value
    /// </summary>
    public string Value = string.Empty;

    /// <summary>
    ///  Enum description
    /// </summary>
    public string Description = string.Empty;

    /// <summary>
    ///  Convert field value
    /// </summary>
    public static Enum From(Xml.FixFieldsFixFieldSpecFixEnumField @enum)
        => new()
        {
            Name = @enum.Key,
            Value = @enum.Value,
            //Description = @enum // todo
        };

    /// <summary>
    ///  Convert type value
    /// </summary>
    public static Enum From(Xml.FixTypesFixTypeEnum @enum)
        => new()
        {
            Name = @enum.Name,
            Value = @enum.Value,
            //Description = @enum // todo
        };

    /// <summary>
    ///  Convert normalized enum value to fields enum
    /// </summary>
    public static Enum From(Fix.Specification.Enum @enum)
        => new()
        {
            Name = @enum.Name,
            Value = @enum.Value,
            Description = @enum.Description
        };

    /// <summary>
    ///  Convert fields enumerated value to normalized fix specification value
    /// </summary>
    public Fix.Specification.Enum ToSpecification()
        => new()
        {
            Name = Name,
            Value = Value,
            Description = Description
        };

    /// <summary>
    /// Write fix type enum to stream
    /// </summary>
    public void Write(StreamWriter stream)
    {
        stream.WriteLine($"    <Enum>");
        stream.WriteLine($"      <Name>{Name}</Name>");
        stream.WriteLine($"      <Value>{Value}</Value>");

        if (!string.IsNullOrEmpty(Description))
        {
            stream.WriteLine($"      <Description>{Description}</Description>");
        }

        stream.WriteLine($"    </Enum>");
    }

    /// <summary>
    ///  Display enumerated value as string
    /// </summary>
    public override string ToString()
    {
        if (string.IsNullOrWhiteSpace(Description))
        {
            return $"{Name} = {Value}";
        }

        return $"{Name} = {Value}, {Description}";
    }
}