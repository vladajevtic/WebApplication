using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using WebApplication.CodeFirst.Entities;
using WebApplication.CodeFirst.Interfaces;

namespace WebApplication.CodeFirst.Implementations
{
    public class OrderRepository : IOrderDAL
    {
        private IConfiguration Configuration { get; set; }
        public OrderRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Order> GetAll(int skip, int take)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
               
                    List<Order> result = db.Orders.Skip(skip).Take(take).ToList();
                        
                    return result;
                
            }
        }

        public List<Order> GetByEmployeeId(int id)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                List<Order> result = db.Orders
                    .Include(o => o.Employee).Where(e => e.Employee.Id == id).ToList();
                return result;
            }
        }

        public Order GetById(int id)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                return db.Orders.First(o => o.Id == id);
            }
        }

        public void Save(Order item)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                db.Orders.Add(item);
                db.SaveChanges();
            }
        }

        public List<Order> GetByCustomerId(int id, int skip, int take)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                List<Order> result = db.Orders
                    .Include(o => o.OrderItems).ThenInclude(x => x.Product).Where(e => e.CustomerId == id).Skip(skip).Take(take).ToList();
                    
                return result;
            }
        }
    }
}
