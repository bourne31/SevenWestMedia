using AutoMoqCore;
using Moq;
using NUnit.Framework;
using SevenWestMedia.Technical.ConsoleApp.Writer;
using SevenWestMedia.Technical.Core.Services.User;

namespace SevenWestMedia.Technical.Tests.ConsoleApp.Writer
{
    [TestFixture]
    public class ConsoleWriterTests
    {
        private ConsoleWriter _consoleWriter;
        private AutoMoqer _mocker;

        private const int Id = 42;
        private const int Age = 23;

        [SetUp]
        public void SetUp()
        {
            _mocker = new AutoMoqer();

            _consoleWriter = _mocker.Create<ConsoleWriter>();
        }

        [Test]
        public void TestWriteShouldDisplayResultsToConsole()
        {
            _consoleWriter.Write(Id, Age);

            _mocker.GetMock<IUserService>()
                .Verify(p => p.GetUserById(Id),
                    Times.Once);

            _mocker.GetMock<IUserService>()
                .Verify(p => p.GetUsersByAge(Age),
                    Times.Once);

            _mocker.GetMock<IUserService>()
                .Verify(p => p.GetUsersGroupByAge(),
                    Times.Once);
        }
    }
}