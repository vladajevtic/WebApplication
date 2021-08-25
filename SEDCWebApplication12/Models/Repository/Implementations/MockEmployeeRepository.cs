﻿using SEDCWebApplication.Models;
using SEDCWebApplication12.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication12.Models.Repository.Implementations
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<Employee> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<Employee>
            {
                new Employee
                {
                    Id=1,
                    Name="Pera",
                    Email = "www.nesro.com",
                    Role=RoleEnum.Manager,
                    Test = true,
                    ImagePath = "../image/avatar.png"
                },
                new Employee
                {
                    Id=2,
                    Name="Mika",
                    Email = "www.nesro.com",
                    Role=RoleEnum.Sales,
                    Test = false
                },
                new Employee
                {
                    Id=3,
                    Name="Laza",
                    Email = "www.nesro.com",
                    Role=RoleEnum.Operater
                }
            };
        }

        public IEnumerable<Employee> GetAllEmployees()
        {
            return _employeeList;
        }

        public Employee GetEmployeeById(int id)
        {
            return _employeeList.Where(x => x.Id == id).FirstOrDefault();
        }

        public Employee Add(Employee employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return _employeeList.Where(x => x.Id == employee.Id).FirstOrDefault();
        }
    }
}
