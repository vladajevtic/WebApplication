using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApplication.BLL.Logic.Models
{
    public class CustomerDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Ime je obavezno")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Email id is required")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        public int ContactId { get; set; }
        public string ImagePath { get; set; }
    }
}
