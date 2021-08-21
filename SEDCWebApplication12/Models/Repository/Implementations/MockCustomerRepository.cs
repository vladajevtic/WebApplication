using SEDCWebApplication12.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication12.Models.Repository.Implementations
{
    public class MockCustomerRepository : ICustomerRepository
    {
        private List<Customer> _customerList;
        public MockCustomerRepository()
        {
            _customerList = new List<Customer>
            {
                new Customer
                {
                    Id = 1,
                    Name = "Pera",
                    ContactId = 1
                },
                new Customer
                {
                    Id = 2,
                    Name = "Mika",
                    ContactId = 2
                },
                new Customer
                {
                    Id = 3,
                    Name = "Zika",
                    ContactId = 3
                }
            };
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            return _customerList;
        }

        public Customer GetCustomerById(int id)
        {
            return _customerList.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
