using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDCWebApplication.BLL.Logic.Models;
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
        private readonly IWebHostEnvironment _webHostEnvironment;

        public EmployeeController(IEmployeeRepository employeeRepository, IWebHostEnvironment webHostEnvironment)
        {
            _employeeRepository = employeeRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("EmployeeList")]
        public IActionResult EmployeeList()
        {
            List<EmployeeDTO> employees = _employeeRepository.GetAllEmployees().ToList();

            ViewBag.Title = "Employees List";
            return View(employees);
        }

        [Route("EmployeeDetails/{id}")]
        public IActionResult EmployeeDetails(int id)
        {
            EmployeeDTO employee = _employeeRepository.GetEmployeeById(id);

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
        public IActionResult EmployeeCreate(EmployeeCreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                string uniqueName = "avatar.png";
                if (model.Photo != null)
                { 
                    uniqueName = Guid.NewGuid().ToString() + "_" + model.Photo.FileName;
                    string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "image");
                    string filePath = Path.Combine(uploadsFolder, uniqueName);
                    model.Photo.CopyTo(new FileStream(filePath, FileMode.Create));
                }
                EmployeeDTO employee = new EmployeeDTO
                {
                    Id = null,
                    Name = model.Name,
                    Email = model.Email,
                    Role = model.Role,
                    Gender = model.Gender,
                    ImagePath = "../image/" + uniqueName
                };
                EmployeeDTO newEmployee = _employeeRepository.Add(employee);
                return RedirectToAction("EmployeeDetails", new { id = newEmployee.Id });
            }
            return View();
        }
    }
}
