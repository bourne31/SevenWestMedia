using System.Collections.Generic;
using System.Linq;
using SevenWestMedia.Technical.Core.Interfaces;
using SevenWestMedia.Technical.Core.Models;

namespace SevenWestMedia.Technical.Core.Services.User
{
    public class UserService : IUserService
    {
        private readonly IUserDataSource _userDataSource;

        public UserService(IUserDataSource userDataSource)
        {
            _userDataSource = userDataSource;
        }

        public UserModel GetUserById(int userId)
        {
            var user = _userDataSource.Users
                .Where(c => c.Id == userId)
                .Select(c => new UserModel
                {
                    Id = c.Id,
                    FirstName = c.First,
                    LastName = c.Last,
                    Age = c.Age
                })
                .SingleOrDefault();

            return user;
        }

        public List<UserModel> GetUsersByAge(int userAge)
        {
            var users = _userDataSource.Users
                .Where(c => c.Age == userAge)
                .Select(c => new UserModel
                {
                    Id = c.Id,
                    FirstName = c.First,
                    LastName = c.Last,
                    Age = c.Age
                })
                .ToList();

            return users;
        }

        public List<UserAgeGroupModel> GetUsersGroupByAge()
        {
            var maleGenderLabels = new List<string> {"MALE", "M"};
            var femaleGenderLabels = new List<string> {"FEMALE", "F"};

            var users = _userDataSource.Users
                .GroupBy(
                    c => c.Age,
                    c => c.Gender,
                    (key, genders) => new
                    {
                        Age = key,
                        Genders = genders
                    }
                )
                .Select(c => new UserAgeGroupModel
                {
                    Age = c.Age,
                    MaleCount = c.Genders.Count(g => maleGenderLabels.Contains(g.ToUpper())),
                    FemaleCount = c.Genders.Count(g => femaleGenderLabels.Contains(g.ToUpper())),
                    NonBinaryCount = c.Genders.Count(g => !maleGenderLabels.Contains(g.ToUpper()) &&
                                                          !femaleGenderLabels.Contains(g.ToUpper()))
                })
                .ToList();

            return users;
        }
    }
}