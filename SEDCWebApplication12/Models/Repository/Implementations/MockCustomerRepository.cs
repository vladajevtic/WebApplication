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
                    ContactId = 1,
                    Email = "nest@gmail.com",
                    Picture = "../image/avatar.png"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Mika",
                    ContactId = 2,
                    Email = "nest@gmail.com",
                    Picture = "../image/avatar.png"
                },
                new Customer
                {
                    Id = 3,
                    Name = "Zika",
                    ContactId = 3,
                    Email = "nest@gmail.com",
                    Picture = "../image/avatar.png"
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
        public Customer Add(Customer customer)
        {
            customer.Id = _customerList.Max(e => e.Id) + 1;
            _customerList.Add(customer);
            return _customerList.Where(x => x.Id == customer.Id).FirstOrDefault();
        }
    }
}
