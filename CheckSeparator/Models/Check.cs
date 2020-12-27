using System.Collections.Generic;

namespace CheckSeparatorMVC.Models
{
    public class Check
    {
        public int CheckId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerId { get; set; }
        public List<CheckUser> CheckUsers { get; set; }
        public List<Product> Products { get; set; }
        public Check()
        {
        }

        public Check(User user)
        {
            OwnerId = user.Id;
            OwnerName = user.UserName;
        }
    }
}
