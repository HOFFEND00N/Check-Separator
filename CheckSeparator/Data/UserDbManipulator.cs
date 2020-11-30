using CheckSeparatorMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Data
{
    public class UserDbManipulator
    {
        private CheckSeparatorMvcContext context;

        public UserDbManipulator(CheckSeparatorMvcContext context)
        {
            this.context = context;
        }

        public void AddUser(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}
