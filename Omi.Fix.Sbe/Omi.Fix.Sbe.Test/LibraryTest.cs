namespace Omi.Fix.Sbe.Test {
    using NUnit.Framework;

    /// <summary>
    ///  Regression tests for Sbe Fix Librarys
    /// </summary>

    public class LibraryTests {

        List<Xml.messageSchema> xmls;

        [OneTimeSetUp]
        public void Setup()
        {
            var directory = Path.Combine(TestContext.CurrentContext.TestDirectory, "Library","Cme.iLink3");
            var files = Directory.GetFiles(directory, "*.xml");
            xmls = new List<Xml.messageSchema>();

            foreach (var file in files ?? Array.Empty<string>())
            {
                xmls.Add(Xml.Load.SbeXmlFrom(file));
            }
        }

        [Test]
        public void VerifyiLink3Xmls() {

            var actual = xmls.Count;
            var expected = 7;

            Assert.That(actual, Is.EqualTo(expected), "Verify iLink3 library count");
        }
    }
}