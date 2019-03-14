using System.Collections.Generic;
using SevenWestMedia.Technical.Core.Interfaces;
using SevenWestMedia.Technical.Domain.Users;

namespace SevenWestMedia.Technical.Infrastructure.DataSources
{
    public class InMemoryUserDataSource : IUserDataSource
    {
        public IEnumerable<User> Users => null;
    }
}