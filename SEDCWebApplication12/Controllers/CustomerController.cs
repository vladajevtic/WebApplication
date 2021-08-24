using Microsoft.AspNetCore.Mvc;
using SEDCWebApplication12.Models;
using SEDCWebApplication12.Models.Repository.Interfaces;
using SEDCWebApplication12.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication12.Controllers
{
    [Route("Customer")]
    public class CustomerController : Controller
    {
        private ICustomerRepository _customerRepository;
        public CustomerController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [Route("CustomerList")]
        public IActionResult CustomerList()
        {
            List<Customer> customers = _customerRepository.GetAllCustomers().ToList();
            
            ViewBag.Title = "Customers";

            return View(customers);
        }
        [Route("CustomerDetails/{id}")]
        public IActionResult CustomerDetails(int id)
        {
            Customer customers = _customerRepository.GetCustomerById(id);

            CustomerDetailsViewModel customersVM = new CustomerDetailsViewModel
            {
                Customer = customers,

                PageTitle = "Customer Details"
            };
            return View(customersVM);
        }
        [HttpGet]
        public IActionResult CustomerCreate()
        {
          
            return View();
        }

        [HttpPost]
        public IActionResult CustomerCreate(Customer customer)
        {
            if (ModelState.IsValid)
            {
                Customer newCustomer = _customerRepository.Add(customer);
                return RedirectToAction("CustomerDetails", new { id = newCustomer.Id });
            }

            return View();
        }
    }
}
