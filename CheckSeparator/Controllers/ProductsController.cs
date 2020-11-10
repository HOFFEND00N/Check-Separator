using System.Linq;
using CheckSeparatorMVC.Data;
using CheckSeparatorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using CheckSeparatorMVC.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace CheckSeparatorMVC.Controllers
{
    [Authorize]
    public class ProductsController : Controller
    {
        private readonly CheckSeparatorMvcContext context;
        private UserManager<IdentityUser> userManager;
        public ProductsController(CheckSeparatorMvcContext context, UserManager<IdentityUser> manager)
        {
            this.context = context;
            userManager = manager;
        }

        public IActionResult Index()
        {
            var userId = userManager.GetUserId(User);

            var checks = GetUserChecks(userId);
            return View(checks);
        }

        private List<Check> GetUserChecks(string userId) //redundant menthod. I have property CheckUsers
        {
            var checkIds = context.checkUsers
                .Where(cu => cu.UserId == userId)
                    .Select(c => c.CheckId)
                        .ToList();

            var checks = context.Checks.Where(c => checkIds.Contains(c.CheckId));
            return checks.ToList();
        }

        private List<Check> GetUserChecks2(string userId) 
        {
            var user = context.Users
                .Include(u => u.CheckUsers)
                    .ThenInclude(cu => cu.Check)
                        .FirstOrDefault(u => u.Id == userId);
            List<Check> checks = new List<Check>();
            foreach (var i in user.CheckUsers)
            {
                checks.Add(i.Check);
            }
            return checks;
        }
        public IActionResult CheckProducts(string CheckId)
        {
            var userId = userManager.GetUserId(User);

            var Check = context.Checks.Include(c => c.Products).FirstOrDefault(c => c.CheckId.ToString() == CheckId);

            if (Check is null)
                return View("Error", new ErrorViewModel { RequestId = "Wrong Id" });

            foreach (var i in context.productUsers)
            {
                if (Check.Products.Contains(i.Product) && i.UserId == userId)
                    Check.Products.FirstOrDefault(p => p.ProductId == i.ProductId).IsChecked = true;
            }

            return View(new CheckAndUserModel(Check, context.Users.FirstOrDefault(u => u.Id == userId)));
        }

        private bool UserInCheck(Check check, User user)
        {
            if (context.checkUsers.FirstOrDefault(cu => cu.CheckId == check.CheckId && cu.UserId == user.Id) is null)
                return false;
            return true;
        }

        private void AddUserToCheck(Check check, User user)
        {
            context.checkUsers.Add(new CheckUser(check.CheckId, user.Id));
            context.SaveChanges();
        }

        public IActionResult FindCheck(string checkId)
        {
            return RedirectToAction(nameof(CheckProducts), new { CheckId = checkId });
        }

        public IActionResult CreateCheck()
        {
            var userId = userManager.GetUserId(User);
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            var check = new Check(user);
            context.Checks.Add(check);
            context.SaveChanges();
            context.checkUsers.Add(new CheckUser(check.CheckId, user.Id));
            context.SaveChanges();
            return RedirectToAction(nameof(CheckProducts), new { check.CheckId });
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
            context.productUsers.Add(new ProductUser(userManager.GetUserId(User), product.ProductId));
            context.SaveChanges();
            return RedirectToAction(nameof(CheckProducts), new { product.CheckId });
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
            return RedirectToAction(nameof(CheckProducts), new { product.CheckId });
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
            return RedirectToAction(nameof(CheckProducts), new { product.CheckId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ViewAddUserToCheck(int checkId)
        {
            return View("AddUserToCheck", context.Checks.FirstOrDefault(c => c.CheckId == checkId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUserToCheck(string userName, int checkId)
        {
            var user = context.Users.FirstOrDefault(u => u.UserName == userName);
            if (user == null)
                return View("Error", new ErrorViewModel { RequestId = "Wrong Id" });
            context.checkUsers.Add(new CheckUser(checkId, user.Id));
            context.SaveChanges();
            return RedirectToAction(nameof(CheckProducts), new { checkId });
        }

        public IActionResult CalculateCheck(int CheckId)
        {
            var products = context.Product
                .Where(p => p.CheckId == CheckId)
                    .Include(p => p.ProductUsers)
                        .ThenInclude(pu => pu.User)
                    .Include(p => p.Check);

            List<Transaction> transactions = Transaction.MakeTransactionList(products.ToList());

            return View("Transactions", transactions);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SaveChangesInCheck(Check model)
        {
            var userId = userManager.GetUserId(User);
            foreach (var i in model.Products)
            {
                var productUser = context.productUsers.FirstOrDefault(pu => pu.ProductId == i.ProductId && pu.UserId == userId);

                if (productUser == null && i.IsChecked == true)
                    context.productUsers.Add(new ProductUser(userId, i.ProductId));
                if (productUser != null && i.IsChecked == false)
                    context.productUsers.Remove(productUser);
            }
            context.Checks.Update(model);
            context.SaveChanges();
            return RedirectToAction(nameof(CheckProducts), new { model.CheckId });
        }
    }
}
