using System;
using System.Collections.Generic;
using System.Linq;
using Serilog;

namespace Review
{
    public class BirthingUnit
    {
        private static readonly ILogger _logger = Log.ForContext<BirthingUnit>();
        private readonly IRandomNumberGenerator _randomNumberGenerator;
        private readonly IClock _clock;
        private readonly List<People> _people;

        public BirthingUnit(IRandomNumberGenerator randomNumberGenerator, IClock clock)
        {
            _randomNumberGenerator = randomNumberGenerator;
            _clock = clock;
            _people = new List<People>();
        }

        public List<People> CreatePeople(int numberOfPeopleToCreate)
        {
            for (var i = 0; i < numberOfPeopleToCreate; i++)
            {
                try
                {
                    _people.Add(new People(CreateFirstName(), CreateDateOfBirth()));
                }
                catch (Exception e)
                {
                    _logger.Error(e, "Failed to create user");
                    throw;
                }
            }
            return _people;
        }

        private string CreateFirstName()
        {
            if (_randomNumberGenerator.GenerateRandomNumber(0, 2) == 0)
            {
                return "Bob";
            }
            return "Betty";
        }

        private DateTime CreateDateOfBirth()
        {
            return _clock.Now().Subtract(new TimeSpan(_randomNumberGenerator.GenerateRandomNumber(18, 85) * 356, 0, 0, 0));
        }

        private IEnumerable<People> GetBobs(bool olderThan30)
        {
            return olderThan30 ? _people.Where(x => x.FirstName == "Bob" && x.DateOfBirth >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.FirstName == "Bob");
        }
    }
}