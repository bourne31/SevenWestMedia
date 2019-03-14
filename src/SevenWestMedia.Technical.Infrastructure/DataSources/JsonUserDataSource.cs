using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Newtonsoft.Json;
using SevenWestMedia.Technical.Core.Interfaces;
using SevenWestMedia.Technical.Domain.Users;

namespace SevenWestMedia.Technical.Infrastructure.DataSources
{
    public class JsonUserDataSource : IUserDataSource
    {
        private const string UsersJsonFilename = "SevenWestMedia-Users.json";

        public IEnumerable<User> Users
        {
            get
            {
                var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().FullName);
                var templateFilePath = Path.Combine(exePath ?? "", UsersJsonFilename);
                using (var reader = File.OpenText(templateFilePath))
                {
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        var serializer = new JsonSerializer();
                        var users = serializer.Deserialize<IEnumerable<User>>(jsonReader);
                        return users;
                    }
                }
            }
        }
    }
}