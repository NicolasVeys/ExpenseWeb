using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Domain
{
    public class ExpenseProduct
    {
        public int ExpenseId { get; set; }
        public Expense Expense { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
