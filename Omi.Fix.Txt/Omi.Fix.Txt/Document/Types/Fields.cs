namespace Omi.Fix.Txt;
    using System.Collections.Generic;
    using System.Linq;

/// <summary>
/// List of all the fields found in a text file
/// </summary>

public class Fields : List<Field>
{
    /// <summary>
    ///  Default constructor
    /// </summary>
    public Fields()
    { }

    /// <summary>
    /// Returns fields from a text file
    /// </summary>
    public static Fields From(string path)
    {
        var lines = File.ReadLines(path);

        return From(lines, Enums.From(lines));
    }

    /// <summary>
    /// Obtain lines in the path to our text file, returns fields
    /// </summary>
    public static Fields From(IEnumerable<string> lines, Enums enums)
    {
        var fields = new List<string>();

        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (line.Contains(":enum:") || line[0].Equals("#"))
            {
                continue;
            }

            fields.Add(line);
        }

        return Process(fields, enums);
    }

    /// <summary>
    /// Return fields from lines in text file
    /// </summary>
    public static Fields Process(IEnumerable<string> lines, Enums enums)
    {
        var fields = new Fields();
        var validlines = lines.ToList().Where(l => !l.StartsWith("#"));

        foreach (var line in validlines)
        {
            if (string.IsNullOrEmpty(line))
            {
                continue;
            }

            // Field lines begin with an int
            var fieldID = line[0].ToString();
            if (!Int32.TryParse(fieldID, out var value))
            {
                continue;
            }

            Field field = Field.From(line);
            fields.Add(field);
        }

        return fields;
    }

    /// <summary>
    /// Convert fields to specification
    /// </summary>
    public Specification.Types ToSpecification(Enums enums)
    {
        var fields = new Specification.Types();

        foreach (var field in this)
        {
            fields.Add(field.Name, field.ToSpecification(enums));
        }

        // what about enums with no field value?

        return fields;
    }

}