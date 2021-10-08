using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.BLL.Logic.Models;

namespace WebApplication.BLL.Logic.Interfaces
{
    public interface IUserManager
    {
        UserDTO GetUserByUserNameAndPassword(string userName, string password);
        UserDTO GetById(int id);
        //UserDTO Delete(UserDTO user);
        //UserDTO Update(int id, UserDTO user);
    }
}
