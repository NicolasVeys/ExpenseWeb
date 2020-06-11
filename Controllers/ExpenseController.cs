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
    public class ExpenseController : Controller
    {
        private readonly IExpenseDatabase _expenseDatabase;
        public ExpenseController(IExpenseDatabase expenseDatabase)
        {
            _expenseDatabase = expenseDatabase;
        }

        public IActionResult Index()
        {
            IEnumerable<Expense> expenceFromDb = _expenseDatabase.GetExpenses();
            List<ExpenseListViewModel> expences = new List<ExpenseListViewModel>();
            foreach (var expence in expenceFromDb)
            {
                expences.Add(new ExpenseListViewModel()
                {
                    Id = expence.Id,
                    Amount = expence.Amount,
                    Date = expence.Date,
                    Description = expence.Description
                });
            }
            return View(expences);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ExpeseCreateViewModel NewExpense = new ExpeseCreateViewModel();
            return View(NewExpense);
        }

        [HttpPost]
        public IActionResult Create(ExpeseCreateViewModel NewContact)
        {

            _expenseDatabase.Insert(new Expense
            {
                Amount = NewContact.Amount,
                Date = NewContact.Date,
                Description = NewContact.Description
            });
            return RedirectToAction("Index");
        }
    }
}
