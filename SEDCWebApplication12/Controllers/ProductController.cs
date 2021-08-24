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

        [Route("ProductCreate")]
        [HttpGet]
        public IActionResult ProductCreate()
        {
            return View();
        }

        [Route("ProductCreate")]
        [HttpPost]
        public IActionResult ProductCreate(Product product)
        {
            if (ModelState.IsValid)
            {
            Product newProduct = _product.AddProduct(product);
            return RedirectToAction("ProductDetails", new {id = newProduct.ProductId });
            }
            return View();
        }


        [Route("ProductEdit/{id}")]
        [HttpGet]
        public IActionResult ProductEdit(int id)
        {
            var editProduct = _product.GetProductById(id);
            return View(editProduct);
        }

        [Route("ProductEdit/{id}")]
        [HttpPost]
        public IActionResult ProductEdit(Product product, int id)
        {
            Product unique = _product.GetProductById(id);
            unique.ProductName = product.ProductName;
            unique.UnitPrice = product.UnitPrice;
            unique.Description = product.Description;
            unique.Picture = product.Picture;
             
            return RedirectToAction("ProductDetails", new { id = unique.ProductId });
        }
    }
}
