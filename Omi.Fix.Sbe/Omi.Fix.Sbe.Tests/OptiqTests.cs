namespace Omi.Fix.Sbe.Test;
using NUnit.Framework;

/// <summary>
///  Regression tests for Opti Sbe
/// </summary>

public class OptiqTests {

    [Test]
    public void VerifyFixSpecificationMessageCount()
    {
        var actual = Optiq.Fix.Messages.Count;
        var expected = 55;

        Assert.That(actual, Is.EqualTo(expected), "Verify Optiq message count");
    }

    internal static class Optiq
    {
        internal static string Path = System.IO.Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Euronext.Optiq", "Euronext.Optiq.OrderEntryGateway.Sbe.v5.33.xml");
        internal static Specification.Document Fix = Sbe.Optiq.Load.From(Path);
    }
}