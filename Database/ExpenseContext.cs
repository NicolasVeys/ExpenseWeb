using ExpenseWeb.Domain;
using ExpenseWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Database
{
    public class ExpenseContext : IdentityDbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options)
        {
        }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<PaymentStatus> paymentStatuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ExpenseProduct> expenseProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PaymentStatus>().HasData(new PaymentStatus { Id = 1, Status = "Already payed" });
            modelBuilder.Entity<PaymentStatus>().HasData(new PaymentStatus { Id = 2, Status = "Not payed" });

            modelBuilder.Entity<Product>().HasData(new Product { Id = 1, Name = "Sla" });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 2, Name = "Tomaat" });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 3, Name = "ui" });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 4, Name = "kip" });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 5, Name = "patatten" });
            modelBuilder.Entity<Product>().HasData(new Product { Id = 6, Name = "Pizza" });

            modelBuilder.Entity<ExpenseProduct>().HasKey(sc => new { sc.ExpenseId, sc.ProductId });
        }
    }
}
