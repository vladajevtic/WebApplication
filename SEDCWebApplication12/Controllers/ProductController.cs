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
    [Route("Product")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _product;

        public ProductController(IProductRepository product)
        {
            _product = product;
        }

        [Route("ProductList")]
        public IActionResult ProductList()
        {
            List<Product> products = _product.GetAllProduct().ToList();
            return View(products);
        }

        [Route("ProductDetails/{id}")]

        public IActionResult ProductDetails(int id)
        {
            var product = _product.GetProductById(id);

            return View(product);
        }

        [HttpGet]
        public IActionResult ProductCreate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProductCreate(Product product)
        {
            _product.AddProduct(product);
            return RedirectToAction("ProductList");
        }

        [Route("ProductEdit/{id}")]
        public IActionResult ProductEdit(int id)
        {
            var editProduct = _product.GetProductById(id);
            return View(editProduct);
        }
    }
}
