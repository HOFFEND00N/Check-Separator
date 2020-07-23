using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Models
{
    public class Transactions
    {
        public string Sender { get; set; }
        public string Recipient { get; set; }
        public double TransactionSize { get; set; }

        public Transactions(string wherefrom, string where, double price)
        {
            Sender = wherefrom;
            Recipient = where;
            TransactionSize = price;
        }
    }
}
