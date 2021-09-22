using System;
using System.Collections.Generic;
using System.Text;
using WebApplication.CodeFirst.Entities;

namespace WebApplication.CodeFirst.Interfaces
{
    public interface IUserDAL
    {
        User GetUserByUserNameAndPassword(string userName, string password);
    }
}
