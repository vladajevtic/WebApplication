using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.CodeFirst.Entities;

namespace WebApplication.CodeFirst.Interfaces
{
    public interface ICustomerDAL
    {
        void Save(Customer item);
        void Update(Customer item);
        Customer GetById(int id);
        List<Customer> GetAll(int skip, int take);
    }
}
