using WebApplication.BLL.Logic.Models;
using WebAPP2.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Interfaces;
using SEDCWebApplication.BLL.Logic.Models;

namespace WebAPP2.Models.Repository.Implementations
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
            try
            {
                return _employeeManager.GetEmployeeById(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
