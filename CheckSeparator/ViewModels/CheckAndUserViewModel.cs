using CheckSeparatorMVC.Models;

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
