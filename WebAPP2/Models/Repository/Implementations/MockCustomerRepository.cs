using WebAPP2.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Models;
using WebApplication.BLL.Logic.Helpers;

namespace WebAPP2.Models.Repository.Implementations
{
    public class MockCustomerRepository : ICustomerRepository
    {
        private List<CustomerDTO> _customerList;
        public MockCustomerRepository()
        {
            _customerList = new List<CustomerDTO>
            {
                new CustomerDTO
                {
                    Id = 1,
                    Name = "Pera",
                    ContactId = 1,
                   
                    ImagePath = "../image/avatar.png"
                },
                new CustomerDTO
                {
                    Id = 2,
                    Name = "Mika",
                    ContactId = 2,
                   
                    ImagePath = "../image/avatar.png"
                },
                new CustomerDTO
                {
                    Id = 3,
                    Name = "Zika",
                    ContactId = 3,
                   
                    ImagePath = "../image/avatar.png"
                }
            };
        }

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            return _customerList;
        }

        public CustomerDTO GetCustomerById(int id)
        {
            return _customerList.Where(x => x.Id == id).FirstOrDefault();
        }
        //public CustomerDTO Add(CustomerDTO customer)
        //{
        //    customer.Id = _customerList.Max(e => e.Id) + 1;
        //    _customerList.Add(customer);
        //    return _customerList.Where(x => x.Id == customer.Id).FirstOrDefault();
        //}

        public CustomerDTO Update(int id, NewCustomerModel customer)
        {
            throw new NotImplementedException();
        }

        public CustomerDTO Delete(CustomerDTO customer)
        {
            throw new NotImplementedException();
        }

       

        public CustomerDTO Add(NewCustomerModel customer)
        {
            throw new NotImplementedException();
        }
    }
}
