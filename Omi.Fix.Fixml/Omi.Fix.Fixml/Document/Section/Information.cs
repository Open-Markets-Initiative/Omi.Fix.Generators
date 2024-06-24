namespace Omi.Fixml;

/// <summary>
///  Fixml Specification Information
/// </summary>

public class Information
{

    // Need to add Service pack

    /// <summary>
    ///  Fixml Major Version
    /// </summary>
    public string Major = string.Empty;

    /// <summary>
    ///  Fixml Minor Version
    /// </summary>
    public string Minor = string.Empty;

    /// <summary>
    ///  Convert xml attributs to fixml information
    /// </summary>
    public static Information From(Xml.fix xml)
        => new()
        { // need more checks, defaults
            Major = xml.major.ToString(),
            Minor = xml.minor.ToString(),
        };

    /// <summary>
    /// Convert from specification Types to Xml Fields
    /// </summary>
    public static Information From(Fix.Specification.Information description)
        => new()
        {
            Major = description.Major,
            Minor = description.Minor,
        };

    /// <summary>
    ///  Write components out to Fixml
    /// </summary>
    public void Write(StreamWriter stream)
    {
        stream.WriteLine($"<fix major=\"{Major}\" minor=\"{Minor}\">"); // sp, null, etc
    }

    /// <summary>
    ///  Convert fixml field declarations to normalized fix specification description
    /// </summary>
    public Fix.Specification.Information ToSpecification()
        => new()
        {
            Major = Major,
            Minor = Minor,
        };

    /// <summary>
    ///  Verify fixml information
    /// </summary>
    public void Verify()
    {
        if (string.IsNullOrWhiteSpace(Major))
        {
            throw new Exception("Missing Major Version");
        }
    }

    /// <summary>
    ///  Report errors in fixml information
    /// </summary>
    public void Error()
    {
        if (string.IsNullOrWhiteSpace(Minor))
        {
            Console.WriteLine("Missing Minor Version");
        }
    }

    /// <summary>
    ///  Display fixml version information as string
    /// </summary>
    public override string ToString()
    {
        if (!string.IsNullOrWhiteSpace(Minor))
        {
            return $"{Major}.{Minor}";
        }
        if (string.IsNullOrWhiteSpace(Major))
        {
            return $"{Major}";
        }

        return "UNSPECIFIED";
    }

}
