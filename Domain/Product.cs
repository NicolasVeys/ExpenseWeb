using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Domain
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IList<ExpenseProduct> ExpenseProducts { get; set; }

    }
}
