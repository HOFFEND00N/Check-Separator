using System.Linq;
using CheckSeparatorMVC.Data;
using CheckSeparatorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data;

namespace CheckSeparatorMVC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly CheckSeparatorMvcContext context;
        public ProductsController(CheckSeparatorMvcContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult CheckProducts(int CheckId)
        {
            var Check = context.Checks.Find(CheckId);
            if (Check is null)
                return View("Error", new ErrorViewModel { RequestId = "Wrong Id" });
            Check.Products = context.Product.Where(product => product.CheckId == CheckId).ToList();
            return View(Check);
        }

        public IActionResult FindCheck(int checkId)
        {
            return RedirectToAction(nameof(CheckProducts), new { CheckId = checkId });
        }

        public IActionResult CreateCheck()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult CreateCheck(string name)
        {
            var tmp = new Check(name);
            context.Checks.Add(tmp);
            context.SaveChanges();
            return RedirectToAction(nameof(CheckProducts), new { CheckId = tmp.CheckId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ViewAddProduct(int CheckId)
        {
            return View("AddProduct", new Product(CheckId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Product product)
        {
            context.Product.Add(product);
            context.Checks.Find(product.CheckId).Products.Add(product);
            context.SaveChanges();
            return RedirectToAction(nameof(CheckProducts), new { CheckId = product.CheckId });
        }

        public IActionResult DeleteProduct(int id)
        {
            var product = context.Product.FirstOrDefault(p => p.ProductId == id);
            return View(product);
        }

        [HttpPost, ActionName("DeleteProduct")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var product = context.Product.Find(id);
            context.Product.Remove(product);
            context.SaveChanges();
            return RedirectToAction(nameof(CheckProducts), new { CheckId = product.CheckId });
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
            return RedirectToAction(nameof(CheckProducts), new { CheckId = product.CheckId });
        }

        //public IActionResult CalculateCheck()
        //{
        //    Dictionary<int, int> productCnt = new Dictionary<int, int>();
        //    foreach (var item in context.Check_Product.ToList())
        //    {
        //        if (productCnt.ContainsKey(item.ProductId))
        //            productCnt[item.ProductId]++;
        //        else
        //            productCnt.Add(item.ProductId, 1);
        //    }

        //    List<Transactions> transactions = new List<Transactions>();
        //    foreach (var item in context.Check_Product.ToList())
        //    {
        //        if (productCnt.ContainsKey(item.ProductId))
        //        {
        //            var product = context.Product.Find(item.ProductId);
        //            var tmp = (product.Price * product.Amount) / productCnt[item.ProductId];
        //            transactions.Add(new Transactions(item.UserName, "admin", tmp));
        //        }
        //    }
        //    return View("Transactions", transactions);
        //}

        public IActionResult MakeUrl(int CheckId)
        {
            var url = new Url();
            url.Address = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + "/Products/SelectProducts/" + CheckId;
            return View(url);
        }

        public IActionResult SelectProducts(int CheckId)
        {
            var Check = context.Checks.Find(CheckId);
            if (Check is null)
                return View("Error", new ErrorViewModel { RequestId = "Wrong Id" });
            Check.Products = context.Product.Where(product => product.CheckId == CheckId).ToList();
            return View(Check);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmSelectedProducts(Check model, string userName)
        {
            var user = new Models.User(userName);
            context.Users.Add(user);
            context.SaveChanges();
            context.checkUsers.Add(new CheckUser(model.CheckId, user.UserId));
            foreach(var i in model.Products)
                if (i.IsChecked == true)
                    context.productUsers.Add(new ProductUser(user.UserId, i.ProductId));
            context.SaveChanges();
            return View("Index");
        }
    }
}
