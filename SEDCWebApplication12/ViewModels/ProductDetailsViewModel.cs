using SEDCWebApplication12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Models;

namespace SEDCWebApplication12.ViewModels
{
    public class ProductDetailsViewModel
    {
        public ProductDTO Product { get; set; }
        public string Title { get; set; }
       
    }
}
