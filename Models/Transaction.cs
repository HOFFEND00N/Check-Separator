using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Models
{
    public class Transaction
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

        public Transaction(string wherefrom, string where, double price)
        {
            Sender = wherefrom;
            Recipient = where;
            TransactionSize = price;
        }

        public static List<Transaction> MakeTransactionList(List<Product> products)
        {
            List<Transaction> transactions = new List<Transaction>();
            foreach (var item in products)
            {
                var cntUsersToSplit = item.ProductUsers.Count;
                if (cntUsersToSplit != 0)
                {
                    var transactionSize = (item.Price * item.Amount) / item.ProductUsers.Count;
                    foreach (var j in item.ProductUsers)
                        transactions.Add(new Transaction(j.User.Name, item.Check.OwnerName,
                            transactionSize));
                }
            }
            return transactions;
        }
    }
}
