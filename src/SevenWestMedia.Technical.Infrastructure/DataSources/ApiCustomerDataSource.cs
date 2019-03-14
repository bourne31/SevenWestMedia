using System.Collections.Generic;
using SevenWestMedia.Technical.Core.Interfaces;
using SevenWestMedia.Technical.Domain.Customers;

namespace SevenWestMedia.Technical.Infrastructure.DataSources
{
    public class ApiCustomerDataSource : ICustomerDataSource
    {
        public IEnumerable<Customer> Customers => null;
    }
}