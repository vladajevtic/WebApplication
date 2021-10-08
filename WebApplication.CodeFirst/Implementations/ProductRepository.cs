using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication.CodeFirst.Entities;
using WebApplication.CodeFirst.Interfaces;

namespace WebApplication.CodeFirst.Implementations
{
    public class ProductRepository : IProductDAL
    {
        private IConfiguration Configuration { get; set; }
        public ProductRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Product> GetAll(int skip, int take)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                List<Product> result = db.Products.Skip(skip).Take(take).ToList();
                return result;
            }

        }

        public Product GetById(int id)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                Product result = db.Products.First(e => e.Id == id);
                return result;
            }
        }

        public void Save(Product item)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {                
                db.Products.Add(item);
                db.SaveChanges();
            }
        }

        public void Update(Product item)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                db.Entry<Product>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
