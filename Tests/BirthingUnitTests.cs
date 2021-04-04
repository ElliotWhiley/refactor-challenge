using System;
using System.Linq;
using Moq;
using Review;
using Xunit;

namespace Tests
{
    public class BirthingUnitTests
    {
        private readonly Mock<IRandomNumberGenerator> _randomNumberGeneratorMock;
        private readonly BirthingUnit _birthingUnit;

        public BirthingUnitTests()
        {
            _randomNumberGeneratorMock = new Mock<IRandomNumberGenerator>();
            var fakeClock = new Mock<IClock>();
            fakeClock.Setup(x => x.Now()).Returns(new DateTime(2000, 1, 1));
            fakeClock.Setup(x => x.NowOld()).Returns(new DateTime(2000, 1, 1));
            _birthingUnit = new BirthingUnit(_randomNumberGeneratorMock.Object, fakeClock.Object);
        }

        [Fact]
        public void GetPeopleCreatesBirthingUnitMembersWithNameAndDateOfBirth()
        {
            _randomNumberGeneratorMock.Setup(x => x.GenerateRandomNumber(18, 85)).Returns(50);
            var birthingUnitMembers = _birthingUnit.CreatePeople(5);
            Assert.True(birthingUnitMembers.Count == 5);
            Assert.All(birthingUnitMembers, member => Assert.True(member.FirstName == "Bob"));
            Assert.All(birthingUnitMembers, member => Assert.True(member.DateOfBirth == new DateTime(1951, 4, 8)));
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-5)]
        public void GetPeopleWithZeroOrLessInputReturnsNoBirthingUnitMembers(int numberOfBirthingUnitMembers)
        {
            var birthingUnitMembers = _birthingUnit.CreatePeople(numberOfBirthingUnitMembers);
            Assert.True(birthingUnitMembers.Count == 0);
        }

        [Fact]
        public void GetBobsReturnsBirthingUnitMembersNamedBob()
        {
            SeedRandomNumberGeneratorUsedForGeneratingDateOfBirth(35);
            _birthingUnit.CreatePeople(7);
            SeedRandomNumberGeneratorUsedForGeneratingDateOfBirth(25);
            var birthingUnitMembers = _birthingUnit.CreatePeople(3);
            var birthingUnitMembersNamedBobYoungerThanThirty = _birthingUnit.GetBobs(false);
            Assert.True(birthingUnitMembers.Count == 10);
            Assert.True(birthingUnitMembersNamedBobYoungerThanThirty.Count() == 10);
        }

        [Fact]
        public void GetBobsReturnsBirthingUnitMembersNamedBobOld()
        {
            SeedRandomNumberGeneratorUsedForGeneratingDateOfBirth(35);
            _birthingUnit.CreatePeople(7);
            SeedRandomNumberGeneratorUsedForGeneratingDateOfBirth(25);
            var birthingUnitMembers = _birthingUnit.CreatePeople(3);
            var birthingUnitMembersNamedBobYoungerThanThirty = _birthingUnit.GetBobsOld(false);
            Assert.True(birthingUnitMembers.Count == 10);
            Assert.True(birthingUnitMembersNamedBobYoungerThanThirty.Count() == 10);
        }

        [Fact]
        public void GetBobsOlderThanThirtyReturnsBirthingUnitMembersNamedBobOverAgeOfThirty()
        {
            SeedRandomNumberGeneratorUsedForGeneratingDateOfBirth(35);
            _birthingUnit.CreatePeople(7);
            SeedRandomNumberGeneratorUsedForGeneratingDateOfBirth(25);
            var birthingUnitMembers = _birthingUnit.CreatePeople(3);
            var birthingUnitMembersNamedBobOlderThanThirty = _birthingUnit.GetBobs(true);
            Assert.True(birthingUnitMembers.Count == 10);
            Assert.True(birthingUnitMembersNamedBobOlderThanThirty.Count() == 3);
        }

        [Fact]
        public void GetBobsOlderThanThirtyReturnsBirthingUnitMembersNamedBobOverAgeOfThirtyOld()
        {
            SeedRandomNumberGeneratorUsedForGeneratingDateOfBirth(35);
            _birthingUnit.CreatePeople(7);
            SeedRandomNumberGeneratorUsedForGeneratingDateOfBirth(25);
            var birthingUnitMembers = _birthingUnit.CreatePeople(3);
            var birthingUnitMembersNamedBobOlderThanThirty = _birthingUnit.GetBobsOld(true);
            Assert.True(birthingUnitMembers.Count == 10);
            Assert.True(birthingUnitMembersNamedBobOlderThanThirty.Count() == 3);
        }

        [Fact]
        public void GetMembersByPredicateReturnsBirthingUnitMembers()
        {
            _birthingUnit.CreatePeople(5);
            var birthingUnitMembersStartingWithLetterB = _birthingUnit.GetMembersByPredicate(x => x.FirstName.StartsWith('B'));
            Assert.True(birthingUnitMembersStartingWithLetterB.Count() == 5);
        }

        private void SeedRandomNumberGeneratorUsedForGeneratingDateOfBirth(int numberOfYears)
        {
            _randomNumberGeneratorMock.Setup(x => x.GenerateRandomNumber(18, 85)).Returns(numberOfYears);
        }
    }
}