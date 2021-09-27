using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApplication.CodeFirst.Entities
{
    
    public class OrderItem
    {
        public int OrderItemId { get; set; }
        public int ProductId { get; set; }//productId
        public int Quantity { get; set; }//quantity
        [ForeignKey("ProductId")]
        public Product Product { get; set; }
        public Order Order { get; set; }
    }
}
