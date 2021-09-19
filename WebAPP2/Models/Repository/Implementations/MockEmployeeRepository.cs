
using SEDCWebApplication.BLL.Logic.Models;

using WebAPP2.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPP2.Models.Repository.Implementations
{
    public class MockEmployeeRepository : IEmployeeRepository
    {
        private List<EmployeeDTO> _employeeList;
        public MockEmployeeRepository()
        {
            _employeeList = new List<EmployeeDTO>
            {
                new EmployeeDTO
                {
                    Id=1,
                    Name="Pera",
                    Email = "www.nesro.com",
                    Role=RoleEnum.Manager,
                    Test = true,
                    ImagePath = "../image/avatar.png"
                },
                new EmployeeDTO
                {
                    Id=2,
                    Name="Mika",
                    Email = "www.nesro.com",
                    Role=RoleEnum.Sales,
                    Test = false
                },
                new EmployeeDTO
                {
                    Id=3,
                    Name="Laza",
                    Email = "www.nesro.com",
                    Role=RoleEnum.Operater
                }
            };
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            return _employeeList;
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            return _employeeList.Where(x => x.Id == id).FirstOrDefault();
        }

        public EmployeeDTO Add(EmployeeDTO employee)
        {
            employee.Id = _employeeList.Max(e => e.Id) + 1;
            _employeeList.Add(employee);
            return _employeeList.Where(x => x.Id == employee.Id).FirstOrDefault();
        }
    }
}
