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
    public class CustomerRepository : ICustomerDAL
    {
        private IConfiguration Configuration { get; set; }
        public CustomerRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Customer> GetAll(int skip, int take)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                List<Customer> result = db.Customers.Skip(skip).Take(take).ToList();
                return result;
            }

        }

        public Customer GetById(int id)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                Customer result = db.Customers.Include(o => o.Contact).First(e => e.Id == id);
                return result;
            }
        }

        public void Save(Customer item)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                //User user = new User();
                db.Users.Add(item);
                db.SaveChanges();
            }
        }

        public void Update(Customer item)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                db.Entry<Customer>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
