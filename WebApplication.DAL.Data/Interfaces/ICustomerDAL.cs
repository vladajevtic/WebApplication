using SEDCWebApplication12.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.DAL.Data.Interfaces
{
    public interface ICustomerDAL
    {
        void Save(Customer item);

        Customer GetById(int id);

        List<Customer> GetAll(int skip, int take);
    }
}
