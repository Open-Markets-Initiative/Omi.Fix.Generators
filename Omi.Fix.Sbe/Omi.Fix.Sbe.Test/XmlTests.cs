namespace Omi.Fix.Sbe.Test {
    using NUnit.Framework;
    using Omi.Fix.Sbe.Library;
    using Omi.Fix.Sbe.Xml;

    public class XmlTests {

        messageSchema message;

        [OneTimeSetUp] 
        public void SetUp() {
            message = Xml.Load.SbeXmlFrom(Path.Combine(TestContext.CurrentContext.TestDirectory, "Library", "Cme.iLink3", "Cme.Futures.iLink3.Sbe.v8.2.xml"));

        }

        [Test]
        public void VerifymessageSchemaPackage() {
            var actual = message.package;
            var expected = "iLinkBinary";

            Assert.That(actual, Is.EqualTo(expected), "Verify messageSchema package field");
        }

        [Test]
        public void VerifymessageSchemaId() {
            var actual = message.id;
            var expected = 8;

            Assert.That(actual, Is.EqualTo(expected), "Verify messageSchema id field");
        }

        [Test]
        public void VerifymessageSchemaVersion() {
            var actual = message.version;
            var expected = 2;

            Assert.That(actual, Is.EqualTo(expected), "Verify messageSchema version field");
        }

        [Test]
        public void VerifymessageSchemaSemanticVersion() {
            var actual = message.semanticVersion;
            var expected = "FIX5.0";

            Assert.That(actual, Is.EqualTo(expected), "Verify messageSchema id field");
        }

        [Test]
        public void VerifymessageSchemaDescription() {
            var actual = message.description;
            var expected = 20191105;

            Assert.That(actual, Is.EqualTo(expected), "Verify messageSchema description field");
        }
        [Test]
        public void VerifymessageSchemaByteOrder() {
            var actual = message.byteOrder;
            var expected = "littleEndian";

            Assert.That(actual, Is.EqualTo(expected), "Verify messageSchema byteOrder field");
        }
    }
}
