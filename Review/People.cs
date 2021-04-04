using System;

namespace Review
{
    public class People
    {
        private const int MaximumFullNameLength = 255;

        public string FirstName { get; }
        public string LastName { get; private set; }
        public DateTimeOffset DateOfBirth { get; }

        public People(string firstName, IClock clock) : this(firstName, clock.FifteenYearsAgo())
        {
        }

        public People(string firstName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            DateOfBirth = dateOfBirth;
        }

        public string GetMarried(string lastName)
        {
            if (lastName.Contains("test"))
            {
                return FirstName;
            }
            LastName = lastName;
            return GetFullName();
        }

        public string GetFullName()
        {
            if (string.IsNullOrWhiteSpace(LastName))
            {
                return FirstName;
            }
            var fullName = $"{FirstName} {LastName}";
            if (fullName.Length > MaximumFullNameLength)
            {
                return fullName.Substring(0, MaximumFullNameLength);
            }
            return fullName;
        }
    }
}
