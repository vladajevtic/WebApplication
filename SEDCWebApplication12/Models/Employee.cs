using SEDCWebApplication.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication12.Models
{
    public class Employee
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]
        public string Name { get; set; }

        public string Email { get; set; }
        public RoleEnum Role { get; set; }

        public bool Test { get; set; }


    }
}
