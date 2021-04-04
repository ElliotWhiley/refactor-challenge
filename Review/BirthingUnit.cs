using System;
using System.Collections.Generic;
using System.Linq;

namespace Review
{
    public class BirthingUnit
    {
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly List<People> _people;

        public BirthingUnit(IRandomNumberGenerator randomNumberGenerator)
        {
            _randomNumberGenerator = randomNumberGenerator;
            _people = new List<People>();
        }

        public List<People> GetPeople(int i)
        {
            for (int j = 0; j < i; j++)
            {
                try
                {
                    // Creates a dandon Name
                    string name = string.Empty;
                    if (_randomNumberGenerator.GenerateRandomNumber(0, 2) == 0) {
                        name = "Bob";
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(_randomNumberGenerator.GenerateRandomNumber(18, 85) * 356, 0, 0, 0))));
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation");
                }
            }
            return _people;
        }

        private IEnumerable<People> GetBobs(bool olderThan30)
        {
            return olderThan30 ? _people.Where(x => x.FirstName == "Bob" && x.DateOfBirth >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.FirstName == "Bob");
        }
    }
}