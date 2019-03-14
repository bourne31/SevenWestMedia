using SevenWestMedia.Technical.Domain.Common;

namespace SevenWestMedia.Technical.Domain.Users
{
    public class User : IEntity
    {
        public string First { get; set; }

        public string Last { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }
        public int Id { get; set; }
    }
}