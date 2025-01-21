namespace Omi.Fix.Fixml.Test;
using NUnit.Framework;

/// <summary>
/// Fixml XML document regression tests
/// </summary>

public class XmlTests
{
    [Test]
    public void VerifyFixTypeElementCount() {
        var expected = 899;
        var actual = Fix44.Document.FirstChild?.ChildNodes.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Xml Type element count");
    }

    internal static class Fix44
    {
        internal static string Path = System.IO.Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Fields", "Fix44.Fields.xml");
        internal static System.Xml.XmlDocument Document = Omi.Fix.Types.Document.From(Path).ToXml();
    }
}