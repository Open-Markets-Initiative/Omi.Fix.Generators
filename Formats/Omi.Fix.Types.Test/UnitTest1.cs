namespace Omi.Fix.Types.Test {
    using NUnit.Framework;

    /// <summary>
    ///  Fix Types Regression Tests
    /// </summary>

    public class LibraryTests {

        [Test]
        public void VerifyFieldsXmlsCount() {
            var actual = Omi.Fix.Types.Library.Xmls().Count;
            var expected = 1;

            Assert.That(actual, Is.EqualTo(expected), "Verify Fix Types library count");
        }
    }
}