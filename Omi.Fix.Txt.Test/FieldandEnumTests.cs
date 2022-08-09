namespace Omi.Fix.Txt.Test
{
    public class FieldandEnumTests
    {


        [Test]
        public void VerifyEnumsFromPath() {

            var expected = Enums.From(@".\SampleInputs\enums1.txt")["Bool"].Values[1].Data;

            var actual = "N";
            Assert.AreEqual(expected, actual, "Verify enums correctly formed from path");  
        }

        [Test]
        public void VerifyEnumsFromLines() {

            var expected = Enums.From(new List<string> { "ExecTransType:enum:New=0,Cancel=1,Correct=2,Status=3" })["ExecTransType"].Values[0].Data;
            var actual = "0";
            Assert.AreEqual(expected, actual, "Verify enums correctly formed from path");
        }

        [Test]
        public void VerifyEnumsExcludesComments() {

            var expected = Enums.From(new List<string> { "# This is a comment " });
            
            Assert.IsEmpty(expected, "verify comments do not get read as enums");
        }

        [Test]
        public void VerifyEnumNameFromLine() {

            var expected = Enum.From("ExecTransType:enum:New=0,Cancel=1,Correct=2,Status=3").Name;
            var actual = "ExecTransType";

            Assert.AreEqual(expected, actual, "Verify enum Name correctly formed from line");
        }

        [Test]
        public void VerifyEnumValueFromLine() {

            var expected = Enum.From("ExecTransType:enum:New=0,Cancel=1,Correct=2,Status=3").Values[2].Data;
            var actual = "2";

            Assert.AreEqual(expected, actual, "Verify enum Value correctly formed from line");
        }

        [Test]
        public void VerifyFieldNumberFromLine() {

            var expected = Field.NumberFrom("1:Account:string");
            var actual = "1";

            Assert.AreEqual(expected, actual, "Verify field number from line");
        }

        [Test]
        public void VerifyFieldNameFromLine()
        {

            var expected = Field.NameFrom("1:Account:string");
            var actual = "Account";

            Assert.AreEqual(expected, actual, "Verify field name from line");
        }

        [Test]
        public void VerifyFieldTypeFromLine()
        {

            var expected = Field.TypeFrom("1:Account:string", new Enums());
            var actual = "string";

            Assert.AreEqual(expected, actual, "Verify field type from line");
        }

        [Test]
        public void VerifyInvalidLineThrowsError()
        {

            Assert.Throws<ArgumentException>( () => Field.From("1:Account:", new Enums()), "Verify Line missing type is invalid");
        }

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
    }
}