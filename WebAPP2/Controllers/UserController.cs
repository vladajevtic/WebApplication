using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPP2.Services.Interfaces;
using WebApplication.BLL.Logic.Models;

namespace WebAPP2.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    
    
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public UserController(IUserService userService, IWebHostEnvironment webHostEnvironment)
        {
            _userService = userService;
            _webHostEnvironment = webHostEnvironment;
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Authenticate([FromBody] AuthenticateDTO authenticateModel)
        {
            UserDTO user = _userService.Authenticate(authenticateModel.UserName, authenticateModel.Password);
            if (user == null)
                return BadRequest(new { message = "User name or password is incorect" });
            return Ok(user);
        }
    }
}
