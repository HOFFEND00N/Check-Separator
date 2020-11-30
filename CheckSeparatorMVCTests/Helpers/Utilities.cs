using CheckSeparatorMVC.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CheckSeparatorMVC.Models;

namespace CheckSeparatorMVCTests.Classes
{
    public static class Utilities
    {
        public static void InitializeDbForTests(CheckSeparatorMvcContext db)
        {
            db.Users.AddRange(InintializeUsers());
            db.Checks.AddRange(InintializeChecks());
            db.Product.AddRange(InintializeProducts());
            db.productUsers.AddRange(InintializeProductUsers());
            db.checkUsers.AddRange(InintializeCheckUsers());
            db.SaveChanges();
        }

        public static List<User> InintializeUsers()
        {
            return new List<User>()
            {
                new User(){Id="780e1bc8-910f-43a6-8d1d-95617c14108f", Email="a@a", UserName = "Test user"},
            };
        }

        public static List<Check> InintializeChecks()
        {
            return new List<Check>()
            {
                new Check(){CheckId=1, OwnerId = "1" }
            };
        }

        public static List<Product> InintializeProducts()
        {
            return new List<Product>()
            {
                new Product(){ CheckId = 1, ProductId = 1, Amount = 1, Name = "apple" , Price = 10}
            };
        }

        public static List<ProductUser> InintializeProductUsers()
        {
            return new List<ProductUser>()
            {
                new ProductUser(){ProductId = 1, UserId = "780e1bc8-910f-43a6-8d1d-95617c14108f"}
            };
        }

        public static List<CheckUser> InintializeCheckUsers()
        {
            return new List<CheckUser>()
            {
                new CheckUser(){ UserId = "780e1bc8-910f-43a6-8d1d-95617c14108f", CheckId = 1}  
            };
        }
    }
}
