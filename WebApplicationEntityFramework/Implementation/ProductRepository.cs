using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplicationEntityFramework.Entities;
using WebApplicationEntityFramework.Interfaces;

namespace WebApplicationEntityFramework.Implementation
{
    public class ProductRepository : IProductDAL
    {
        public List<Product> GetAll(int skip, int take)
        {
            using (var db = new PizzaShopFinalContext())
            {
                return db.Products.ToList();
            }
        }

        public Product GetById(int id)
        {
            using (var db = new PizzaShopFinalContext())
            {
                return db.Products.First(x => x.ProductId == id);
            }
        }

        public void Save(Product item)
        {
            using (var db = new PizzaShopFinalContext())
            {
                db.Products.Add(item);
                db.SaveChanges();
            }
        }
    }
}
