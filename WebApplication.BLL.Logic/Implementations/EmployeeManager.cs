using AutoMapper;
using SEDCWebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLL.Logic.Interfaces;

//using WebApplicationEntityFramework.Entities;
//using WebApplicationEntityFramework.Interfaces;
//using WebApplication.DAL.Data.Entities;
//using WebApplication.DAL.Data.Interfaces;
using WebApplication.CodeFirst.Interfaces;
using WebApplication.CodeFirst.Entities;

namespace WebApplication.BLL.Logic.Implementations
{
    public class EmployeeManager : IEmployeeManager
    {
        private readonly IEmployeeDAL _employeeDAL;
        //private readonly IOrderDAL _orderDAL;
        private readonly IMapper _mapper;
        public EmployeeManager(IEmployeeDAL employeeDAL, IMapper mapper)
        {
            _employeeDAL = employeeDAL;
            _mapper = mapper;
            //_orderDAL = orderDAL;
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
                EmployeeDTO employeeDTO = _mapper.Map<EmployeeDTO>(_employeeDAL.GetById(id));
                //employeeDTO.Orders = _orderDAL.GetByEmployeeId(employee.Id);
                return employeeDTO;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
