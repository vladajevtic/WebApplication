using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.CodeFirst.Entities;

namespace WebApplication.BLL.Logic.Models
{
    public class OrderItemDTO
    {
        public int ProductId { get; set; }//productId
        public int Quantity { get; set; }//quantity

    }
}
