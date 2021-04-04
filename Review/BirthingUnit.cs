using System;
using System.Collections.Generic;
using System.Linq;

namespace Review
{
    public class BirthingUnit
    {
        private readonly List<People> _people;
        private static readonly Random RandomNumberGenerator = new Random(); 

        public BirthingUnit()
        {
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
                    if (RandomNumberGenerator.Next(0, 2) == 0) {
                        name = "Bob";
                    }
                    else {
                        name = "Betty";
                    }
                    // Adds new people to the list
                    _people.Add(new People(name, DateTime.UtcNow.Subtract(new TimeSpan(RandomNumberGenerator.Next(18, 85) * 356, 0, 0, 0))));
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
            return olderThan30 ? _people.Where(x => x.Name == "Bob" && x.DateOfBirth >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.Name == "Bob");
        }
    }
}