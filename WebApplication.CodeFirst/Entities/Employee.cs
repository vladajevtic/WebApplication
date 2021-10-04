using System;
using System.Collections.Generic;
using System.Text;

namespace WebApplication.CodeFirst.Entities
{
    public class Employee : User
    {
       
        public string Name { get; set; }

        public string Gender { get; set; }       

        public DateTime DateOfBirth { get; set; }
    }
}
