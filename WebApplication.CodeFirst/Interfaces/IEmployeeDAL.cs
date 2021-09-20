using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.CodeFirst.Entities;

namespace WebApplication.CodeFirst.Interfaces
{
    public interface IEmployeeDAL
    {
        void Save(Employee item);
        Employee GetById(int id);
        List<Employee> GetAll(int skip, int take);
    }
}
