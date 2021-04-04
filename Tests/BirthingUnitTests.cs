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
    }
}