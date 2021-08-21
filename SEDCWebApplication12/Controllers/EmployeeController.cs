using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SEDCWebApplication12.Models;
using SEDCWebApplication12.Models.Repository.Implementations;
using SEDCWebApplication12.Models.Repository.Interfaces;
using SEDCWebApplication12.ViewModels;

namespace SEDCWebApplication12.Controllers
{
    [Route("Employee")]
    public class EmployeeController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeController(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        [Route("EmployeeList")]
        public IActionResult EmployeeList()
        {
            List<Employee> employees = _employeeRepository.GetAllEmployees().ToList();
            
            ViewBag.Title = "Employees List";
            return View(employees);
        }

        [Route("EmployeeDetails/{id}")]
        public IActionResult EmployeeDetails(int id)
        {
            Employee employee = _employeeRepository.GetEmployeeById(id);

            EmployeeDetailsViewModel employeeVM = new EmployeeDetailsViewModel
            {
                Employee = employee,

                PageTitle = "Employee details",
            };
            return View(employeeVM);
        }
    }
}
