﻿using SEDCWebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPP2.Models.Repository.Interfaces
{
    public interface IEmployeeRepository
    {
        IEnumerable<EmployeeDTO> GetAllEmployees();
        EmployeeDTO GetEmployeeById(int id);
        EmployeeDTO Add(EmployeeDTO employee);
        EmployeeDTO Update(EmployeeDTO employee);
        EmployeeDTO Delete(EmployeeDTO employee);
    }
}
