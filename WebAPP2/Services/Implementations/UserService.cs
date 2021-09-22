using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPP2.Services.Interfaces;
using WebApplication.BLL.Logic.Interfaces;
using WebApplication.BLL.Logic.Models;


namespace WebAPP2.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUserManager _userManager;

        public UserService(IUserManager userManager)
        {
            _userManager = userManager;
        }
        public UserDTO Authenticate(string userName, string password)
        {
            UserDTO userDTO = _userManager.GetUserByUserNameAndPassword(userName, password);
            // JWT token generate

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("pizzashop pizzashop pizzashop pizzashop pizzashop");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userDTO.Id.ToString()),
                    new Claim(ClaimTypes.Role, "admin")
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)

            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            userDTO.Token = tokenHandler.WriteToken(token);

            return userDTO;
        }
    }
}
