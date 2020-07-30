using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Models
{
    public class ProductAndUserViewModel
    {
        public List<Product> Products { get; set; }

        public string UserName { get; set; }
        public ProductAndUserViewModel()
        {
            Products = new List<Product>();
            UserName = "";
        }

        public ProductAndUserViewModel(List<Product> products, string name)
        {
            Products = products;
            UserName = name;
        }

    }
}
