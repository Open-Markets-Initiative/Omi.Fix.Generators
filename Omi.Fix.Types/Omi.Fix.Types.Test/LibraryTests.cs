namespace Omi.Fix.Types.Test {
    using NUnit.Framework;

    /// <summary>
    ///  Fix Types Regression Tests
    /// </summary>

    public class LibraryTests {

        [Test]
        public void VerifyFieldsXmlsCount() {

            var directory = Path.Combine(Directory.GetCurrentDirectory(), "Library\\Fields");
            var files = Directory.GetFiles(directory, "*.xml");

            var xmls = new List<Xml.FixFields>();
            foreach (var file in files ?? Array.Empty<string>())
            {
                xmls.Add(Load.FieldsXmlFrom(file));
            }

            var actual = xmls.Count;
            var expected = 1;

            Assert.That(actual, Is.EqualTo(expected), "Verify Fix Types library count");
        }
    }
}