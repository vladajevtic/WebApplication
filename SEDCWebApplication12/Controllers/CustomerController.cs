using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using SEDCWebApplication12.Models;
using SEDCWebApplication12.Models.Repository.Interfaces;
using SEDCWebApplication12.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using SEDCWebApplication.BLL.Logic.Models;
using WebApplication.BLL.Logic.Models;

namespace SEDCWebApplication12.Controllers
{
    [Route("Customer")]
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CustomerController(ICustomerRepository customerRepository, IWebHostEnvironment webHostEnvironment)
        {
            _customerRepository = customerRepository;
            _webHostEnvironment = webHostEnvironment;
        }

        //[Route("CustomerList")]
        //public IActionResult CustomerList()
        //{
        //   List<CustomerDTO> customers = _customerRepository.GetAllCustomers().ToList();
            
        //    ViewBag.Title = "Customers";

        //    return View(customers);
        //}
        //[Route("CustomerDetails/{id}")]
        //public IActionResult CustomerDetails(int id)
        //{
        //    CustomerDTO customers = _customerRepository.GetCustomerById(id);

        //    CustomerDetailsViewModel customersVM = new CustomerDetailsViewModel
        //    {
        //        Customer = customers,

        //        PageTitle = "Customer Details"
        //    };
        //    return View(customersVM);
        //}
        [HttpGet]
        public IActionResult CustomerCreate()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult CustomerCreate(CustomerDTO customer)
        {
            if (ModelState.IsValid)
            {
                CustomerDTO newCustomer = _customerRepository.Add(customer);
                return RedirectToAction("CustomerDetails", new { id = newCustomer.Id });
            }

            return View();
        }
    }
}
