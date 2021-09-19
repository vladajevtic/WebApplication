
using WebAPP2.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Interfaces;
using WebApplication.BLL.Logic.Models;


namespace WebAPP2.Models.Repository.Implementations
{
    public class DataBaseCustomerRepository : ICustomerRepository
    {
        private readonly ICustomerManager _customerManager;

        public DataBaseCustomerRepository(ICustomerManager customerManager)
        {
            _customerManager = customerManager;
        }
        public CustomerDTO Add(CustomerDTO customer)
        {
            return _customerManager.Add(customer);
        }

        public IEnumerable<CustomerDTO> GetAllCustomers()
        {
            return _customerManager.GetAllCustomer();
        }

        public CustomerDTO GetCustomerById(int id)
        {
            try
            {
                return _customerManager.GetCustomerById(id);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
