using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDCWebApplication12.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            var exeption = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            ViewBag.Ex = exeption.Error.Message;
            return View();
        }
    }
}
