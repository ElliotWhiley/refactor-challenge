using System;
using Moq;
using Review;
using Xunit;

namespace Tests
{
    public class PeopleTests
    {
        private readonly Mock<IClock> _fakeClock;
        private const string LongLastNameWith256Characters = "Loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo" +
                                                             "ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo" +
                                                             "ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo" +
                                                             "oooooooooooooooooooooong";
        
        public PeopleTests()
        {
            _fakeClock = new Mock<IClock>();
            _fakeClock.Setup(x => x.FifteenYearsAgo()).Returns(new DateTime(1985, 1, 1));
        }

        [Fact]
        public void GetMarriedReturnsFullName()
        {
            var person = new People("Tester", _fakeClock.Object);
            var fullName = person.GetMarried( "Smith");
            Assert.True(fullName == $"{person.FirstName} Smith");
        }

        [Fact]
        public void GetFullNameTrimsLongNames()
        {
            var person = new People("Tester", _fakeClock.Object);
            person.GetMarried(LongLastNameWith256Characters);
            Assert.True(person.LastName == LongLastNameWith256Characters);
            Assert.True(person.GetFullName().Length == 255);
        }

        [Fact]
        public void GetMarriedWithTestLastNameReturnsFirstName()
        {
            var person = new People("Tester", _fakeClock.Object);
            var fullName = person.GetMarried("test");
            Assert.True(fullName == person.FirstName);
        }

        [Fact]
        public void GetMarriedUpdatesLastName()
        {
            var person = new People("Tester", _fakeClock.Object);
            person.GetMarried( "Smith");
            Assert.True(person.LastName == "Smith");
            Assert.True(person.GetFullName() == $"{person.FirstName} Smith");
        }

        [Fact]
        public void PeopleHaveDefaultAgeOfFifteen()
        {
            var person = new People("Tester", _fakeClock.Object);
            Assert.True(person.DateOfBirth == new DateTime(1985, 1, 1));
        }
    }
}
