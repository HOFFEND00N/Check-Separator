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
            db.Users.AddRange(GetSeedingMessages());
            db.SaveChanges();
        }

        public static List<User> GetSeedingMessages()
        {
            return new List<User>()
            {
                new User(){Id="1", Email="a@a"},
                new User(){Id="2", Email="b@b"}
            };
        }
    }
}
