namespace Omi.Fix.Txt;

public interface IFormatter
{
    string Name(string text);
}

public class NullFormatter : IFormatter
{
    public string Name(string text)
    {
        return text;
    }
}