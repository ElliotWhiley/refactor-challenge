using System.Linq;
using Review;
using Xunit;

namespace Tests
{
    public class BirthingUnitTests
    {
        [Fact]
        public void GetPeopleCreatesBirthingUnitMembers()
        {
            var birthingUnit = new BirthingUnit();
            var birthingUnitMembers = birthingUnit.GetPeople(5);
            Assert.True(birthingUnitMembers.Count == 5);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void GetPeopleWithZeroOrLessInputReturnsNoBirthingUnitMembers(int numberOfBirthingUnitMembers)
        {
            var birthingUnit = new BirthingUnit();
            var birthingUnitMembers = birthingUnit.GetPeople(numberOfBirthingUnitMembers);
            Assert.True(birthingUnitMembers.Count == 0);
        }

        [Fact]
        public void GetMarriedReturnsFullName()
        {
            var birthingUnit = new BirthingUnit();
            var person = birthingUnit.GetPeople(1).Single();
            var fullName = person.GetMarried( "Smith");
            Assert.True(fullName == $"{person.Name} Smith");
        }

        [Fact]
        public void GetFullNameTrimsLongNames()
        {
            var birthingUnit = new BirthingUnit();
            var person = birthingUnit.GetPeople(1).Single();
            const string longLastNameWith256Characters = "Loooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo" +
                                                         "ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo" +
                                                         "ooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooooo" +
                                                         "oooooooooooooooooooooong";
            person.GetMarried(longLastNameWith256Characters);
            Assert.True(person.LastName == longLastNameWith256Characters);
            Assert.True(person.GetFullName().Length == 255);
        }

        [Fact]
        public void GetMarriedWithTestLastNameReturnsFirstName()
        {
            var birthingUnit = new BirthingUnit();
            var person = birthingUnit.GetPeople(1).Single();
            var fullName = person.GetMarried("test");
            Assert.True(fullName == person.Name);
        }

        [Fact]
        public void GetMarriedUpdatesLastName()
        {
            var birthingUnit = new BirthingUnit();
            var person = birthingUnit.GetPeople(1).Single();
            person.GetMarried( "Smith");
            Assert.True(person.LastName == "Smith");
            Assert.True(person.GetFullName() == $"{person.Name} Smith");
        }
    }
}