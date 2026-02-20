namespace Omi.Fix.Types.Test;
    using NUnit.Framework;

public class InformationTests
{
    Document document;

    [OneTimeSetUp]
    public void SetUp()
    {
        document = Document.From(Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Fields", "Fix42.Fields.xml"));
    }

    [Test]
    public void VerifyInformationMajor()
    {
        var actual = document.Information.Major;
        var expected = string.Empty;

        Assert.That(actual, Is.EqualTo(expected), "Verify fix major version");
    }

    [Test]
    public void VerifyInformationMinor()
    {
        var actual = document.Information.Minor;
        var expected = string.Empty;

        Assert.That(actual, Is.EqualTo(expected), "Verify fix minor version");
    }

    [Test]
    public void VerifyInformationSource()
    {
        var actual = document.Information.Source;
        var expected = Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Fields", "Fix42.Fields.xml");

        Assert.That(actual, Is.EqualTo(expected), "Verify fix source");
    }
}