using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.CodeFirst.Entities;

namespace WebApplication.BLL.Logic.Models
{
    public class OrderDTO
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public Employee Employee { get; set; }
        public Customer Customer { get; set; }

        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
