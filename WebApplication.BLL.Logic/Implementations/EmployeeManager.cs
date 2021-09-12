using AutoMapper;
using SEDCWebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLL.Logic.Interfaces;
using WebApplicationEntityFramework.Entities;
//using WebApplication.DAL.Data.Entities;
//using WebApplication.DAL.Data.Interfaces;

using WebApplicationEntityFramework.Interfaces;

namespace WebApplication.BLL.Logic.Implementations
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeDAL _employeeDAL;

        private readonly IMapper _mapper;
        public EmployeeManager(IEmployeeDAL employeeDAL, IMapper mapper)
        {
            _employeeDAL = employeeDAL;
            _mapper = mapper;
        }
        public EmployeeDTO Add(EmployeeDTO employee)
        {
            Employee employeeEntity = _mapper.Map<Employee>(employee);
            _employeeDAL.Save(employeeEntity);
             employee = _mapper.Map<EmployeeDTO>(employeeEntity);
            return employee;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            return _mapper.Map<List<EmployeeDTO>>(_employeeDAL.GetAll(0, 50));
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            try
            {
                Employee employee = _employeeDAL.GetById(id);
                if(employee == null)
                {
                    throw new Exception($"Employee with {id} not found");
                }
                return _mapper.Map<EmployeeDTO>(_employeeDAL.GetById(id));
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
