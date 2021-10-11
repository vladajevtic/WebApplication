using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPP2.Helpers;
using WebAPP2.Models.Repository.Interfaces;
using WebApplication.BLL.Logic.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPP2.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;

        }
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<OrderDTO> Get()
        {
            return _orderRepository.GetAll();
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public OrderDTO Get(int id)
        {
            return _orderRepository.GetById(id);
        }
        //Swashbuckle.AspNetCore.SwaggerGen.SwaggerGeneratorException: Conflicting method/path combination "GET api/Order/{id}" for actions - WebAPP2.Controllers.OrderController.Get(WebAPP2),WebAPP2.Controllers.OrderController.GetByCustomerId(WebAPP2). Actions require a unique method/path combination for Swagger/OpenAPI 3.0. Use ConflictingActionsResolver as a workaround
        [Authorize(Roles = AuthorizationRoles.Client)]
        [Route("my")]
        [HttpGet]
        public IEnumerable<OrderDTO> GetByCustomerId(int id)
        {
            UserDTO user = (UserDTO)HttpContext.Items["User"];
            return _orderRepository.GetByCustomerId(user.Id);
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] OrderDTO orderDTO)
        {
            _orderRepository.Add(orderDTO);
        }


        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
