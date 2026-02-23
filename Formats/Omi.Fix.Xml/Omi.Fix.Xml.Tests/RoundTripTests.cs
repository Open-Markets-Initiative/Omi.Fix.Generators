namespace Omi.Fix.Xml.Test;

using NUnit.Framework;

/// <summary>
///  FIXML round-trip regression tests (load, write, reload)
/// </summary>

public class RoundTripTests
{
    [Test]
    public void VerifyFix42RoundTrip()
    {
        var original = Document.From(DocumentTests.LibraryPath("Fix.v4.2.xml"));
        var output = Path.Combine(TestContext.CurrentContext.TestDirectory, "RoundTrip.Fix42.xml");

        original.WriteTo(output);
        var reloaded = Document.From(output);

        Assert.That(reloaded.Messages.Count, Is.EqualTo(original.Messages.Count), "Verify round-trip message count");
        Assert.That(reloaded.Fields.Count, Is.EqualTo(original.Fields.Count), "Verify round-trip field count");
        Assert.That(reloaded.Components.Count, Is.EqualTo(original.Components.Count), "Verify round-trip component count");
        Assert.That(reloaded.Header.Elements.Count, Is.EqualTo(original.Header.Elements.Count), "Verify round-trip header count");
        Assert.That(reloaded.Trailer.Elements.Count, Is.EqualTo(original.Trailer.Elements.Count), "Verify round-trip trailer count");
        Assert.That(reloaded.Information.Major, Is.EqualTo(original.Information.Major), "Verify round-trip major version");
        Assert.That(reloaded.Information.Minor, Is.EqualTo(original.Information.Minor), "Verify round-trip minor version");
    }

    [Test]
    public void VerifyFix44RoundTrip()
    {
        var original = Document.From(DocumentTests.LibraryPath("Fix.v4.4.xml"));
        var output = Path.Combine(TestContext.CurrentContext.TestDirectory, "RoundTrip.Fix44.xml");

        original.WriteTo(output);
        var reloaded = Document.From(output);

        var expected = original.Messages.Count;
        var actual = reloaded.Messages.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify round-trip message count");
        Assert.That(reloaded.Fields.Count, Is.EqualTo(original.Fields.Count), "Verify round-trip field count");
        Assert.That(reloaded.Components.Count, Is.EqualTo(original.Components.Count), "Verify round-trip component count");
        Assert.That(reloaded.Header.Elements.Count, Is.EqualTo(original.Header.Elements.Count), "Verify round-trip header count");
        Assert.That(reloaded.Trailer.Elements.Count, Is.EqualTo(original.Trailer.Elements.Count), "Verify round-trip trailer count");
    }

    [Test]
    public void VerifyFix50RoundTrip()
    {
        var original = Document.From(DocumentTests.LibraryPath("Fix.v5.0.sp2.xml"));
        var output = Path.Combine(TestContext.CurrentContext.TestDirectory, "RoundTrip.Fix50.xml");

        original.WriteTo(output);
        var reloaded = Document.From(output);

        var expected = original.Messages.Count;
        var actual = reloaded.Messages.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify round-trip message count");
        Assert.That(reloaded.Fields.Count, Is.EqualTo(original.Fields.Count), "Verify round-trip field count");
        Assert.That(reloaded.Components.Count, Is.EqualTo(original.Components.Count), "Verify round-trip component count");
    }

    [Test]
    public void VerifyRoundTripPreservesErrors()
    {
        var original = Document.From(DocumentTests.LibraryPath("Fix.v4.4.xml"));
        var output = Path.Combine(TestContext.CurrentContext.TestDirectory, "RoundTrip.Errors.xml");

        original.WriteTo(output);
        var reloaded = Document.From(output);

        var expected = original.Errors.Count;
        var actual = reloaded.Errors.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify round-trip preserves error count");
    }
}
