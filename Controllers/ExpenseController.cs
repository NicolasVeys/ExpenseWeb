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

        public IActionResult Edit(int id)
        {
            Expense expenseFromDb = _expenseDatabase.GetExpenses(id);
            ExpenseEditViewModel vm = new ExpenseEditViewModel
            {
                Amount = expenseFromDb.Amount,
                Date = expenseFromDb.Date,
                Description = expenseFromDb.Description
            };
            return View(vm);
        }

        [HttpPost]
        public IActionResult Edit(int id, ExpenseEditViewModel vm)
        {
            if (!TryValidateModel(vm))
            {
                return View(vm);
            }
            Expense DomainExpense = new Expense()
            {
                Id = vm.Id,
                Amount = vm.Amount,
                Description = vm.Description,
                Date = vm.Date
            };
            _expenseDatabase.Update(id, DomainExpense);
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Expense domainExpense = _expenseDatabase.GetExpenses(id);
            ExpenseDeleteViewModel vm = new ExpenseDeleteViewModel()
            {
                Id = domainExpense.Id,
                Amount = domainExpense.Amount,
                Description = domainExpense.Description,
                Date = domainExpense.Date
            };
            return View(vm);
        }

        public IActionResult ConfirmDelete(int id)
        {
            _expenseDatabase.Delete(id);
            return RedirectToAction("");
        }
    }
}
