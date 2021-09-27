
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Text;

namespace WebApplication.BLL.Logic.Models
{
    public class ProductDTO
    {
        public int? Id { get; set; }       
        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool? IsDiscounted { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Size { get; set; }

    }
}

