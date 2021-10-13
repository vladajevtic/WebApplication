using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.CodeFirst.Entities;

namespace WebApplication.BLL.Logic.Models
{
    public class OrderDTO
    {

        public decimal TotalAmount { get; set; }
        public ICollection<OrderItemDTO> OrderItems { get; set; }
    }
}
