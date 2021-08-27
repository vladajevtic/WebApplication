using AutoMapper;
using SEDCWebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLL.Logic.Interfaces;
using WebApplication.DAL.Data.Entities;
using WebApplication.DAL.Data.Interfaces;

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
            return employee;
        }

        public IEnumerable<EmployeeDTO> GetAllEmployees()
        {
            return _mapper.Map<List<EmployeeDTO>>(_employeeDAL.GetAll(0, 5));
        }

        public EmployeeDTO GetEmployeeById(int id)
        {
            return _mapper.Map<EmployeeDTO>(_employeeDAL.GetById(id));
        }
    }
}
