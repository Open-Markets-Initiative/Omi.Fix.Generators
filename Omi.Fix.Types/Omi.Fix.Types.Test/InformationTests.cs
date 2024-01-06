namespace Omi.Fix.Types.Test{
    using NUnit.Framework;
    public class InformationTests
    {
        [Test]
        public void VerifyInformationMajor() {
            var actual = Library.Fix42.Information.Major;
            var expected = string.Empty;

            Assert.That(actual, Is.EqualTo(expected), "Verify fix major version");  
        }

        [Test] 
        public void VerifyInformationMinor() {
            var actual = Library.Fix42.Information.Minor;
            var expected = string.Empty;

            Assert.That(actual, Is.EqualTo(expected), "Verify fix minor version");
        }

        [Test]
        public void VerifyInformationSource() {
            var actual = Library.Fix42.Information.Source;
            var expected = "Library\\Fields\\Fix42.Fields.xml";

            Assert.That(actual, Is.EqualTo(expected), "Verify fix source");
        }
    }
}
