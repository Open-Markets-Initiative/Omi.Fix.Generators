namespace Omi.Fix.Xml.Test;

using NUnit.Framework;

/// <summary>
///  FIXML version information regression tests
/// </summary>

public class InformationTests
{
    [Test]
    public void VerifyFix42Version()
    {
        var document = Document.From(DocumentTests.LibraryPath("Fix.v4.2.xml"));

        var expectedMajor = "4";
        var actualMajor = document.Information.Major;

        var expectedMinor = "2";
        var actualMinor = document.Information.Minor;

        Assert.That(actualMajor, Is.EqualTo(expectedMajor), "Verify Fix 4.2 major version");
        Assert.That(actualMinor, Is.EqualTo(expectedMinor), "Verify Fix 4.2 minor version");
    }

    [Test]
    public void VerifyFix44Version()
    {
        var document = Document.From(DocumentTests.LibraryPath("Fix.v4.4.xml"));

        var expectedMajor = "4";
        var actualMajor = document.Information.Major;

        var expectedMinor = "4";
        var actualMinor = document.Information.Minor;

        Assert.That(actualMajor, Is.EqualTo(expectedMajor), "Verify Fix 4.4 major version");
        Assert.That(actualMinor, Is.EqualTo(expectedMinor), "Verify Fix 4.4 minor version");
    }

    [Test]
    public void VerifyFix50Version()
    {
        var document = Document.From(DocumentTests.LibraryPath("Fix.v5.0.sp2.xml"));

        var expectedMajor = "5";
        var actualMajor = document.Information.Major;

        var expectedMinor = "0";
        var actualMinor = document.Information.Minor;

        Assert.That(actualMajor, Is.EqualTo(expectedMajor), "Verify Fix 5.0 SP2 major version");
        Assert.That(actualMinor, Is.EqualTo(expectedMinor), "Verify Fix 5.0 SP2 minor version");
    }

    [Test]
    public void VerifyFix42VersionString()
    {
        var document = Document.From(DocumentTests.LibraryPath("Fix.v4.2.xml"));

        var expected = "4.2";
        var actual = document.Information.ToString();

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 4.2 version string");
    }

    [Test]
    public void VerifyFix44VersionString()
    {
        var document = Document.From(DocumentTests.LibraryPath("Fix.v4.4.xml"));

        var expected = "4.4";
        var actual = document.Information.ToString();

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 4.4 version string");
    }

    [Test]
    public void VerifyFix50VersionString()
    {
        var document = Document.From(DocumentTests.LibraryPath("Fix.v5.0.sp2.xml"));

        var expected = "5.0";
        var actual = document.Information.ToString();

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 5.0 SP2 version string");
    }
}
