using Moq;
using Review;
using Xunit;

namespace Tests
{
    public class BirthingUnitTests
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;

        public BirthingUnitTests()
        {
            var randomNumberGeneratorMock = new Mock<IRandomNumberGenerator>();
            randomNumberGeneratorMock.Setup(x => x.GenerateRandomNumber(It.IsAny<int>(), It.IsAny<int>())).Returns(0);
            _randomNumberGenerator = randomNumberGeneratorMock.Object;
        }

        [Fact]
        public void GetPeopleCreatesBirthingUnitMembersWithNames()
        {
            var birthingUnit = new BirthingUnit(_randomNumberGenerator);
            var birthingUnitMembers = birthingUnit.GetPeople(5);
            Assert.True(birthingUnitMembers.Count == 5);
            Assert.All(birthingUnitMembers, member => Assert.True(member.FirstName == "Bob"));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void GetPeopleWithZeroOrLessInputReturnsNoBirthingUnitMembers(int numberOfBirthingUnitMembers)
        {
            var birthingUnit = new BirthingUnit(_randomNumberGenerator);
            var birthingUnitMembers = birthingUnit.GetPeople(numberOfBirthingUnitMembers);
            Assert.True(birthingUnitMembers.Count == 0);
        }
    }
}