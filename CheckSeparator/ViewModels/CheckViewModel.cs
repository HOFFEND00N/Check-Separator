using CheckSeparatorMVC.Models;
using System.Collections.Generic;

namespace CheckSeparatorMVC.ViewModels
{
    public class CheckViewModel
    {
        public int CheckId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerId { get; set; }
        public List<CheckUser> CheckUsers { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public CheckViewModel()
        {
        }

        public CheckViewModel(Check check)
        {
            CheckId = check.CheckId;
            OwnerName = check.OwnerName;
            OwnerId = check.OwnerId;
            CheckUsers = check.CheckUsers;
            Products = new List<ProductViewModel>();
            foreach(var i in check.Products)
            {
                Products.Add(new ProductViewModel(i));
            }
        }

        public CheckViewModel(User user)
        {
            CheckId = 0;
            OwnerId = user.Id;
            OwnerName = user.UserName;
        }
    }
}
