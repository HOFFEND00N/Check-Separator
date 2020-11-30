using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Models
{
    public class CheckUser
    {
        public int CheckId { get; set; }
        public Check Check { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public CheckUser(int checkId, string userId)
        {
            CheckId = checkId;
            UserId = userId;
        }

        public CheckUser()
        {
        }
    }
}
