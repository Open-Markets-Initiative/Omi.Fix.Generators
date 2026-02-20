namespace Omi.Fix.Sbe.Test;

using NUnit.Framework;

/// <summary>
///  Regression tests for Sbe Fix Formatting
/// </summary>

public class FormatTests
{
    [Test]
    public void VerifyFormatMultipleWords()
    {
        var actual = Sbe.Format.Name("Accept Security Proposal as is");
        var expected = "AcceptSecurityProposalAsIs";

        Assert.That(actual, Is.EqualTo(expected), $"Verify Sbe text normalization: {actual} to {expected}");
    }

    [Test]
    public void VerifyFormatNameFix()
    {
        var actual = Sbe.Format.Name("OrigCIOrdID");
        var expected = "OrigCiOrdId";

        Assert.That(actual, Is.EqualTo(expected), $"Verify Sbe text normalization: {actual} to {expected}");
    }
}