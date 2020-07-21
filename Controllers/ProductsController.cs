using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckSeparatorMVC.Data;
using CheckSeparatorMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    }
}
