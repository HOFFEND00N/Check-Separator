using System.Collections.Generic;

namespace CheckSeparatorMVC.Models
{
    public class ProductAndUserViewModel
    {
        public IEnumerable<Product> Products { get; set; }

        public string UserName { get; set; }
        public ProductAndUserViewModel()
        {
            Products = new List<Product>();
            UserName = "";
        }

        public ProductAndUserViewModel(IEnumerable<Product> products, string name)
        {
            Products = products;
            UserName = name;
        }

    }
}
