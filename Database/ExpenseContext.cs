using ExpenseWeb.Domain;
using ExpenseWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Database
{
    public class ExpenseContext : DbContext
    {
        public ExpenseContext(DbContextOptions<ExpenseContext> options) : base(options)
        {
        }
        public DbSet<Expense> Expenses { get; set; }

        public DbSet<PaymentStatus> paymentStatuses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentStatus>().HasData(new PaymentStatus { Id = 1, Status = "Already payed" });
            modelBuilder.Entity<PaymentStatus>().HasData(new PaymentStatus { Id = 2, Status = "Not payed" });
        }
    }
}
