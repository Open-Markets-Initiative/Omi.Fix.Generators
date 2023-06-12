namespace Omi.Fix.Fixml.Test
{
    using NUnit.Framework;

    public class LibraryTests
    {

        [Test]
        public void VerifyFixmlXmls() {

            var actual = Omi.Fixml.Library.Xmls().Count;
            var expected = 3;

            Assert.That(actual, Is.EqualTo(expected), "Verify Fixml library count");
        }
        /*
                [Test]
                public void VerifyReadingInvalidFixmlThrowsException() {

                    Assert.Throws<ArgumentOutOfRangeException>(() => Omi.Fixml.Document.From(@".\SampleInput\fixmlmissingrequired.xml"), "Verify Line missing type is invalid");
                }
            }
        */
    }

}