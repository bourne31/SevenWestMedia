using System.Collections.Generic;
using SevenWestMedia.Technical.Domain.Users;

namespace SevenWestMedia.Technical.Core.Interfaces
{
    public interface IUserDataSource
    {
        IEnumerable<User> Users { get; }
    }
}