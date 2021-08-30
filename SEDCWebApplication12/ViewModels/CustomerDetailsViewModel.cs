using SEDCWebApplication12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Models;

namespace SEDCWebApplication12.ViewModels
{
    public class CustomerDetailsViewModel
    {
        public CustomerDTO Customer { get; set; }

        public string PageTitle { get; set; }
    }
}
