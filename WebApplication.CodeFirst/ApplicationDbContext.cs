using Microsoft.EntityFrameworkCore;
using System;
using WebApplication.CodeFirst.Entities;

namespace WebApplication.CodeFirst
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options)
        {

        }
        public  DbSet<Customer> Customers { get; set; }
        public  DbSet<Employee> Employees { get; set; }
        public  DbSet<Order> Orders { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
