using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckSeparatorMVC.Data;
using CheckSeparatorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace CheckSeparatorMVC.Controllers
{
    public class ProductsController : Controller
    {
        private List<ProductAndUserViewModel> userAndPurchase = new List<ProductAndUserViewModel>();

        private readonly CheckSeparatorMvcContext context;
        public ProductsController(CheckSeparatorMvcContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View(context.Product.ToList());
        }

        public IActionResult AddProduct()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddProduct(Product product)
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
        public async Task<IActionResult> EditProduct(Product product)
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
            foreach (var i in context.Product)
            {
                sum += i.Price * i.Amount;
            }
            var tmp = sum / check.Count;
            var TransactionList = new List<Transactions>();
            foreach (var i in check.Names.Split(" "))
            {
                TransactionList.Add(new Transactions(i, check.Master, tmp));
            }
            return View("SelectProducts", context.Product.ToList());
        }

        public IActionResult MakeUrl()
        {
            var url = new Url();
            url.Address = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + "/Products/EnterUserName";
            return View(url);
        }

        public IActionResult SelectProducts(ProductAndUserViewModel model)
        {
            return View(new ProductAndUserViewModel(context.Product.ToList(), model.UserName));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmSelectedProducts(string userName, Product[] product)
        {
            //userAndPurchase.Add(model);
            return View("SelectProducts");
        }

        public IActionResult EnterUserName()
        {
            return View();
        }
    }
}
 