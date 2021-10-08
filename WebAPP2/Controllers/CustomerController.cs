﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebAPP2.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Models;
using Microsoft.AspNetCore.Cors;
using WebApplication.BLL.Logic.Helpers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPP2.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CustomerController(ICustomerRepository customerRepository, IWebHostEnvironment webHostEnvironment)
        {
            _customerRepository = customerRepository;
            _webHostEnvironment = webHostEnvironment;
        }
        // GET: api/<CustomerController>
        [HttpGet]
        public IEnumerable<CustomerDTO> Get()
        {
            return _customerRepository.GetAllCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("{id}")]
        public CustomerDTO Get(int id)
        {
            return _customerRepository.GetCustomerById(id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] NewCustomerModel value)
        {
            CustomerDTO customer = _customerRepository.Add(value);
        }

        // PUT api/<CustomerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] CustomerDTO value)
        {
            _customerRepository.Update( value);
        }

        // DELETE api/<CustomerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var customerDel = _customerRepository.GetCustomerById(id);
            _customerRepository.Delete(customerDel);
        }
    }
}
