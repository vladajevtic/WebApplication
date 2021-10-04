using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication.BLL.Logic.Models;

namespace WebAPP2.Services.Interfaces
{
    public interface IUserService
    {
        UserDTO Authenticate(string userName, string password);
        UserDTO GetById(int id);
    }
}
