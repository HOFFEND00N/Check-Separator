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
        public int UserId { get; set; }
        public User User { get; set; }

        public CheckUser(int checkId, int userId)
        {
            CheckId = checkId;
            UserId = userId;
        }
    }
}
