using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Helpers;
using WebApplication.BLL.Logic.Models;

namespace WebAPP2.Models.Repository.Interfaces
{
    public interface ICustomerRepository
    {
        IEnumerable<CustomerDTO> GetAllCustomers();
        CustomerDTO GetCustomerById(int id);
        CustomerDTO Add(NewCustomerModel customer);
        CustomerDTO Update(int id, NewCustomerModel customer);
        CustomerDTO Delete(CustomerDTO customer);

    }
}
