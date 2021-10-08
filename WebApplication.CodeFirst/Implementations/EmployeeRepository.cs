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
    public class EmployeeRepository : IEmployeeDAL
    {
        private IConfiguration Configuration { get; set; }
        public EmployeeRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public List<Employee> GetAll(int skip, int take)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                List<Employee> result = db.Employees.Skip(skip).Take(take).ToList();
                return result;
            }

        }

        public Employee GetById(int id)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                Employee result = db.Employees.First(e => e.Id == id);
                return result;
            }
        }

        public void Save(Employee item)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                //User user = new User();   
                db.Users.Add(item);
                db.SaveChanges();
            }
        }

        public void Update(Employee item)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                db.Entry<Employee>(item).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}
