using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLL.Logic.Helpers;
using WebApplication.BLL.Logic.Models;

namespace WebApplication.BLL.Logic.Interfaces
{
    public interface ICustomerManager
    {
        IEnumerable<CustomerDTO> GetAllCustomer();
        CustomerDTO GetCustomerById(int id);
        CustomerDTO Add(NewCustomerModel customer);
        CustomerDTO Update(int id, NewCustomerModel customer);
        CustomerDTO Delete(CustomerDTO customer);
    }
}
