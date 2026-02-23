namespace Omi.Fix.Xml.Test;

using NUnit.Framework;

/// <summary>
///  FIXML message property regression tests
/// </summary>

public class MessageTests
{
    [Test]
    public void VerifyFix42FirstMessageProperties()
    {
        var document = Document.From(DocumentTests.LibraryPath("Fix.v4.2.xml"));
        var actual = document.Messages[0];

        var expectedName = "Heartbeat";
        var expectedType = "0";
        var expectedCategory = "admin";

        Assert.That(actual.Name, Is.EqualTo(expectedName), "Verify first message name");
        Assert.That(actual.Type, Is.EqualTo(expectedType), "Verify first message type");
        Assert.That(actual.Category, Is.EqualTo(expectedCategory), "Verify first message category");
    }

    [Test]
    public void VerifyFix42MessageTypeCount()
    {
        var document = Document.From(DocumentTests.LibraryPath("Fix.v4.2.xml"));

        var expected = 46;
        var actual = document.Messages.Types().Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 4.2 message type count");
    }

    [Test]
    public void VerifyFix44MessageTypeCount()
    {
        var document = Document.From(DocumentTests.LibraryPath("Fix.v4.4.xml"));

        var expected = 92;
        var actual = document.Messages.Types().Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fix 4.4 message type count");
    }

    [Test]
    public void VerifyFix50FirstMessageProperties()
    {
        var document = Document.From(DocumentTests.LibraryPath("Fix.v5.0.sp2.xml"));
        var actual = document.Messages[0];

        var expectedName = "IOI";
        var expectedType = "6";
        var expectedCategory = "app";

        Assert.That(actual.Name, Is.EqualTo(expectedName), "Verify Fix 5.0 SP2 first message name");
        Assert.That(actual.Type, Is.EqualTo(expectedType), "Verify Fix 5.0 SP2 first message type");
        Assert.That(actual.Category, Is.EqualTo(expectedCategory), "Verify Fix 5.0 SP2 first message category");
    }

    [Test]
    public void VerifyFix42AdminMessageExists()
    {
        var document = Document.From(DocumentTests.LibraryPath("Fix.v4.2.xml"));

        var actual = document.Messages.FindAll(m => m.Category == "admin").Count;

        Assert.That(actual, Is.GreaterThan(0), "Verify Fix 4.2 has admin messages");
    }

    [Test]
    public void VerifyFix44HasFieldsInMessages()
    {
        var document = Document.From(DocumentTests.LibraryPath("Fix.v4.4.xml"));

        foreach (var message in document.Messages)
        {
            var actual = message.HasFields;

            Assert.That(actual, Is.True, $"Verify message {message.Name} has fields");
        }
    }
}
