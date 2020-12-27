using System.ComponentModel.DataAnnotations;

namespace CheckSeparatorMVC.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Username is not specified")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public LoginViewModel(string ReturnUrl)
        {
            this.ReturnUrl = ReturnUrl;
        }

        public LoginViewModel()
        {
        }
    }
}
