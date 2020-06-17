using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Domain
{
    public class PaymentStatus
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public List<Expense> Expenses { get; set; }
    }

}

