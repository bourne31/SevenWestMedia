using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using SevenWestMedia.Technical.Domain.Customers;

namespace SevenWestMedia.Technical.Infrastructure.DataSources
{
    public class JsonCustomerDataSource
    {
        private const string FilePath = @".\Customers.json";

        public IEnumerable<Customer> Customers
        {
            get
            {
                using (var reader = File.OpenText(FilePath))
                {
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        var serializer = new JsonSerializer();

                        // read the json from a stream
                        // json size doesn't matter because only a small piece is read at a time from the HTTP request
                        var customers = serializer.Deserialize<IEnumerable<Customer>>(jsonReader);
                        return customers;
                    }
                }
            }
        }
    }
}