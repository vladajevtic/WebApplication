using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.DAL.Data.Entities;

namespace WebApplication.DAL.Data.Interfaces
{
    public interface IEmployeeDAL
    {
        void Save(Employee item);

        Employee GetById(int id);

        List<Employee> GetAll(int skip, int take);
    }
}
