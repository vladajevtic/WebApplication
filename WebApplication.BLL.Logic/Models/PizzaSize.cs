using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication12.Models
{
    public enum PizzaSize
    {
        [Display(Name ="small")]
        Small,
        Medium,
        Large
    }
}
