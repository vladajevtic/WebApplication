using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.CodeFirst.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? UnitPrice { get; set; }
        public bool? IsDiscounted { get; set; }
        public bool? IsActive { get; set; }
        public bool? IsDeleted { get; set; }
        public string Size { get; set; }
    }
}
