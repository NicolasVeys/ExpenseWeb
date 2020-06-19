using ExpenseWeb.Database;
using ExpenseWeb.Domain;
using ExpenseWeb.Migrations;
using ExpenseWeb.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
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
            IEnumerable<Expense> expencesFromDb = await _expenseDatabase.Expenses
                .Include(x => x.PaymentStatus)
                .Include(e => e.ExpenseProducts)
                .ThenInclude(p => p.Product).Where(expense => expense.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier)).ToListAsync();
            List<ExpenseListViewModel> expences = new List<ExpenseListViewModel>();
            foreach (var expence in expencesFromDb)
            {
                string productList = "";
                foreach (var product in expence.ExpenseProducts)
                {
                    productList += product.Product.Name + " ";
                }
                expences.Add(new ExpenseListViewModel()
                {
                    Id = expence.Id,
                    Amount = expence.Amount,
                    Date = expence.Date,
                    Description = expence.Description,
                    Category = expence.Category,
                    PaymentStatus = expence.PaymentStatus.Status,
                    ProductName = productList,
                });
            }
            return View(expences);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            ExpenseCreateViewModel NewExpense = new ExpenseCreateViewModel();

            IEnumerable<PaymentStatus> paymentStatusus = await _expenseDatabase.paymentStatuses.ToListAsync();
            foreach (var Status in paymentStatusus)
            {
                NewExpense.PaymentStatusus.Add(new SelectListItem() { Text = Status.Status, Value = Status.Id.ToString() });
            }
            IEnumerable<Product> expenseProducts = await _expenseDatabase.Products.ToListAsync();
            foreach (var Product in expenseProducts)
            {
                NewExpense.Products.Add(new SelectListItem() { Text = Product.Name, Value = Product.Id.ToString() });
            }
            return View(NewExpense);
        }

        [HttpPost]
        public IActionResult Create(ExpenseCreateViewModel NewExpense)
        {
            List<ExpenseProduct> products = new List<ExpenseProduct>();
            foreach (var productId in NewExpense.SelectedProductId)
            {
                products.Add(new ExpenseProduct()
                {
                    ProductId = productId
                });
            }
            _expenseDatabase.Expenses.Add(new Expense
            {
                Amount = NewExpense.Amount,
                Date = NewExpense.Date,
                Description = NewExpense.Description,
                Category = NewExpense.Category,
                PaymentStatusId = NewExpense.PaymentStatusId,
                ExpenseProducts = products,
                UserId = User.FindFirstValue(ClaimTypes.NameIdentifier)
            });
            _expenseDatabase.SaveChanges();
            return RedirectToAction("Index");
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Expense expenseFromDb = await _expenseDatabase.Expenses.Include(expense => expense.ExpenseProducts).FirstOrDefaultAsync(m => m.Id == id);
            if (expenseFromDb.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {

                ExpenseEditViewModel vm = new ExpenseEditViewModel
                {
                    Amount = expenseFromDb.Amount,
                    Date = expenseFromDb.Date,
                    Description = expenseFromDb.Description,
                    Category = expenseFromDb.Category,
                    PaymentStatusId = expenseFromDb.PaymentStatusId,
                    SelectedProducts = expenseFromDb.ExpenseProducts.Select(x => x.ProductId).ToArray(),
                };
                var products = await _expenseDatabase.Products.ToListAsync();
                vm.Products = products.Select(tag => new SelectListItem() { Value = tag.Id.ToString(), Text = tag.Name }).ToList();

                return View(vm);
            }
            else
            {
                return RedirectToAction("NoSneakyStuff");
            }


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
            expenseFromDb.PaymentStatusId = vm.PaymentStatusId;


            _expenseDatabase.Expenses.Update(expenseFromDb);
            _expenseDatabase.SaveChanges();

            return RedirectToAction("Index");
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            Expense domainExpense = await _expenseDatabase.Expenses.FindAsync(id);
            if (domainExpense.UserId == User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                ExpenseDeleteViewModel vm = new ExpenseDeleteViewModel()
                {
                    Id = domainExpense.Id,
                    Amount = domainExpense.Amount,
                    Description = domainExpense.Description,
                    Date = domainExpense.Date
                };
                return View(vm);
            }
            else
            {
                return RedirectToAction("NoSneakyStuff");
            }
        }

        public IActionResult ConfirmDelete(int id)
        {
            var expenseFromDb = _expenseDatabase.Expenses.Find(id);
            _expenseDatabase.Expenses.Remove(expenseFromDb);
            _expenseDatabase.SaveChanges();

            return RedirectToAction("");
        }
        public IActionResult NoSneakyStuff()
        {
            return View("NoSneakyStuff");
        }
    }
}
