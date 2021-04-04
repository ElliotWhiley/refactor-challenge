using System;

namespace Review
{
    public class People
    {
        private static readonly DateTimeOffset Under16 = DateTimeOffset.UtcNow.AddYears(-15);
        public string Name { get; }
        public DateTimeOffset DateOfBirth { get; }

        public People(string name) : this(name, Under16.Date)
        {
        }

        public People(string name, DateTime dateOfBirth)
        {
            Name = name;
            DateOfBirth = dateOfBirth;
        }
    }
}
