﻿using Microsoft.AspNetCore.Mvc;
using WebAPP2.Models.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using WebAPP2.Helpers;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPP2.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = AuthorizationRoles.Client)]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _product;

        public ProductController(IProductRepository product)
        {
            _product = product;
        }
        // GET: api/<ProductController>
        [HttpGet]
        public IEnumerable<ProductDTO> Get()
        {
            return _product.GetAllProduct();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public ProductDTO Get(int id)
        {
            return _product.GetProductById(id);
        }

        // POST api/<ProductController>
        [HttpPost]
        public void Post([FromBody] ProductDTO product)
        {
             _product.AddProduct(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put([FromBody] ProductDTO product)
        {
            _product.Update(product);

        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            var productDel = _product.GetProductById(id);
            _product.Delete(productDel);
            var productDeleted = _product.GetProductById(id);
            return productDeleted.IsDeleted;
        }
    }
}
