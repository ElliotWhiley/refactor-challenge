using Review;
using Xunit;

namespace Tests
{
    public class PeopleTests
    {
        private const string LongLastNameWith256Characters = "Loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo" +
                                                             "ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo" +
                                                             "ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo" +
                                                             "oooooooooooooooooooooong";

        [Fact]
        public void GetMarriedReturnsFullName()
        {
            var person = new People("Tester");
            var fullName = person.GetMarried( "Smith");
            Assert.True(fullName == $"{person.FirstName} Smith");
        }

        [Fact]
        public void GetFullNameTrimsLongNames()
        {
            var person = new People("Tester");
            person.GetMarried(LongLastNameWith256Characters);
            Assert.True(person.LastName == LongLastNameWith256Characters);
            Assert.True(person.GetFullName().Length == 255);
        }

        [Fact]
        public void GetMarriedWithTestLastNameReturnsFirstName()
        {
            var person = new People("Tester");
            var fullName = person.GetMarried("test");
            Assert.True(fullName == person.FirstName);
        }

        [Fact]
        public void GetMarriedUpdatesLastName()
        {
            var person = new People("Tester");
            person.GetMarried( "Smith");
            Assert.True(person.LastName == "Smith");
            Assert.True(person.GetFullName() == $"{person.FirstName} Smith");
        }
    }
}
