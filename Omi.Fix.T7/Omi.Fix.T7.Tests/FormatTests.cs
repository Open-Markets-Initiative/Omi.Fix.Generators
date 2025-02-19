namespace Omi.Fix.T7.Tests;
    using NUnit.Framework;

/// <summary>
///  Regression tests for Eti Fix Formatting
/// </summary>

public class FormatTests
{
    [Test]
    public void VerifyEnumNameTwoWords()
    {
        var actual = T7.Xml.Format.Name("RiskControl");
        var expected = "RiskControl";

        Assert.That(actual, Is.EqualTo(expected), $"Verify T7 text normalization: {actual} to {expected}");
    }

    [Test]
    public void VerifyEnumNameWithSpace()
    {
        var actual = T7.Xml.Format.Name("Service Availability");
        var expected = "ServiceAvailability";

        Assert.That(actual, Is.EqualTo(expected), $"Verify T7 text normalization: {actual} to {expected}");
    }

    [Test]
    public void VerifyEnumNameUnderscoreAbbreviation()
    {
        var actual = T7.Xml.Format.Name("Tradeable_BOC");
        var expected = "TradeableBoc";

        Assert.That(actual, Is.EqualTo(expected), $"Verify T7 text normalization: {actual} to {expected}");
    }
}