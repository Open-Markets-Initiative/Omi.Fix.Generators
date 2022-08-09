namespace Omi.Fix.Fixml.Test
{
    public class FixmlTests
    {

        [Test]
        public void VerifyReadingInvalidFixmlThrowsException() {

            Assert.Throws<ArgumentOutOfRangeException>(() => Omi.Fixml.Document.From(@".\SampleInput\fixmlmissingrequired.xml"), "Verify Line missing type is invalid");
        }
    }
}