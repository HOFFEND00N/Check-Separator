using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Models
{
    public class ProductAndUserViewModel
    {
        public List<Product> Products { get; set; }

        public List<string> Names { get; set; }
        public ProductAndUserViewModel()
        {
            Products = new List<Product>();
        }

        public ProductAndUserViewModel(List<Product> products, List<string> names)
        {
            Products = products;
            Names = names;
        }

    }
}
