namespace Omi.Fix.Xml.Test;
    using NUnit.Framework;

/// <summary>
/// Fixml XML document regression tests
/// </summary>

public class XmlTests
{
    [Test]
    public void VerifyFieldElementCount() 
    {
        var fields = Fix44.Document.FirstChild?.ChildNodes.Item(4);

        var expected = 919;
        var actual = fields?.ChildNodes.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Xml Fields element count");
    }

    internal static class Fix44 {
        internal static string Path = System.IO.Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Xml", "Fix.v4.4.xml");
        internal static System.Xml.XmlDocument Document = Omi.Fix.Xml.Document.From(Path).ToXml();
    }
}
