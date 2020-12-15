using CheckSeparatorMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Data
{
    // not used
    public class ProductDbManupulator
    {
        private CheckSeparatorMvcContext context;

        public ProductDbManupulator (CheckSeparatorMvcContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product product)
        {
            context.Product.Add(product);
            context.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            context.Product.Remove(product);
            context.SaveChanges();
        }

        public void EditProduct(Product product)
        {
            context.Product.Update(product);
            context.SaveChanges();
        }
    }
}
