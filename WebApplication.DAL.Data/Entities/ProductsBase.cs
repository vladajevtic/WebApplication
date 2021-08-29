using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.DAL.Data.Entities
{
    public class ProductsBase : BaseEntity
    {
        public ProductsBase(int? id)
           : base(id)
        {
        }
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
    }
}
