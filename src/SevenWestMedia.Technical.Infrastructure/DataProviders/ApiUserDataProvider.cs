﻿using System.Collections.Generic;
using SevenWestMedia.Technical.Core.Interfaces;
using SevenWestMedia.Technical.Domain.Users;

namespace SevenWestMedia.Technical.Infrastructure.DataProviders
{
    public class ApiUserDataProvider : IUserDataProvider
    {
        public IEnumerable<User> Users => null;
    }
}