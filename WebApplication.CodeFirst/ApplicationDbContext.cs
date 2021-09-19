using Microsoft.EntityFrameworkCore;
using System;
using WebApplication.CodeFirst.Entities;

namespace WebApplication.CodeFirst
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItem>()
                .HasKey(t => new { t.OrderId, t.ProductId });

            modelBuilder.Entity<OrderItem>()
                .HasOne(pt => pt.Order)
                .WithMany(p => p.OrderItems)
                .HasForeignKey(pt => pt.OrderId);

            modelBuilder.Entity<OrderItem>()
                .HasOne(pt => pt.Product)
                .WithMany(t => t.OrderItems)
                .HasForeignKey(pt => pt.ProductId);
        }
    }
}
