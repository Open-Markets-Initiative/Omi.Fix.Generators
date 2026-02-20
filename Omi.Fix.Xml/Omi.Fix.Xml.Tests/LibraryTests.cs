namespace Omi.Fix.Xml.Test;
    using NUnit.Framework;

/// <summary>
///  Fixml Library regression tests
/// </summary>

public class LibraryTests
{
    [Test]
    public void VerifyFixmlCount()
    {
        var directory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Xml");
        var files = Directory.GetFiles(directory, "*.xml");
        var xmls = new List<Omi.Fix.Xml.Xml.fix>();
        foreach (var file in files ?? Array.Empty<string>())
        {
            xmls.Add(Omi.Fix.Xml.Load.From(file));
        }
        var actual = xmls.Count;
        var expected = 3;

        Assert.That(actual, Is.EqualTo(expected), "Verify Fixml library count");
    }

    /*
            [Test]
            public void VerifyReadingInvalidFixmlThrowsException() {

                Assert.Throws<ArgumentOutOfRangeException>(() => Omi.Fix.Xml.Document.From(@".\SampleInput\fixmlmissingrequired.xml"), "Verify Line missing type is invalid");
            }
        }
    */
}