using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication12.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public bool IsDiscounted { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public Size Size { get; set; }
    }
}
