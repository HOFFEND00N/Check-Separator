using System.ComponentModel.DataAnnotations;

namespace CheckSeparatorMVC.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Email is not specified")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Password is incorrect")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "User name is not specified")]
        public string UserName { get; set; }

        public string ReturnUrl { get; set; }

        public RegisterViewModel(string ReturnUrl)
        {
            this.ReturnUrl = ReturnUrl;
        }

        public RegisterViewModel()
        {
        }
    }
}
