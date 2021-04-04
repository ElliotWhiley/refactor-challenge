using System.Linq;
using CodingAssessment.Review;
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
            var fullName = birthingUnit.GetMarried(person, "Smith");
            Assert.True(fullName == $"{person.Name} Smith");
        }

        [Fact]
        public void GetMarriedWithTestLastNameReturnsFirstName()
        {
            var birthingUnit = new BirthingUnit();
            var person = birthingUnit.GetPeople(1).Single();
            var fullName = birthingUnit.GetMarried(person, "test");
            Assert.True(fullName == person.Name);
        }
    }
}