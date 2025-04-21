namespace Omi.Fix.T7.Tests;
    using NUnit.Framework;

/// <summary>
///  Regression tests for Eti Fix Library
/// </summary>

public class LibraryTests
{
    [Test]
    public void VerifyEtiCashMessages()
    {
        var specifications = Library.EtiDerivatives.Active();

        var actual = specifications.Messages.Count;
        var expected = 161;

        Assert.That(actual, Is.EqualTo(expected), "Verify Eurex Eti cash messages count");
    }

    [Test]
    public void VerifyEtiDerivativesMessages()
    {
        var specifications = Library.EtiDerivatives.Active();

        var actual = specifications.Messages.Count;
        var expected = 161;

        Assert.That(actual, Is.EqualTo(expected), "Verify Eurex Eti derivatives message count");
    }

    [Test]
    public void VerifyEdciDerivativesMessages()
    {
        var specifications = Library.Edci.Active();

        var actual = specifications.Messages.Count;
        var expected = 13;

        Assert.That(actual, Is.EqualTo(expected), "Verify Eurex Edci derivatives message count");
    }
}