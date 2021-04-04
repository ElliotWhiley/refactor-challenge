using System;

namespace Review
{
    public class People
    {
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
        private const int MaximumFullNameLength = 255;

        public string Name { get; }
        public string LastName { get; private set; }
        public DateTimeOffset DateOfBirth { get; }

        public People(string name) : this(name, Under16.Date)
        {
        }

        public People(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }

        public string GetMarried(string lastName)
        {
            if (lastName.Contains("test"))
            {
                return Name;
            }
            LastName = lastName;
            return GetFullName();
        }

        public string GetFullName()
        {
            if (string.IsNullOrWhiteSpace(LastName))
            {
                return Name;
            }
            var fullName = $"{Name} {LastName}";
            if (fullName.Length > MaximumFullNameLength)
            {
                return fullName.Substring(0, MaximumFullNameLength);
            }
            return fullName;
        }
    }
}
