using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplicationEntityFramework.Entities;
using WebApplicationEntityFramework.Interfaces;

namespace WebApplicationEntityFramework.Implementation
{
    public class EmployeeRepository : IEmployeeDAL
    {
        public List<Employee> GetAll(int skip, int take)
        {
            using(var db = new PizzaShopFinalContext())
            {
                return db.Employees.ToList();
            }
        }

        public Employee GetById(int id)
        {
            using (var db = new PizzaShopFinalContext())
            {
                return db.Employees.First(x => x.EmployeeId == id);
            }
        }

        public void Save(Employee item)
        {
            throw new NotImplementedException();
        }
    }
}
