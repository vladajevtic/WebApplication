using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationEntityFramework.Entities;

namespace WebApplicationEntityFramework.Interfaces
{
    public interface ICustomerDAL
    {
        void Save(Customer item);

        Customer GetById(int id);

        List<Customer> GetAll(int skip, int take);
    }
}
