namespace Omi.Fix.Xml.Test;
    using NUnit.Framework;

/// <summary>
///  Fixml Error regression tests
/// </summary>

public class ErrorTests 
{

    [Test]
    public void VerifyFixmlMissingFromMessage() 
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.2.MissingFromMessage.xml");
        var document = Omi.Fix.Xml.Document.From(path);

        var expected = "TestReqID: Field is missing from dictionary";
        var actual = document.Errors.First();

        Assert.That(expected, Is.EqualTo(actual), "Verify Missing Field From Message is Identified");
    }

    [Test]
    public void VerifyFixmlMissingFromHeader() 
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.2.MissingFromHeader.xml");
        var document = Omi.Fix.Xml.Document.From(path);

        var expected = "SecureDataLen: Field is missing from dictionary";
        var actual = document.Errors.First();

        Assert.That(expected, Is.EqualTo(actual), "Verify Missing Field From Header is Identified ");
    }

    [Test]
    public void VerifyFixmlMissingFromTrailer() 
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.2.MissingFromTrailer.xml");
        var document = Omi.Fix.Xml.Document.From(path);

        var expected = "CheckSum: Field is missing from dictionary";
        var actual = document.Errors.First();

        Assert.That(expected, Is.EqualTo(actual), "Verify Missing Field from Trailer is Identified");
    }

    [Test]
    public void VerifyFixmlErrorFromDuplicateMessageTags() 
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.2.DuplicateMessageTags.xml");
        var document = Omi.Fix.Xml.Document.From(path);

        var expected = "ClientID : Tag occurs more than once in message";
        var actual = document.Errors.First();

        Assert.That(expected, Is.EqualTo(actual), "Verify Duplicate Tags in Message are Identified ");
    }

    [Test]
    public void VerifyFixmlErrorFromDuplicateHeaderTags() 
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.2.DuplicateHeaderTags.xml");
        var document = Omi.Fix.Xml.Document.From(path);

        var expected = "MsgType : Tag occurs more than once in header";
        var actual = document.Errors.First();

        Assert.That(expected, Is.EqualTo(actual), "Verify Duplicate Tags in Header are Identified");
    }

    [Test]
    public void VerifyFixmlErrorFromDuplicateTrailerTags() 
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.2.DuplicateTrailerTags.xml");
        var document = Omi.Fix.Xml.Document.From(path);

        var expected = "SignatureLength : Tag occurs more than once in trailer";
        var actual = document.Errors.First();

        Assert.That(expected, Is.EqualTo(actual), "Verify Duplicate Tags in Trailer are Identified ");
    }

    [Test]
    public void VerifyGatherComponents()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.4.ShortDefinition.xml");
        var document = Omi.Fix.Xml.Document.From(path);

        var actual = document.GatherComponents();

        var expected = new HashSet<string> {
            "Component1",
            "Component2",
            "Component3",
            "Component4",
            "Component5"
        };

        Assert.That(actual, Is.EquivalentTo(expected), "Document Gathered in-use components improperly");
    }

    [Test]
    public void VerifyTripleNestedComponentWithDeletingMiddleComponent()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.4.ShortDefinition.xml");
        var document = Omi.Fix.Xml.Document.From(path);

        document.Components.Remove("Component2");

        var actual = document.GatherComponents();

        var expected = new HashSet<string>();
        expected.UnionWith(new[] {
            "Component1",
            "Component4",
            "Component5"
        });

        Assert.That(actual, Is.EquivalentTo(expected), "Document Gathered in-use components improperly after removal");
    }

    [Test]
    public void VerifyGatherFields()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.4.ShortDefinition.xml");
        var document = Omi.Fix.Xml.Document.From(path);

        var actual = document.GatherFields();

        var expected = new HashSet<string>();
        expected.UnionWith(new[] {
            "BeginString",
            "MsgType",
            "CheckSum",
            "AdvId",
            "NoLegs",
            "LegIOIQty",
            "OrderQty",
            "Account",
            "SendingTime",
            "SecurityDesc"
        });

        Assert.That(actual, Is.EquivalentTo(expected), "Document Gathered in-use fields improperly");
    }

    [Test]
    public void VerifyFieldMissingFromDictionary()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.4.MissingFieldDefinition.xml");
        var document = Omi.Fix.Xml.Document.From(path);

        var actual = document.Errors;

        var expected = new List<string>
        {
            "AdvId: Field is missing from dictionary",
            "SecurityDesc: Field is missing from dictionary",
            "LegIOIQty: Field is missing from dictionary"
        };

        Assert.That(actual, Is.EquivalentTo(expected), "Document identified missing field definition improperly.");
    }

    [Test]
    public void VerifyComponentMissingFromDictionary()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Fixmls", "Fix.v4.4.MissingComponentDefinition.xml");
        var document = Omi.Fix.Xml.Document.From(path);

        var actual = document.Errors;

        var expected = new List<string>
        {
            "Component0: Component is missing from dictionary",
            "Component3: Component is missing from dictionary",
            "Component4: Component is missing from dictionary"
        };

        Assert.That(actual, Is.EquivalentTo(expected), "Document identified missing component definition improperly.");
    }
}