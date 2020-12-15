using CheckSeparatorMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.ViewModels
{
    //what are viewmodels 
    //normally called ...VewModels
    public class CheckAndUserModel
    {
        public Check Check { get; set; }
        public User User { get; set; }

        public CheckAndUserModel(Check check, User user)
        {
            Check = check;
            User = user;
        }
    }
}
