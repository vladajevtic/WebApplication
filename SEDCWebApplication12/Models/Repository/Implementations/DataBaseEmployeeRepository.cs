using SEDCWebApplication.BLL.Logic.Models;
using SEDCWebApplication12.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Interfaces;

namespace SEDCWebApplication12.Models.Repository.Implementations
{
    public class DataBaseEmployeeRepository : IEmployeeRepository
    {
        private readonly IEmployeeManager _employeeManager;

        public DataBaseEmployeeRepository(IEmployeeManager employeeManager)
        {
            _employeeManager = employeeManager;
        }
        public EmployeeDTO Add(EmployeeDTO employee)
        {
            return _employeeManager.Add(employee);
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            return _employeeManager.GetAllEmployees();
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            return _employeeManager.GetEmployeeById(id);
        }
    }
}
