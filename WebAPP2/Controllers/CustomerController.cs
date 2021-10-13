using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using WebAPP2.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Models;
using Microsoft.AspNetCore.Cors;
using WebApplication.BLL.Logic.Helpers;
using Microsoft.AspNetCore.Authorization;
using WebAPP2.Helpers;

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
        [Authorize(Roles = AuthorizationRoles.Client)]
        [EnableCors("MyPolicy")]
        [Route("my")]
        [HttpGet]
        public CustomerDTO Get(int id)
        {
            UserDTO user = (UserDTO)HttpContext.Items["User"];
            return _customerRepository.GetCustomerById(user.Id);
        }

        // POST api/<CustomerController>
        [HttpPost]
        public void Post([FromBody] NewCustomerModel value)
        {
            CustomerDTO customer = _customerRepository.Add(value);
        }

        // PUT api/<CustomerController>/5
        [Authorize(Roles = AuthorizationRoles.Client)]
        [EnableCors("MyPolicy")]
        [Route("put")]
        [HttpPut]
        public CustomerDTO Put(int id,[FromBody] NewCustomerModel value)
        {
            UserDTO user = (UserDTO)HttpContext.Items["User"];
            _customerRepository.Update(user.Id, value);
            CustomerDTO customer = _customerRepository.GetCustomerById(user.Id);
            return customer;
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
