using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using WebApplication.CodeFirst.Entities;

namespace WebApplication.BLL.Logic.Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]
        public string Name { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }
        public string ImagePath { get; set; }
        public List<Order> Orders { get; set; }
    }
}
