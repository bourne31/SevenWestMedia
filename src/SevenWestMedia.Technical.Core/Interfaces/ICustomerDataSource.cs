using System.Collections.Generic;
using SevenWestMedia.Technical.Domain.Customers;

namespace SevenWestMedia.Technical.Core.Interfaces
{
    public interface ICustomerDataSource
    {
        IEnumerable<Customer> Customers { get; }
    }
}