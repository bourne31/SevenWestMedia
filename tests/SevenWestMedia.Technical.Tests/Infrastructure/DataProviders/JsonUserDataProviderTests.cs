using System.Collections.Generic;
using System.Linq;
using AutoMoqCore;
using Moq;
using NUnit.Framework;
using SevenWestMedia.Technical.Domain.Users;
using SevenWestMedia.Technical.Infrastructure.DataProviders;
using SevenWestMedia.Technical.Infrastructure.Stream;

namespace SevenWestMedia.Technical.Tests.Infrastructure.DataProviders
{
    [TestFixture]
    public class JsonUserDataProviderTests
    {
        private JsonUserDataProvider _userDataProvider;
        private AutoMoqer _mocker;
        private User _user;

        private const int Id = 1;
        private const string FirstName = "Roberto";
        private const string LastName = "Suner";
        private const string Gender = "M";
        private const int Age = 30;

        [SetUp]
        public void Setup()
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

            _mocker.GetMock<IStreamWrapper>()
                .Setup(u => u.ReadFromStream<IEnumerable<User>>(It.IsAny<string>()))
                .Returns(new List<User> {_user});

            _userDataProvider = _mocker.Create<JsonUserDataProvider>();
        }

        [Test]
        public void TestGetUsersShouldReturnListOfUsers()
        {
            var results = _userDataProvider.Users;

            var result = results.Single();

            Assert.That(result.Id, Is.EqualTo(Id));
            Assert.That(result.First, Is.EqualTo(FirstName));
            Assert.That(result.Last, Is.EqualTo(LastName));
            Assert.That(result.Age, Is.EqualTo(Age));
            Assert.That(result.Gender, Is.EqualTo(Gender));
        }

        [Test]
        public void TestGetUsersShouldReturnNull()
        {
            _mocker.GetMock<IStreamWrapper>()
                .Setup(u => u.ReadFromStream<IEnumerable<User>>(It.IsAny<string>()))
                .Returns((List<User>)null);

            var results = _userDataProvider.Users;

            Assert.That(results, Is.EqualTo(null));
        }
    }
}