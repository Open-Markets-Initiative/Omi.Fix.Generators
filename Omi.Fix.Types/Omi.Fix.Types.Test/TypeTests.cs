namespace Omi.Fix.Types.Test{
    using NUnit.Framework;

    public class TypeTests {

        Type Account;

        [OneTimeSetUp] 
        public void SetUp() {
            Account = Library.Fix42.Fields["Account"];
        }

        [Test]
        public void VerifyDataTypeFromTypes() {
            var actual = Account.DataType;
            var expected = "String";

            Assert.That(actual, Is.EqualTo(expected), "Incorrect DataType from Types");
        }

        [Test]
        public void VerifyVersionFromTypes() {
            var actual = Account.Version;
            var expected = "FIX42";

            Assert.That(actual, Is.EqualTo(expected), "Incorrect Version from Types");
        }

        [Test]
        public void VerifyNameFromTypes() {
            var actual = Account.Name;
            var expected = "Account";

            Assert.That(actual, Is.EqualTo(expected), "Incorrect Name from Types");
        }

        [Test]
        public void VerifyTagFromTypes() {
            var actual = Account.Tag;
            var expected = 1;

            Assert.That(actual, Is.EqualTo(expected), "Incorrect Tag from Types");
        }

        [Test]
        public void VerifyIsEnumFromTypes() {
            var actual = Account.IsEnum;
            var expected = false;

            Assert.That(actual, Is.EqualTo(expected), "Incorrect IsEnum from Types");
        }

        [Test]
        public void VerifyDescriptionFromTypes() {
            var actual = Account.Description;
            var expected = "Account mnemonic as agreed between broker and institution.";

            Assert.That(actual, Is.EqualTo(expected), "Verify FIX Types XML element description");
        }
    }
}
