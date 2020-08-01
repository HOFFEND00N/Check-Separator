using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Models
{
    public class Product
    {
        public int Id { get; set; }

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

        public Product()
        {
            Id = 0;
            Price = 0;
            Amount = 0;
            Name = "";
        }
    }
}
