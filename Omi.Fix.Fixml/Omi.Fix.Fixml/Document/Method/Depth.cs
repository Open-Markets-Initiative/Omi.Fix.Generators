namespace Omi.Fixml;

/// <summary>
///  Depth methods
/// </summary>

public static class Depth
{

    /// <summary>
    ///  Depth of element
    /// </summary>
    public static int Of(IChild child)
    {
        int result = 1;
        IChild? current = child;
        while (true)
        {
            current = current.Parent as IChild;
            if (current == null) { break; }
            result++;
        }

        return result;
    }
}
