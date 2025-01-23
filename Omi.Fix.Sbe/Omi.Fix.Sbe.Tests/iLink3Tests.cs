namespace Omi.Fix.Sbe.Test;
using NUnit.Framework;

/// <summary>
///  Regression tests for iLink3 Sbe
/// </summary>

public class iLink3Tests {

    [Test]
    public void VerifyFixSpecificationMessageCount()
    {
        var actual = iLink3.Fix.Messages.Count;
        var expected = 48;

        Assert.That(actual, Is.EqualTo(expected), "Verify iLink3 message count");
    }

    internal static class iLink3
    {
        internal static string Path = System.IO.Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Cme.iLink3", "Cme.Futures.iLink3.Sbe.v8.2.xml");
        internal static Specification.Document Fix = Sbe.iLink3.Load.From(Path);
    }
}