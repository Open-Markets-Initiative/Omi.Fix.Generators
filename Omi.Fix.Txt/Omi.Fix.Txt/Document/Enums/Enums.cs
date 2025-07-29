namespace Omi.Fix.Txt;

using System.Collections.Generic;
using System.Linq;

/// <summary>
///  Dictionary of the Enum(s) found in a file, with its name as the index
/// </summary>

public class Enums : Dictionary<string, Enum>
{
    /// <summary>
    ///  Default constructor
    /// </summary>
    public Enums() { }

    /// <summary>
    ///  Constructor with enum list as input
    /// </summary>
    public Enums(IEnumerable<Enum> enums)
    {
        foreach (var @enum in enums)
        {
            this[@enum.Name] = @enum;
        }
    }

    /// <summary>
    /// Returns enums from a text file
    /// </summary>
    public static Enums From(string path)
    {
        var lines = File.ReadLines(path);

        return From(lines);
    }

    /// <summary>
    ///  Returns enums from a list of lines
    /// </summary>
    public static Enums From(IEnumerable<string> lines)
    {
        // Check that line contains enums
        var enums = new List<string>();
        foreach (var line in lines)
        {
            if (line.Contains(":enum:") && !line[0].Equals("#"))
            {
                enums.Add(line);
            }
        }

        return Process(enums);
    }

    /// <summary>
    /// Process each enum line and return enums
    /// </summary>
    public static Enums Process(IEnumerable<string> lines)
    {
        var enums = new Enums();
        var validlines = lines.ToList().Where(l => !l.StartsWith("#"));

        // Build enum from each valid line and add to list of enums
        foreach (var line in validlines)
        {
            var trimline = line;

            if (line.Contains("#") && !line[0].Equals("#"))
            {
                trimline = line.Substring(0, line.IndexOf("#"));
            }

            var enumerator = Enum.From(trimline);
            enums.Add(enumerator.Name, enumerator);
        }

        return enums;
    }

    /// <summary>
    ///  Determine enum type if it exists
    /// </summary>
    public bool TryGetType(string text, out string type)
    {
        type = string.Empty;

        var key = text.Trim();

        if (TryGetValue(key, out var current))
        {
            // check if all values are single characters
            bool ischar = true;

            foreach (var value in current.Values)
            {
                if (!char.TryParse(value.Data, out var data))
                {
                    ischar = false;
                    break;
                }
            }

            if (ischar)
            {
                type = "CHAR";
            }
            else
            {
                type = "STRING";
            }

            return true;
        }

        return false;
    }

    /// <summary>
    ///  Convert fixml enums to normalized fix specification enums for a given field name
    /// </summary>
    public Specification.Enums ToSpecification(string name, string type)
    {
        var enums = new Fix.Specification.Enums();

        // Different names for beginstring and fixversion
        if (name.Contains("BeginString"))
        {
            name = "FixVersion";
        }

        // Check for field name in enums
        if (TryGetValue(name, out var @enum))
        {
            foreach (var line in @enum.Values)
            {
                var enumline = Enum.ToSpecification(line);
                enums.Add(enumline);
            }
        }
        else if (TryGetValue(type, out @enum))
        {
            foreach (var line in @enum.Values)
            {
                var enumline = Enum.ToSpecification(line);
                enums.Add(enumline);
            }
        }

        return enums;
    }


    /// <summary>
    /// Convert fields to specification as Types
    /// </summary>
    public Specification.Types ToSpecificationAsTypes()
    {
        var types = new Specification.Types();

        foreach (var name in this.Keys)
        {
            TryGetType(name, out var type);
            var dataType = Field.ConvertType(type);
            var underlying = Field.UnderlyingTypeFor(type);

            types.Add(new()
            {
                Tag = 0,
                Name = name,
                DataType = dataType,
                Underlying = underlying,
                Enums = ToSpecification(name, name)
            });
        }

        return types;
    }
}