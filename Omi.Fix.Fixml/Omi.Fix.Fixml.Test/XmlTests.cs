using NUnit.Framework;
using System.IO;
using System.Xml;
namespace Omi.Fix.Fixml.Test;

/// <summary>
/// Fixml Document Xml Generation regression tests
/// </summary>
public class XmlTests
{
    private XmlElement root;

    [OneTimeSetUp]
    public void Setup() {
        var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Fixml", "Fix.v4.4.xml");
        var document = Omi.Fixml.Document.From(path).GenerateXml();
        root = document.DocumentElement;
    }
    [Test]
    public void VerifyHeaderElementCount() {
        var expected = 30;
        var actual = 0;
        var headerElement = root.ChildNodes.Item(0);
        foreach(XmlNode element in headerElement) 
        {
            actual += (1 + element.ChildNodes.Count);
        }
        Assert.That(actual, Is.EqualTo(expected), "Incorrect Xml Header elements count");
    }

    [Test]
    public void VerifyTrailerElementCount() {
        var expected = 3;
        var actual = 0;
        var trailerElement = root.ChildNodes.Item(1);
        foreach (XmlNode element in trailerElement) {
            actual += (1 + element.ChildNodes.Count);
        }
        Assert.That(actual, Is.EqualTo(expected),"Incorrect Xml Trailer elements count");
    }

    [Test]
    public void VerifyMessageElementCount() {
        var expected = 92;
        var messagesElement = root.ChildNodes.Item(2);
        var actual = messagesElement.ChildNodes.Count;
        Assert.That(actual, Is.EqualTo(expected), "Incorrect Xml Message elements count");
    }

    [Test]
    public void VerifyComponentsElementCount() {
        var expected = 24;
        var componentsElement = root.ChildNodes.Item(3);
        var actual = componentsElement.ChildNodes.Count;
        Assert.That(actual, Is.EqualTo(expected), "Incorrect Xml Components elements count");
    }

    [Test]
    public void VerifyFieldElementCount() {
        var expected = 919;
        var fieldsElement = root.ChildNodes.Item(4);
        var actual = fieldsElement.ChildNodes.Count;
        Assert.That(actual, Is.EqualTo(expected), "Incorrect Xml Fields elements count");
    }
}
