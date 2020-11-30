using CheckSeparatorMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Data
{
    public class CheckDbManipulator
    {
        private CheckSeparatorMvcContext context;

        public CheckDbManipulator(CheckSeparatorMvcContext context)
        {
            this.context = context;
        }

        public void AddCheck(Check check)
        {
            context.Checks.Add(check);
            context.SaveChanges();
        }

    }
}
