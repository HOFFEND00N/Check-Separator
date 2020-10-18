using System.Linq;
using CheckSeparatorMVC.Data;
using CheckSeparatorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using CheckSeparatorMVC.ViewModels;
using System;
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
            var checkIds = context.checkUsers
                .Where(cu => cu.UserId == userId)
                    .Select(c => c.CheckId)
                        .ToList();

            var checks = context.Checks.Where(c => checkIds.Contains(c.CheckId));
            return View(checks);
        }

        public IActionResult CheckProducts(string CheckId)
        {
            var userId = userManager.GetUserId(User);

            var Check = context.Checks.Include(c => c.Products).FirstOrDefault(c => c.CheckId.ToString() == CheckId);

            if (Check is null)
                return View("Error", new ErrorViewModel { RequestId = "Wrong Id" });

            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            if (!UserInCheck(Check, user))
                AddUserToCheck(Check, user);

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
        public IActionResult AddUserToCheck(string userId, int checkId)
        {
            if (context.Users.FirstOrDefault(u => u.Id == userId) == null)
                return View("Error", new ErrorViewModel { RequestId = "Wrong Id" });
            context.checkUsers.Add(new CheckUser(checkId, userId));
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
            context.Checks.Update(model);
            foreach (var i in model.Products)
            {
                var productUser = new ProductUser(userId, i.ProductId);
                if (context.productUsers.FirstOrDefault(pu => pu.ProductId == productUser.ProductId && 
                        pu.UserId == productUser.UserId) == null && i.IsChecked == true)
                    context.productUsers.Add(productUser);
                if (context.productUsers.FirstOrDefault(pu => pu.ProductId == productUser.ProductId && 
                        pu.UserId == productUser.UserId) != null && i.IsChecked == false)
                    context.productUsers.Remove(productUser);
            }
            context.SaveChanges();
            return RedirectToAction(nameof(CheckProducts), new { model.CheckId });
        }
    }
}
