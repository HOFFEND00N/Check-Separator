using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Models
{
    public class ProductUser
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ProductUser(string userId, int productId)
        {
            UserId = userId;
            ProductId = productId;
        }

        public ProductUser()
        {
        }
    }
}
