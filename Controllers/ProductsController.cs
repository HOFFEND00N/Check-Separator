using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckSeparatorMVC.Data;
using CheckSeparatorMVC.Models;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace CheckSeparatorMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CheckSeparatorMvcContext context;
        public ProductsController(CheckSeparatorMvcContext context)
        {
            this.context = context;
        }
       
        public async Task<IActionResult> Index()
        {
            return View(await context.Product.ToListAsync());
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct([Bind("Price,Amount,Name")] Product product)
        {
            context.Add(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await context.Product.FirstOrDefaultAsync(p => p.Id == id);
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var product = await context.Product.FindAsync(id);
            context.Product.Remove(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditProduct(int id)
        {
            var product = await context.Product.FindAsync(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(int id, [Bind("Price,Amount,Name,Id")] Product product)
        {
            context.Product.Update(product);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CalculateCheck()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CalculateCheck(Check check)
        {
            double sum = 0;
            foreach(var i in context.Product)
            {
                sum += i.Price * i.Amount;
            }
            var tmp = sum / check.Count;
            var TransactionList = new List<Transactions>();
            foreach(var i in check.Names.Split(" "))
            {
                TransactionList.Add(new Transactions(i, check.Master, tmp));
            }
            return View("SelectProducts", new ProductAndUserViewModel(context.Product.ToList(),
                check.Names.Split(" ").ToList()));
        }

        public IActionResult MakeUrl()
        {
            var url = new Url();
            url.Address = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + "/Products/SelectProducts";
            return View(url);
        }

        public IActionResult SelectProducts()
        {
            return View(context.Product.ToList());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmSelectedProducts(FormCollection formCollection)
        {
            return View("SelectProducts");
        }
    }
}
