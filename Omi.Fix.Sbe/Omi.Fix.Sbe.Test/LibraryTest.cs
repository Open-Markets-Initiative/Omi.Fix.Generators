namespace Omi.Fix.Sbe.Test;
    using NUnit.Framework;

/// <summary>
///  Regression tests for Sbe Fix Library
/// </summary>

public class LibraryTests
{
    [Test]
    public void VerifyiLink3Xmls()
    {
        var actual = Library.iLink3.Xmls().Count;
        var expected = 7;

        Assert.That(actual, Is.EqualTo(expected), "Verify iLink3 library count");
    }
}