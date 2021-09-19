using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.CodeFirst.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ImagePath { get; set; }
    }
}
