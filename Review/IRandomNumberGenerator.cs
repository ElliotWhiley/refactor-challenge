namespace Review
{
    public interface IRandomNumberGenerator
    {
        int GenerateRandomNumber(int inclusiveLowerBound, int exclusiveUpperBound);
    }
}