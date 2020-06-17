using ExpenseWeb.Database;
using ExpenseWeb.Domain;
using ExpenseWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

//namespace ExpenseWeb.Controllers
//{
//    public class StatisticsController : Controller
//    {
//        private readonly IExpenseDatabase _expenseDatabase;
//        public StatisticsController(IExpenseDatabase expenseDatabase)
//        {
//            _expenseDatabase = expenseDatabase;
//        }


//        [HttpGet]
//        public IActionResult Stats()
//        {
//            IEnumerable<Expense> expenceFromDb = _expenseDatabase.GetExpenses();
//            ExpenseStatsViewModel stats = new ExpenseStatsViewModel();
//            stats.MaxExpense = expenceFromDb.Max(x => x.Amount);

//            return View(stats);
//        }
//    }
//}
