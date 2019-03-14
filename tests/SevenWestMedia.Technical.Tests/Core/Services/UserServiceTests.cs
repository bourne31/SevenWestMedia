using System.Collections.Generic;
using System.Linq;
using AutoMoqCore;
using NUnit.Framework;
using SevenWestMedia.Technical.Core.Interfaces;
using SevenWestMedia.Technical.Core.Services.User;
using SevenWestMedia.Technical.Domain.Users;

namespace SevenWestMedia.Technical.Tests.Core.Services
{
    [TestFixture]
    public class UserServiceTests
    {
        private UserService _userService;
        private AutoMoqer _mocker;
        private User _user;

        private const int Id = 1;
        private const string FirstName = "Roberto";
        private const string LastName = "Suner";
        private const string Gender = "M";
        private const int Age = 30;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _user = new User
            {
                Id = Id,
                First = FirstName,
                Last = LastName,
                Age = Age,
                Gender = Gender
            };

            _mocker.GetMock<IUserDataProvider>()
                .Setup(u => u.Users)
                .Returns(new List<User> {_user});

            _userService = _mocker.Create<UserService>();
        }

        [Test]
        public void TestGetUserByIdShouldReturnSingleUser()
        {
            var result = _userService.GetUserById(Id);

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.FirstName, Is.EqualTo(FirstName));
            Assert.That(result.LastName, Is.EqualTo(LastName));
            Assert.That(result.Age, Is.EqualTo(Age));
            Assert.That(result.Gender, Is.EqualTo(Gender));
        }

        [Test]
        public void TestGetUsersByAgeShouldReturnListOfUser()
        {
            var results = _userService.GetUsersByAge(Age);

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.FirstName, Is.EqualTo(FirstName));
            Assert.That(result.LastName, Is.EqualTo(LastName));
            Assert.That(result.Age, Is.EqualTo(Age));
            Assert.That(result.Gender, Is.EqualTo(Gender));
        }

        [Test]
        public void TestGetUsersGroupByAgeShouldReturnListOfUserAgeGroup()
        {
            var results = _userService.GetUsersGroupByAge();

            var result = results.Single();

            Assert.That(result.Age, Is.EqualTo(Age));
            Assert.That(result.MaleCount, Is.EqualTo(1));
            Assert.That(result.FemaleCount, Is.EqualTo(0));
            Assert.That(result.NonBinaryCount, Is.EqualTo(0));
        }
    }
}