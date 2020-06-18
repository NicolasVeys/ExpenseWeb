using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Domain
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public int PaymentStatusId { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public List<ExpenseProduct> ExpenseProducts { get; set; }

    }
}
