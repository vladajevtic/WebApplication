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
        [HttpGet]
        public IActionResult EmployeeCreate()
        {
            //EmployeeDetailsViewModel employeeVM = new EmployeeDetailsViewModel();
            /*employeeVM.Roles = new List<SelectListItem>
            {
                new SelectListItem {Text = "Shyju", Value = "1"},
                new SelectListItem {Text = "Sean", Value = "2"}
            };*/
            return View();
        }

        [HttpPost]
        public IActionResult EmployeeCreate(Employee employee)
        {
            if (ModelState.IsValid)
            {
            Employee newEmployee = _employeeRepository.Add(employee);
            return RedirectToAction("EmployeeDetails", new { id = newEmployee.Id });
            }
            return View();
        }
    }
}
