﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Models
{
    public class ProductUser
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public ProductUser(int userId, int productId)
        {
            UserId = userId;
            ProductId = productId;
        }
    }
}