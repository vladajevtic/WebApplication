using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplicationEntityFramework.Entities;
using WebApplicationEntityFramework.Interfaces;

namespace WebApplicationEntityFramework.Implementation
{
    public class CustomerRepository : ICustomerDAL
    {
        public List<Customer> GetAll(int skip, int take)
        {
            using (var db = new PizzaShopFinalContext())
            {
                return db.Customers.ToList();
            }
        }

        public Customer GetById(int id)
        {
            using (var db = new PizzaShopFinalContext())
            {
                return db.Customers.First(x => x.CustomerId == id);
            }
        }

        public void Save(Customer item)
        {
            throw new NotImplementedException();
        }
    }
}
