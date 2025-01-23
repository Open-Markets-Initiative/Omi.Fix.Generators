namespace Omi.Fix.Fixml.Test;
    using NUnit.Framework;

/// <summary>
///  FIXML filter regression tests 
/// </summary>

public class FilterTests
{
    [Test]
    public void VerifyFilterComponents()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Fixml", "Fix.v5.0.sp2.xml");
        var original = Omi.Fixml.Document.From(path);
        var filtered = original.Filter(message => message.Name.Equals("ExecutionReport"));

        var expected = 49;
        var actual = filtered.Components.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify FIXML components after filter");
    }

    [Test]
    public void VerifyFilterFields()
    {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Fixml", "Fix.v5.0.sp2.xml");
        var original = Omi.Fixml.Document.From(path);
        var filtered = original.Filter(message => message.Name.Equals("ExecutionAcknowledgement"));

        var expected = 275;
        var actual = filtered.Fields.Count;

        Assert.That(actual, Is.EqualTo(expected), "Verify FIXML fields after filter");
    }
}
