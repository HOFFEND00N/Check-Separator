using CheckSeparatorMVC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheckSeparatorMVC.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }

        [DataType(DataType.Currency)]
        [Range(1, 1000000)]
        [Required]
        public double Price { get; set; }

        [Range(1, 1000000)]
        [Required]
        public int Amount { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        public int CheckId { get; set; }

        public Check Check { get; set; }

        public bool IsChecked { get; set; }

        public List<ProductUser> ProductUsers { get; set; }

        public ProductViewModel()
        {
            ProductId = 0;
            Price = 0;
            Amount = 0;
            Name = "";
        }

        public ProductViewModel(int checkId)
        {
            CheckId = checkId;
        }

        public ProductViewModel(int id, string name, double price, int amount)
        {
            ProductId = id;
            Price = price;
            Name = name;
            Amount = amount;
        }

        public ProductViewModel(Product product)
        {
            ProductId = product.ProductId;
            Price = product.Price;
            Name = product.Name;
            Amount = product.Amount;
        }
    }
}
