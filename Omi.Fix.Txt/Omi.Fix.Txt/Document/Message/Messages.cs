namespace Omi.Fix.Txt;

using System.Collections.Generic;
using System.Linq;

/// <summary>
/// List of message(s) from text 
/// </summary>

public class Messages : List<Message>
{
    /// <summary>
    ///  Default constructor
    /// </summary>
    public Messages()
    { }

    /// <summary>
    /// Contruct messages fromtext  file
    /// </summary>
    public static Messages From(string path)
    {
        var lines = File.ReadLines(path);

        return From(lines);
    }

    /// <summary>
    /// Construct messages from lines in file
    /// </summary>
    public static Messages From(IEnumerable<string> lines)
    {
        var messages = new List<string>();

        // Check if line contains message information, then process 
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
            {
                continue;
            }

            if (line.Contains(":enum:") || line[0].Equals("#") || char.IsDigit(line[0]) || !line.Contains(":"))
            {
                continue;
            }

            messages.Add(line);
        }

        return Process(messages);
    }

    /// <summary>
    /// Obtain messages from lines containing message info 
    /// </summary>
    public static Messages Process(IEnumerable<string> lines)
    {
        var messages = new Messages();
        var validlines = lines.ToList().Where(l => !l.StartsWith("#"));

        foreach (var line in validlines)
        {
            Message message = Message.From(line);
            messages.Add(message);
        }
        return messages;
    }

    /// <summary>
    /// Obtain Fix specification from message
    /// </summary>
    public Specification.Messages ToSpecification()
    {
        var messages = new Specification.Messages();

        foreach (var message in this)
        {
            messages.Add(message.ToSpecification());
        }
        return messages;
    }
}