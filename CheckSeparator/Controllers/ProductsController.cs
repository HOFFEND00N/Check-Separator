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

            var checks = DbManipulator.GetUserChecks(context, userId);
            return View(checks);
        }

        public IActionResult CheckDetails(string CheckId)
        {
            var userId = userManager.GetUserId(User);

            var Check = context.Checks.Include(c => c.Products).FirstOrDefault(c => c.CheckId.ToString() == CheckId);

            if (Check is null)
                return View("Error", new ErrorViewModel { RequestId = "Wrong Id" });

            CheckViewModel checkViewModel = new CheckViewModel(Check);

            foreach (var i in context.productUsers)
            {
                if (Check.Products.Contains(i.Product) && i.UserId == userId)
                    checkViewModel.Products.FirstOrDefault(p => p.ProductId == i.ProductId).IsChecked = true;
            }

            return View(new CheckAndUserViewModel(checkViewModel, context.Users.FirstOrDefault(u => u.Id == userId)));
        }

        public IActionResult FindCheck(string checkId)
        {
            return RedirectToAction(nameof(CheckDetails), new { CheckId = checkId });
        }

        public IActionResult CreateCheck()
        {
            var userId = userManager.GetUserId(User);
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            var check = new Check(user);
            context.Checks.Add(check);
            context.checkUsers.Add(new CheckUser(check, user));
            context.SaveChanges();
            return RedirectToAction(nameof(CheckDetails), new { check.CheckId });
        }

        public IActionResult ViewAddProduct(int CheckId)
        {
            return View(new Product(CheckId));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddProduct(Product product)
        {
            var userId = userManager.GetUserId(User);
            var user = context.Users.FirstOrDefault(u => u.Id == userId);
            context.Product.Add(product);
            context.productUsers.Add(new ProductUser(user, product));
            context.SaveChanges();
            return RedirectToAction(nameof(CheckDetails), new { product.CheckId });
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
            var product = context.Product.FirstOrDefault(p => p.ProductId == id);
            context.Product.Remove(product);
            context.SaveChanges();
            return RedirectToAction(nameof(CheckDetails), new { product.CheckId });
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
            return RedirectToAction(nameof(CheckDetails), new { product.CheckId });
        }

        public IActionResult ViewAddUserToCheck(int checkId)
        {
            return View(context.Checks.FirstOrDefault(c => c.CheckId == checkId));
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
            return RedirectToAction(nameof(CheckDetails), new { checkId });
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
        public IActionResult SaveChangesInCheck(CheckViewModel model)
        {
            SetProductUsersChanges(model);
            context.SaveChanges();
            return RedirectToAction(nameof(CheckDetails), new { model.CheckId });
        }

        private void SetProductUsersChanges(CheckViewModel model)
        {
            var userId = userManager.GetUserId(User);
            foreach (var i in model.Products)
            {
                var productUser = context.productUsers.FirstOrDefault(pu => pu.ProductId == i.ProductId && pu.UserId == userId);

                var user = context.Users.FirstOrDefault(u => u.Id == userId);
                var product = context.Product.FirstOrDefault(p => p.ProductId == i.ProductId);

                if (productUser == null && i.IsChecked == true)
                    context.productUsers.Add(new ProductUser(user, product));
                if (productUser != null && i.IsChecked == false)
                    context.productUsers.Remove(productUser);
            }
        }
    }
}
