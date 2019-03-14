using SevenWestMedia.Technical.Domain.Common;

namespace SevenWestMedia.Technical.Domain.Customers
{
    public class Customer : IEntity
    {
        public int Id { get; set; }

        public string First { get; set; }

        public string Last { get; set; }

        public int Age { get; set; }

        public string Gender { get; set; }
    }
}