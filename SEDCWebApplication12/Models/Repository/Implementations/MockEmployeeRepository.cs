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
                    Id = 1,

                    Name = "Raja",

                    Company = "Some"
                },
                new Employee
                {
                    Id = 2,

                    Name = "Gaja",

                    Company = "Some"
                },
                new Employee
                {
                    Id = 3,

                    Name = "Vlaja",

                    Company = "Some"
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
    }
}
