using Microsoft.AspNetCore.Http;
using SEDCWebApplication.BLL.Logic.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication12.ViewModels
{
    public class EmployeeCreateViewModel
    {
        [Required(ErrorMessage = "Ime je obavezno")]
        
        public string Name { get; set; }

        [Required(ErrorMessage = "Email id is required")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        public RoleEnum Role { get; set; }

        public string Gender { get; set; }

        public IFormFile Photo { get; set; }
    }
}
