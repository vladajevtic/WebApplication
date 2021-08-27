using SEDCWebApplication.BLL.Logic.Models;
using SEDCWebApplication12.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication12.ViewModels
{
    public class EmployeeDetailsViewModel
    {
        public EmployeeDTO Employee { get; set; }

        public string PageTitle { get; set; }
    }
}
