using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL.Data.Entities;

namespace WebApplication.DAL.Data.Entities
{
    public class Product : BaseEntity
    {
        public Product(int? id)
               : base(id)
        {
        }

        public string Name { get; set; }
        public decimal Price { get; set; }
        public bool? IsDiscounted { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public string Size { get; set; }
        
    }
}
