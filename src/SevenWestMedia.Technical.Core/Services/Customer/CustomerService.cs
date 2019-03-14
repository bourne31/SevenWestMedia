using System.Collections.Generic;
using System.Linq;
using SevenWestMedia.Technical.Core.Interfaces;
using SevenWestMedia.Technical.Core.Models;

namespace SevenWestMedia.Technical.Core.Services.Customer
{
    public class CustomerService
    {
        private readonly ICustomerDataSource _customerDataSource;

        public CustomerService(ICustomerDataSource customerDataSource)
        {
            _customerDataSource = customerDataSource;
        }

        public CustomerModel GetCustomerById(int customerId)
        {
            var customer = _customerDataSource.Customers
                .Where(c => c.Id == customerId)
                .Select(c => new CustomerModel
                    {
                        Id = c.Id,
                        FirstName = c.First,
                        LastName = c.Last,
                        Age = c.Age
                    }
                ).Single();

            return customer;
        }

        public List<CustomerModel> GetCustomersByAge(int customerId)
        {
            var customers = _customerDataSource.Customers
                .Where(c => c.Id == customerId)
                .Select(c => new CustomerModel
                    {
                        Id = c.Id,
                        FirstName = c.First,
                        LastName = c.Last,
                        Age = c.Age
                    }
                ).ToList();

            return customers;
        }

        public List<CustomerGroupModel> GroupCustomersByAge()
        {
            var maleGenderLabels = new List<string> {"MALE", "M"};
            var femaleGenderLabels = new List<string> {"FEMALE", "M"};

            var customers = _customerDataSource.Customers
                .GroupBy(
                    c => c.Age,
                    c => c.Gender,
                    (key, g) => new
                    {
                        Age = key,
                        Genders = g
                    })
                .Select(c => new CustomerGroupModel
                {
                    Age = c.Age,
                    Male = c.Genders.Count(g => maleGenderLabels.Contains(g.ToUpper())),
                    Female = c.Genders.Count(g => femaleGenderLabels.Contains(g.ToUpper())),
                    NonBinary = c.Genders.Count(g => !maleGenderLabels.Contains(g.ToUpper()) &&
                                                     !femaleGenderLabels.Contains(g.ToUpper()))
                }).ToList();

            return customers;
        }
    }
}