using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<CheckUser> CheckUsers { get; set; }

        public List<ProductUser> ProductUsers { get; set; }

        public User(string name)
        {
            Name = name;
        }

        public User(string Email, string Password, string Name)
        {
            this.Email = Email;
            this.Password = Password;
            this.Name = Name;
        }
    }
}
