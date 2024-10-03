namespace Omi.Fix.Fixml.Test;
    using NUnit.Framework;


public class FilterTests
{

    [Test]
    public void VerifyFilterComponents()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Fixml", "Fix.v5.0.sp2.xml");
        Omi.Fixml.Document document = Omi.Fixml.Document.From(path);

        var components = document.Filter(message => message.Name.Equals("ExecutionReport"));

        var expected = 49;
        var actual = document.Components.Count;

        Assert.That(actual, Is.EqualTo(expected), "Document filter incorrectly normalized components");
    }

    [Test]
    public void VerifyFilterFields()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Fixml", "Fix.v5.0.sp2.xml");
        Omi.Fixml.Document document = Omi.Fixml.Document.From(path);

        var fields = document.Filter(message => message.Name.Equals("ExecutionAcknowledgement"));

        var expected = 275;
        var actual = document.Fields.Count;

        Assert.That(actual, Is.EqualTo(expected), "Document filter incorrectly normalized fields");
    }
}
