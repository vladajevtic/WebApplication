using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace WebApplication.CodeFirst.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime Date { get; set; }
        public decimal TotalAmount { get; set; }
        public int Status { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }   //[{productId,quantity}, {productId,quantity}]    
        public int? CustomerId { get; set; }
        public int? EmployeeId { get; set; }
        [ForeignKey("EmployeeId")]
        public Employee Employee { get; set; }
        [ForeignKey("CustomerId")]
        public Customer Customer { get; set; }
    }
}
