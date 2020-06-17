using ExpenseWeb.Database;
using ExpenseWeb.Domain;
using ExpenseWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseWeb.Controllers
{
    public class ExpenseController : Controller
    {
        private readonly ExpenseContext _expenseDatabase;
        public ExpenseController(ExpenseContext expenseDatabase)
        {
            _expenseDatabase = expenseDatabase;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<Expense> expencesFromDb = await _expenseDatabase.Expenses.Include(x => x.PaymentStatus).ToListAsync();
            List<ExpenseListViewModel> expences = new List<ExpenseListViewModel>();
            foreach (var expence in expencesFromDb)
            {
                expences.Add(new ExpenseListViewModel()
                {
                    Id = expence.Id,
                    Amount = expence.Amount,
                    Date = expence.Date,
                    Description = expence.Description,
                    Category = expence.Category,
                    PaymentStatus = expence.PaymentStatus.Status,
                });
            }
            return View(expences);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ExpenseCreateViewModel NewExpense = new ExpenseCreateViewModel();
            IEnumerable<PaymentStatus> paymentStatusus = await _expenseDatabase.paymentStatuses.ToListAsync();
            foreach (var Status in paymentStatusus)
            {
                NewExpense.PaymentStatusus.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() {Text = Status.Status, Value = Status.Id.ToString()});
            }
            return View(NewExpense);
        }

        [HttpPost]
        public IActionResult Create(ExpenseCreateViewModel NewExpense)
        {

            _expenseDatabase.Expenses.Add(new Expense
            {
                Amount = NewExpense.Amount,
                Date = NewExpense.Date,
                Description = NewExpense.Description,
                Category = NewExpense.Category,
                PaymentStatusId = NewExpense.PaymentStatusId,
            });
            _expenseDatabase.SaveChanges();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Edit(int id)
        {
            Expense expenseFromDb = await _expenseDatabase.Expenses.FindAsync(id);
            IEnumerable<PaymentStatus> paymentStatusus = await _expenseDatabase.paymentStatuses.ToListAsync();
            foreach (var Status in paymentStatusus)
            {
                expenseFromDb.PaymentStatusus.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Text = Status.Status, Value = Status.Id.ToString() });
            }

            ExpenseEditViewModel vm = new ExpenseEditViewModel
            {
                Amount = expenseFromDb.Amount,
                Date = expenseFromDb.Date,
                Description = expenseFromDb.Description,
                Category = expenseFromDb.Category,
                PaymentStatusId = expenseFromDb.PaymentStatusId
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
            var expenseFromDb = _expenseDatabase.Expenses.Find(id);

            expenseFromDb.Amount = vm.Amount;
            expenseFromDb.Date = vm.Date;
            expenseFromDb.Description = vm.Description;
            expenseFromDb.Category = vm.Category;

            _expenseDatabase.Expenses.Update(expenseFromDb);
            _expenseDatabase.SaveChanges();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            Expense domainExpense = await _expenseDatabase.Expenses.FindAsync(id);
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
            var expenseFromDb = _expenseDatabase.Expenses.Find(id);
            _expenseDatabase.Expenses.Remove(expenseFromDb);
            _expenseDatabase.SaveChanges();

            return RedirectToAction("");
        }
    }
}
