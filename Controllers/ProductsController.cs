using System.Collections.Generic;
using System.Linq;
using CheckSeparatorMVC.Data;
using CheckSeparatorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace CheckSeparatorMVC.Controllers
{
    public class ProductsController : Controller
    {
        public int curCheckId = 1;
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
        public IActionResult AddProduct(Product product)
        {
            context.Product.Add(product);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = context.Product.FirstOrDefault(p => p.Id == id);
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = context.Product.Find(id);
            List<Check_Product> checkProductToDelete = new List<Check_Product>();
            foreach (var item in context.Check_Product)
                if (item.ProductId == product.Id)
                    context.Check_Product.Remove(item);
            context.Product.Remove(product);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult EditProduct(int id)
        {
            var product = context.Product.Find(id);
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditProduct(Product product)
        {
            context.Product.Update(product);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult CalculateCheck()
        {
            Dictionary<int, int> productCnt = new Dictionary<int, int>();
            foreach (var item in context.Check_Product.ToList())
            {
                if (productCnt.ContainsKey(item.ProductId))
                    productCnt[item.ProductId]++;
                else
                    productCnt.Add(item.ProductId, 1);
            }

            List<Transactions> transactions = new List<Transactions>();
            foreach (var item in context.Check_Product.ToList())
            {
                if (productCnt.ContainsKey(item.ProductId))
                {
                    var product = context.Product.Find(item.ProductId);
                    var tmp = (product.Price * product.Amount) / productCnt[item.ProductId];
                    transactions.Add(new Transactions(item.UserName, "admin", tmp));
                }
            }
            return View("Transactions", transactions);
        }

        public IActionResult MakeUrl()
        {
            var url = new Url();
            url.Address = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + "/Products/SelectProducts";
            return View(url);
        }

        public IActionResult SelectProducts()
        {
            return View(new ProductViewModel(context.Product.ToList()));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmSelectedProducts(ProductsAndUserViewModel model)
        {
            context.Checks.Find(1).Names += model.UserName;
            foreach (var i in model.Products)
            {
                if (i.IsChecked == true)
                    context.Check_Product.Add(new Check_Product(i.Id, curCheckId, model.UserName));
            }
            context.SaveChanges();
            return View("SelectProducts", new ProductViewModel(context.Product.ToList()));
        }
    }
}
