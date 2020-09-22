using System.Linq;
using CheckSeparatorMVC.Data;
using CheckSeparatorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace CheckSeparatorMVC.Controllers
{
    //TODO: Honest usr authentification, Oauth 2 - protocol
    //TODO: registred user change selected products
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly CheckSeparatorMvcContext context;
        public ProductsController(CheckSeparatorMvcContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            var id = User.Claims.FirstOrDefault(x => x.Type == "Id");
            return View();
        }

        public IActionResult CheckProducts(int CheckId)
        {
            var Check = context.Checks.Include(c => c.Products).FirstOrDefault(c => c.CheckId == CheckId);
            if (Check is null)
                return View("Error", new ErrorViewModel { RequestId = "Wrong Id" });
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
        
        public IActionResult MakeUrl(int CheckId)
        {
            // url wrong, made view
            var url = new Url();
            url.Address = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value + "/Products/SelectProducts/" + CheckId;
            return View(url);
        }

        public IActionResult SelectProducts(int CheckId)
        {
            var Check = context.Checks.Include(c => c.Products).FirstOrDefault(c => c.CheckId == CheckId);
            if (Check is null)
                return View("Error", new ErrorViewModel { RequestId = "Wrong Id" });
            return View(Check);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ConfirmSelectedProducts(Check model, string userName)
        {
            //SRP
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

        public IActionResult CalculateCheck(int CheckId)
        {
            var products = context.Product
                .Where(p => p.CheckId == CheckId)
                    .Include(p => p.ProductUsers)
                        .ThenInclude(pu => pu.User)
                    .Include(p => p.Check);

            //should move code above to separate class
            List<Transactions> transactions = new List<Transactions>();
            foreach (var item in products.ToList())
            {
                var cntUsersToSplit = item.ProductUsers.Count;
                if (cntUsersToSplit != 0)
                {
                    var transactionSize = (item.Price * item.Amount) / item.ProductUsers.Count;
                    foreach (var j in item.ProductUsers)
                        transactions.Add(new Transactions(j.User.Name, item.Check.OwnerName, 
                            transactionSize));
                }
            }
            return View("Transactions", transactions);
        }
    }
}
