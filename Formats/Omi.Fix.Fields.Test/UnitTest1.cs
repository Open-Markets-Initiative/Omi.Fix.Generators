namespace Omi.Fix.Fields.Test {
    using NUnit.Framework;

    /// <summary>
    ///  Fix Fields Regression Tests
    /// </summary>

    public class LibraryTests {

        [Test]
        public void VerifyFieldsXmlsCount() {
            var actual = Omi.Fix.Fields.Library.Xmls().Count;
            var expected = 1;

            Assert.That(actual, Is.EqualTo(expected), "Verify Fix Fields library count");
        }
    }
}