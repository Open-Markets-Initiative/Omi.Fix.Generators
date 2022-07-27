namespace Omi.Fix.Fixml.Test
{
    public class FixmlTests
    {

        [Test]
        public void VerifyReadingInvalidFixmlThrowsException() {

            Assert.Throws<ArgumentOutOfRangeException>(() => Omi.Fixml.Document.From(@"D:\git_users\Sophia\Omi.Fix.Generators\Omi.Fix.Fixml.Test\SampleInput\fixmlmissingrequired.xml"), "Verify Line missing type is invalid");
        }
    }
}