namespace Omi.Fix.Txt.Test
{
    public class MessageTests
    {


        [Test]
        public void VerifyChildrenFromGroups() {

            var expected = Children.From("AllocAccount(required), AllocShares");
            var actual = new Children();
            actual.Add(new Group { Name = "AllocAccount", Required = true });
            actual.Add(new Group { Name = "AllocShares", Required = false });

            Assert.AreEqual(expected[1].Name, actual[1].Name, "Verify children from string");
        }

        [Test]
        public void VerifyGroupFromString() {

            var expected = Group.From("ClOrdID(required)");
            var actual = new Group { Name = "ClOrdID", Required = true };

            Assert.AreEqual(expected.Name, actual.Name, "Verify group from string" );
        }

        [Test]
        public void VerifyChildrenFromLine() {

            var groups = Groups.From("ClOrdID(required), ClientID, ExecBroker, Account, NoAllocs(required)[AllocAccount(required), AllocShares]");
            
            var expected = groups[4].Children[1].Name;
            var actual = "AllocShares";

            Assert.AreEqual(expected, actual, "Verify children correctly read in from line");
        }

        [Test]
        public void VerifyMessageFromPath() {

            var messages = Messages.From(@".\SampleInputs\messages1.txt");

            var specification = messages[0].ToSpecification();

            var expected = specification.Fields[4].Children[1].Name;

            var actual = "AllocShares";

            Assert.AreEqual(expected, actual, "Verify children read in from text file");
        }

        [Test]
        public void VerifyInvalidMessageFromLine()
        {
            Assert.Throws<IndexOutOfRangeException>(() => Messages.From(new List<string> { "NewOrderSingle:admin:D: ClOrdID(required), ClientID, ExecBroker, Account, NoAllocs(required)[AllocAccount(required), AllocShares" }), "Verify Line missing type is invalid");
        }

    }
}