using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace CheckSeparatorMVC.Models
{
    public class User : IdentityUser
    {
        public List<CheckUser> CheckUsers { get; set; }

        public List<ProductUser> ProductUsers { get; set; }

    }
}
