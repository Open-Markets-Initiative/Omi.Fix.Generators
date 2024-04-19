namespace Omi.Fix.Fixml.Test;
    using NUnit.Framework;

/// <summary>
///  Fixml Error regression tests
/// </summary>

public class ErrorTests {

    [Test]
    public void VerifyFixmlMissingFromMessage() {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.2.MissingFromMessage.xml");
        var document = Omi.Fixml.Document.From(path);

        var expected = "TestReqID: Field is missing from dictionary";
        var actual = document.Errors.First();

        Assert.That(expected, Is.EqualTo(actual), "Verify Missing Field From Message is Identified");
    }

    [Test]
    public void VerifyFixmlMissingFromHeader() {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.2.MissingFromHeader.xml");
        var document = Omi.Fixml.Document.From(path);

        var expected = "SecureDataLen: Field is missing from dictionary";
        var actual = document.Errors.First();

        Assert.That(expected, Is.EqualTo(actual), "Verify Missing Field From Header is Identified ");
    }

    [Test]
    public void VerifyFixmlMissingFromTrailer() {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.2.MissingFromTrailer.xml");
        var document = Omi.Fixml.Document.From(path);

        var expected = "CheckSum: Field is missing from dictionary";
        var actual = document.Errors.First();

        Assert.That(expected, Is.EqualTo(actual), "Verify Missing Field from Trailer is Identified");
    }

    [Test]
    public void VerifyFixmlErrorFromDuplicateMessageTags() {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.2.DuplicateMessageTags.xml");
        var document = Omi.Fixml.Document.From(path);

        var expected = "ClientID : Tag occurs more than once in message";
        var actual = document.Errors.First();

        Assert.That(expected, Is.EqualTo(actual), "Verify Duplicate Tags in Message are Identified ");
    }

    [Test]
    public void VerifyFixmlErrorFromDuplicateHeaderTags() {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.2.DuplicateHeaderTags.xml");
        var document = Omi.Fixml.Document.From(path);

        var expected = "MsgType : Tag occurs more than once in header";
        var actual = document.Errors.First();

        Assert.That(expected, Is.EqualTo(actual), "Verify Duplicate Tags in Header are Identified");
    }

    [Test]
    public void VerifyFixmlErrorFromDuplicateTrailerTags() {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.2.DuplicateTrailerTags.xml");
        var document = Omi.Fixml.Document.From(path);

        var expected = "SignatureLength : Tag occurs more than once in trailer";
        var actual = document.Errors.First();

        Assert.That(expected, Is.EqualTo(actual), "Verify Duplicate Tags in Trailer are Identified ");
    }
}