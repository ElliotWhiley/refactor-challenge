using System;

namespace Review
{
    public class RandomNumberGenerator : IRandomNumberGenerator
    {
        private readonly Random _randomNumberGenerator;

        public RandomNumberGenerator()
        {
            _randomNumberGenerator = new Random();
        }

        public int GenerateRandomNumber(int inclusiveLowerBound, int exclusiveUpperBound)
        {
            return _randomNumberGenerator.Next(inclusiveLowerBound, exclusiveUpperBound);
        }
    }
}
