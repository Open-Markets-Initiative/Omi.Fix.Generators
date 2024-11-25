namespace Omi.Fix.T7.Test;
    using NUnit.Framework;

/// <summary>
///  Regression tests for Eti Fix Library
/// </summary>

public class LibraryTests
{
    [Test]
    public void VerifyEtiSpecifications()
    {
        var specifications = Library.Eti.Specifications();

        var actual = specifications.Count;
        var expected = 4;

        Assert.That(actual, Is.EqualTo(expected), "Verify Eurex Eti library count");
    }
}