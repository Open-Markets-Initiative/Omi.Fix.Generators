namespace Omi.Fix.Fixml.Test {
    using NUnit.Framework;
    public class FilterTests {

        [Test]
        public void VerifyFilterComponents() {
            var document = Omi.Fixml.Library.Fix50;
            var components = document.Filter(message => message.Name.Equals("ExecutionReport"));

            var expected = 36;
            var actual = document.Components.Count;

            Assert.That(actual, Is.EqualTo(expected), "Document filter incorrectly normalized components");
        }

        [Test]
        public void VerifyFilterFields()
        {
            var document = Omi.Fixml.Library.Fix50;
            var components = document.Filter(message => message.Name.Equals("ExecutionAcknowledgement"));

            var expected = 250;
            var actual = document.Fields.Count;

            Assert.That(actual, Is.EqualTo(expected), "Document filter incorrectly normalized fields");
        }
    }
}
