﻿using CheckSeparatorMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.ViewModels
{
    public class CheckAndUserViewModel
    {
        public CheckViewModel Check { get; set; }
        public User User { get; set; }

        public CheckAndUserViewModel(CheckViewModel check, User user)
        {
            Check = check;
            User = user;
        }
    }
}