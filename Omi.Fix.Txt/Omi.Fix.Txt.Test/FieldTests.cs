namespace Omi.Fix.Txt.Test {
    using NUnit.Framework;

    /// <summary>
    ///  Regression tests for fix txt fields
    /// </summary>

    public class FieldTests {

        [Test]
        public void VerifyFieldNumberFromLine() {
            var expected = Field.NumberFrom("1:Account:string");
            var actual = "1";

            Assert.That(actual, Is.EqualTo(expected), "Verify field number from line");
        }

        [Test]
        public void VerifyFieldNameFromLine() {
            var expected = "Account";
            var actual = Field.NameFrom("1:Account:string");

            Assert.That(actual, Is.EqualTo(expected), "Verify field name from line");
        }

        [Test]
        public void VerifyFieldTypeStringFromLine() {
            var expected = "String";
            var actual = Field.TypeFrom("1:Account:string", new Enums());

            Assert.That(actual, Is.EqualTo(expected), "Verify field type String from line");
        }

        [Test]
        public void VerifyFieldTypeCommentFromLine()
        {
            var expected = Field.From("1:Account:string", new Enums()).ToString();
            var actual = Field.From("1:Account:string #Comment", new Enums()).ToString();

            Assert.That(actual, Is.EqualTo(expected), "Verify field comment from line");
        }


        [Test]
        public void VerifyInvalidLineThrowsError()
        {
            Assert.Throws<ArgumentException>(() => Field.From("1:Account:", new Enums()), "Verify Line missing type is invalid");
        }

        /*

        [Test]
        public void VerifyFieldsAndEnumsBuiltinParallel() {

            var text = Fields.From(@".\SampleInputs\fieldandenums1.txt");
            var specification = text.ToSpecification(Enums.From(@".\SampleInputs\fieldandenums1.txt"));

            var expected = specification["ExecTransType"].Enums[2].Description;
            var actual = "Correct";

            Assert.AreEqual(expected, actual, "Verify field matches enums in specification from text");
        }

        [Test]
        public void VerifyFieldsAndEnumsBuiltinParallelNoEnums() {

            var text = Fields.From(new List<string> { "14:CumQty:qty" });
            var specification = text.ToSpecification(new Enums());

            var expected = specification["CumQty"].Enums;

            Assert.IsEmpty(expected, "verify empty enums for field without a match");
        }

         */
    }
}