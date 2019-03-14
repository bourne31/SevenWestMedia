using System.Collections.Generic;
using System.IO;
using System.Reflection;
using SevenWestMedia.Technical.Core.Interfaces;
using SevenWestMedia.Technical.Domain.Users;
using SevenWestMedia.Technical.Infrastructure.Stream;

namespace SevenWestMedia.Technical.Infrastructure.DataProviders
{
    public class JsonUserDataProvider : IUserDataProvider
    {
        private const string UsersJsonFilename = "SevenWestMedia-Users.json";

        private readonly IStreamWrapper _streamWrapper;

        private IEnumerable<User> _users;

        public JsonUserDataProvider(IStreamWrapper streamWrapper)
        {
            _streamWrapper = streamWrapper;
        }

        public IEnumerable<User> Users
        {
            get
            {
                if (_users == null)
                {
                    _users = GetUsers();
                    return _users;
                }

                return _users;
            }
        }

        private IEnumerable<User> GetUsers()
        {
            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().FullName);
            var templateFilePath = Path.Combine(exePath ?? "", UsersJsonFilename);

            var users = _streamWrapper.ReadFromStream<IEnumerable<User>>(templateFilePath);

            return users;
        }
    }
}