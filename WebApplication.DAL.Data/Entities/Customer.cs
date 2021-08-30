using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.DAL.Data.Entities;

namespace SEDCWebApplication12.Models
{
    public class Customer : User
    {
        public Customer(int? id)
               : base(id)
        {
        }

        [Required(ErrorMessage = "Ime je obavezno")]
       
        public string Name { get; set; }

        public int ContactId { get; set; }

    }
}
