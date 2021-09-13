using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplicationEntityFramework.Entities;
using WebApplicationEntityFramework.Interfaces;

namespace WebApplicationEntityFramework.Implementation
{
    public class OrderRepository : IOrderDAL
    {
        public List<Order> GetAll(int skip, int take)
        {
            using(var db = new PizzaShopFinalContext())
            {
                return db.Orders.ToList();
            }
        }

        public List<Order> GetByEmployeeId(int id)
        {
            using (var db = new PizzaShopFinalContext())
            {
                List<Order> orders = db.Orders.Include(o => o.Customer).Where(x => x.EmployeeId == id).ToList();
                return orders;
            }
            
        }

        public Order GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Order item)
        {
            using (var db = new PizzaShopFinalContext())
            {
                db.Orders.Add(item);
                db.SaveChanges();
            }
        }
    }
}
