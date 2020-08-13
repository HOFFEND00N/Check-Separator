using System.Collections.Generic;

namespace CheckSeparatorMVC.Models
{
    public class ProductsAndUserViewModel
    {
        public int Id { get; set; }

        public List<Product> Products { get; set; }

        public string UserName { get; set; }
        public ProductsAndUserViewModel()
        {
            Products = new List<Product>();
            UserName = "";
        }

        public ProductsAndUserViewModel(List<Product> products, string name)
        {
            Products = products;
            UserName = name;
        }

    }
}
