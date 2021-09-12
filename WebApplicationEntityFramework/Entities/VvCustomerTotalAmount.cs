using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplicationEntityFramework.Entities
{
    public partial class VvCustomerTotalAmount
    {
        public int CustomerId { get; set; }
        public string CustomerName { get; set; }
        public decimal? TotalAmount { get; set; }
    }
}
