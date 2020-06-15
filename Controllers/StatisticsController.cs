using ExpenseWeb.Database;
using ExpenseWeb.Domain;
using ExpenseWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Controllers
{
    public class StatisticsController : Controller
    {
        private readonly IExpenseDatabase _expenseDatabase;
        public StatisticsController(IExpenseDatabase expenseDatabase)
        {
            _expenseDatabase = expenseDatabase;
        }
        public IActionResult Index()
        {
            IEnumerable<Expense> expenceFromDb = _expenseDatabase.GetExpenses();
            List<ExpenseStatsViewModel> expences = new List<ExpenseStatsViewModel>();
            foreach (var expence in expenceFromDb)
            {
                expences.Add(new ExpenseStatsViewModel()
                {
                    Id = expence.Id,
                    Amount = expence.Amount,
                    Date = expence.Date,
                    Description = expence.Description,
                    Category = expence.Category
                });
            }
            return View(expences);
        }
    }
}
