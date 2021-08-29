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
        [RegularExpression(@"^(([A-za-z]+[\s]{1}[A-za-z]+)|([A-Za-z]+))$",
           ErrorMessage = "Please enter a valid Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Email id is required")]
        [RegularExpression(@"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                            ErrorMessage = "Please enter a valid email address")]
        public string Email { get; set; }
        public RoleEnum Role { get; set; }

        public IFormFile Photo { get; set; }
    }
}
