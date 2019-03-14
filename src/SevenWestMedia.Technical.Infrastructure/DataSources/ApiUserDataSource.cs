using System.Collections.Generic;
using SevenWestMedia.Technical.Core.Interfaces;
using SevenWestMedia.Technical.Domain.Users;

namespace SevenWestMedia.Technical.Infrastructure.DataSources
{
    public class ApiUserDataSource : IUserDataSource
    {
        public IEnumerable<User> Users => null;
    }
}