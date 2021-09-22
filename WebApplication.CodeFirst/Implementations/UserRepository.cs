using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApplication.CodeFirst.Entities;
using WebApplication.CodeFirst.Interfaces;

namespace WebApplication.CodeFirst.Implementations
{
    public class UserRepository : IUserDAL
    {
        private IConfiguration Configuration { get; set; }
        public UserRepository(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public User GetUserByUserNameAndPassword(string userName, string password)
        {
            var optionBuilder = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer(Configuration.GetConnectionString("SEDC2"));
            using (var db = new ApplicationDbContext(optionBuilder.Options))
            {
                User result = db.Users.First( u => u.UserName == userName && u.Password == password);
                return result;
            }
        }
    }
}
