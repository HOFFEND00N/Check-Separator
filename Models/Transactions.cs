using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Models
{
    public class Transactions
    {
        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Sender { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z]*$")]
        [Required]
        [StringLength(100, MinimumLength = 1)]
        public string Recipient { get; set; }

        [Range(1, 100000000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18, 2)")]
        public double TransactionSize { get; set; }

        public Transactions(string wherefrom, string where, double price)
        {
            Sender = wherefrom;
            Recipient = where;
            TransactionSize = price;
        }
    }
}
