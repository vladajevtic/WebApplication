using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLL.Logic.Models;

namespace WebApplication.BLL.Logic.Interfaces
{
    public interface IUserManager
    {
        UserDTO GetUserByUserNameAndPassword(string userName, string password);
    }
}
