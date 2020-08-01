using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Models
{
    public class ProductViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public ProductViewModel()
        {
            Products = new List<Product>();
        }

        public ProductViewModel(IEnumerable<Product> products)
        {
            Products = products;
        }
    }
}
