﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }

        public List<CheckUser> CheckUsers { get; set; }
    }
}
