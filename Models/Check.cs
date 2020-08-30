using System.Collections.Generic;
namespace CheckSeparatorMVC.Models
{
    public class Check
    {
        public int CheckId { get; set; }
        public string OwnerName { get; set; }
        public List<CheckUser> CheckUsers { get; set; }
        public List<Product> Products { get; set; }
        public Check()
        {
            CheckId = 0;
            OwnerName = "admin";
        }

        public Check(string name)
        {
            OwnerName = name;
        }
    }
}
