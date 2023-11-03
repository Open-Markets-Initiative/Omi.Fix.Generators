namespace Omi.Fix.Txt.Test {
    using NUnit.Framework;

    /// <summary>
    ///  Fix Txt Message Regression tests 
    /// </summary>

    public class MessageTests {
        [Test]
        public void VerifyChildrenFromGroups() {
            var expected = new Children {
                new Group { Name = "AllocAccount", Required = true },
                new Group { Name = "AllocShares", Required = false }
            };
            var actual = Children.From("AllocAccount(required), AllocShares");

            Assert.That(actual[1].Name, Is.EqualTo(expected[1].Name), "Verify group children from record");
        }

        [Test]
        public void VerifyGroupFromString() {
            var expected = Group.From("ClOrdID(required)");
            var actual = new Group { Name = "ClOrdID", Required = true };

            Assert.That(actual.Name, Is.EqualTo(expected.Name), "Verify group from string" );
        }

        [Test]
        public void VerifyChildrenFromLine() {
            var groups = Groups.From("ClOrdID(required), ClientID, ExecBroker, Account, NoAllocs(required)[AllocAccount(required), AllocShares]");
            
            var expected = groups[4].Children[1].Name;
            var actual = "AllocShares";

            Assert.That(actual, Is.EqualTo(expected), "Verify children correctly read in from line");
        }

        [Test]
        public void VerifyMessageFromPath() {

            var messages = Messages.From(@".\SampleInputs\messages1.txt");
            var specification = messages[0].ToSpecification();

            var expected = specification.Fields[4].Children[1].Name;
            var actual = "AllocShares";

            Assert.That(actual, Is.EqualTo(expected), "Verify children read in from text file");
        }

        [Test]
        public void VerifyInvalidMessageFromLine() {
            Assert.Throws<IndexOutOfRangeException>(() => Messages.From(new List<string> { "NewOrderSingle:admin:D: ClOrdID(required), ClientID, ExecBroker, Account, NoAllocs(required)[AllocAccount(required), AllocShares" }), "Verify Line missing type is invalid");
        }
    }
}