namespace Omi.Fix.Fixml.Test {
    using NUnit.Framework;


    public class FilterTests {

        Omi.Fixml.Document document;

        [OneTimeSetUp]
        public void SetUp()
        {
            var path = Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Fixml", "Fix.v5.0.sp2.xml");
            document = Omi.Fixml.Document.From(path);
        }

        [Test]
        public void VerifyFilterComponents() {
            var components = document.Filter(message => message.Name.Equals("ExecutionReport"));

            var expected = 36;
            var actual = document.Components.Count;

            Assert.That(actual, Is.EqualTo(expected), "Document filter incorrectly normalized components");
        }

        [Test]
        public void VerifyFilterFields()
        {
            var components = document.Filter(message => message.Name.Equals("ExecutionAcknowledgement"));

            var expected = 250;
            var actual = document.Fields.Count;

            Assert.That(actual, Is.EqualTo(expected), "Document filter incorrectly normalized fields");
        }
    }
}
