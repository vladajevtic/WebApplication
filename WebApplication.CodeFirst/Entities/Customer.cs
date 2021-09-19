using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.CodeFirst.Entities
{
    public class Customer : User
    {
        public string Name { get; set; }
        public int ContactId { get; set; }
    }
}
