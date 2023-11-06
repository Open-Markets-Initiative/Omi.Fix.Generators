namespace Omi.Fix.Txt.Test {
    using NUnit.Framework;

    /// <summary>
    ///  Regression tests for fix text field records
    /// </summary>

    public class FieldTests {

        [Test]
        public void VerifyFieldNumberFromLine() {
            var field = Field.From("1:Account:string", new Enums());

            var expected = "1";
            var actual = field.Number;

            Assert.That(actual, Is.EqualTo(expected), "Verify field tag number from text record");
        }

        [Test]
        public void VerifyFieldNameFromLine() {
            var field = Field.From("1:Account:string", new Enums());

            var expected = "Account";
            var actual = field.Name;

            Assert.That(actual, Is.EqualTo(expected), "Verify field name from text record");
        }

        [Test]
        public void VerifyFieldTypeStringFromLine() {
            var field = Field.From("1:Account:string", new Enums());

            var expected = "String";
            var actual = field.Type;

            Assert.That(actual, Is.EqualTo(expected), "Verify field type from text record (String)");
        }

        [Test]
        public void VerifyFieldTypeCommentFromLine() {
            var expected = Field.From("1:Account:string", new Enums()).ToString();
            var actual = Field.From("1:Account:string #Comment", new Enums()).ToString();

            Assert.That(actual, Is.EqualTo(expected), "Verify field comments are trimmed for text record");
        }

        [Test]
        public void VerifyInvalidLineThrowsError()
            => Assert.Throws<ArgumentException>(() => Field.From("1:Account:", new Enums()), "Verify Line missing type is invalid");
    }
}