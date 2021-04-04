﻿using System;
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

        public List<People> CreatePeople(int numberOfPeopleToCreate)
        {
            for (int j = 0; j < numberOfPeopleToCreate; j++)
            {
                try
                {
                    _people.Add(new People(CreateFirstName(), CreateDateOfBirth()));
                }
                catch (Exception e)
                {
                    // Dont think this should ever happen
                    throw new Exception("Something failed in user creation");
                }
            }
            return _people;
        }

        private string CreateFirstName()
        {
            if (_randomNumberGenerator.GenerateRandomNumber(0, 2) == 0) {
                return "Bob";
            }
            return "Betty";
        }

        private static DateTime CreateDateOfBirth()
        {
            return DateTime.UtcNow.Subtract(new TimeSpan(new Random().Next(18, 85) * 356, 0, 0, 0));
        }

        private IEnumerable<People> GetBobs(bool olderThan30)
        {
            return olderThan30 ? _people.Where(x => x.FirstName == "Bob" && x.DateOfBirth >= DateTime.Now.Subtract(new TimeSpan(30 * 356, 0, 0, 0))) : _people.Where(x => x.FirstName == "Bob");
        }
    }
}