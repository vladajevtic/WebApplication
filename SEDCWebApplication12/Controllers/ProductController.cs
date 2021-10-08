using Microsoft.AspNetCore.Mvc;
using SEDCWebApplication12.Models;
using SEDCWebApplication12.Models.Repository.Interfaces;
using SEDCWebApplication12.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Models;

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

        //[Route("ProductList")]
        //public IActionResult ProductList()
        //{
        //    List<ProductDTO> products = _product.GetAllProduct().ToList();
        //    return View(products);
        //}

        //[Route("ProductDetails/{id}")]

        //public IActionResult ProductDetails(int id)
        //{
        //    var product = _product.GetProductById(id);

        //    return View(product);
        //}

        [Route("ProductCreate")]
        [HttpGet]
        public IActionResult ProductCreate()
        {
            return View();
        }

        [Route("ProductCreate")]
        [HttpPost]
        public IActionResult ProductCreate(ProductDTO product)
        {
            if (ModelState.IsValid)
            {
            ProductDTO newProduct = _product.AddProduct(product);
            return RedirectToAction("ProductDetails", new {id = newProduct.Id });
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
        public IActionResult ProductEdit(ProductDTO product)
        {
            ProductDTO unique = _product.Update(product);
            unique.Name = product.Name;
            unique.Price = product.Price;
            //unique.Description = product.Description;
            //unique.Picture = product.Picture;

            return RedirectToAction("ProductDetails", new { unique.Id });
        }
    }
}
