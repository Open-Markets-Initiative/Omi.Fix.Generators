namespace Omi.Fix.Xml.Test;
    using NUnit.Framework; // Required: Omi.Fix.Xml.Is shadows NUnit.Framework.Is at global scope

/// <summary>
///  FIXML document structure regression tests
/// </summary>

public class DocumentTests
{
    internal static string LibraryPath(string file)
        => Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Xml", file);

    #region Fix 4.2

    [Test]
    public void VerifyFix42MessageCount()
    {
        var document = Document.From(LibraryPath("Fix.v4.2.xml"));

        var expected = 46;
        var actual = document.Messages.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 4.2 message count");
    }

    [Test]
    public void VerifyFix42ComponentCount()
    {
        var document = Document.From(LibraryPath("Fix.v4.2.xml"));

        var expected = 0;
        var actual = document.Components.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 4.2 component count");
    }

    [Test]
    public void VerifyFix42FieldCount()
    {
        var document = Document.From(LibraryPath("Fix.v4.2.xml"));

        var expected = 404;
        var actual = document.Fields.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 4.2 field count");
    }

    [Test]
    public void VerifyFix42HeaderElementCount()
    {
        var document = Document.From(LibraryPath("Fix.v4.2.xml"));

        var expected = 27;
        var actual = document.Header.Elements.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 4.2 header element count");
    }

    [Test]
    public void VerifyFix42TrailerElementCount()
    {
        var document = Document.From(LibraryPath("Fix.v4.2.xml"));

        var expected = 3;
        var actual = document.Trailer.Elements.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 4.2 trailer element count");
    }

    #endregion

    #region Fix 4.4

    [Test]
    public void VerifyFix44MessageCount()
    {
        var document = Document.From(LibraryPath("Fix.v4.4.xml"));

        var expected = 92;
        var actual = document.Messages.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 4.4 message count");
    }

    [Test]
    public void VerifyFix44ComponentCount()
    {
        var document = Document.From(LibraryPath("Fix.v4.4.xml"));

        var expected = 24;
        var actual = document.Components.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 4.4 component count");
    }

    [Test]
    public void VerifyFix44FieldCount()
    {
        var document = Document.From(LibraryPath("Fix.v4.4.xml"));

        var expected = 919;
        var actual = document.Fields.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 4.4 field count");
    }

    [Test]
    public void VerifyFix44HeaderElementCount()
    {
        var document = Document.From(LibraryPath("Fix.v4.4.xml"));

        var expected = 27;
        var actual = document.Header.Elements.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 4.4 header element count");
    }

    [Test]
    public void VerifyFix44TrailerElementCount()
    {
        var document = Document.From(LibraryPath("Fix.v4.4.xml"));

        var expected = 3;
        var actual = document.Trailer.Elements.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 4.4 trailer element count");
    }

    #endregion

    #region Fix 5.0 SP2

    [Test]
    public void VerifyFix50MessageCount()
    {
        var document = Document.From(LibraryPath("Fix.v5.0.sp2.xml"));

        var expected = 110;
        var actual = document.Messages.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 5.0 SP2 message count");
    }

    [Test]
    public void VerifyFix50ComponentCount()
    {
        var document = Document.From(LibraryPath("Fix.v5.0.sp2.xml"));

        var expected = 198;
        var actual = document.Components.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 5.0 SP2 component count");
    }

    [Test]
    public void VerifyFix50FieldCount()
    {
        var document = Document.From(LibraryPath("Fix.v5.0.sp2.xml"));

        var expected = 1610;
        var actual = document.Fields.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 5.0 SP2 field count");
    }

    #endregion

    #region Errors

    [Test]
    public void VerifyFix42NoErrors()
    {
        var document = Document.From(LibraryPath("Fix.v4.2.xml"));

        var actual = document.Errors;

        Assert.That(actual, Is.Empty, "Verify Fix 4.2 has no errors");
    }

    [Test]
    public void VerifyFix44NoErrors()
    {
        var document = Document.From(LibraryPath("Fix.v4.4.xml"));

        var actual = document.Errors;

        Assert.That(actual, Is.Empty, "Verify Fix 4.4 has no errors");
    }

    [Test]
    public void VerifyFix50NoErrors()
    {
        var document = Document.From(LibraryPath("Fix.v5.0.sp2.xml"));

        var actual = document.Errors;

        Assert.That(actual, Is.Empty, "Verify Fix 5.0 SP2 has no errors");
    }

    #endregion
}
