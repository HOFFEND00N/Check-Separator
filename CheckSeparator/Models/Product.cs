using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CheckSeparatorMVC.Models
{
    public class Product
    {
        public int ProductId { get; set; }

        [DataType(DataType.Currency)]
        [Range(1,1000000)]
        [Required]
        public double Price { get; set; }

        [Range(1,1000000)]
        [Required]
        public int Amount { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Name { get; set; }

        public int CheckId { get; set; }

        public Check Check { get; set; }

        public List<ProductUser> ProductUsers { get; set; }
        public Product()
        {
            ProductId = 0;
            Price = 0;
            Amount = 0;
            Name = "";
        }
        public Product(int checkId)
        {
            CheckId = checkId;
        }
        public Product(int id, string name, double price, int amount)
        {
            ProductId = id;
            Price = price;
            Name = name;
            Amount = amount;
        }
    }
}
