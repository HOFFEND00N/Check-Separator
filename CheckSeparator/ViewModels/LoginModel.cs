using System.ComponentModel.DataAnnotations;

namespace CheckSeparatorMVC.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Username is not specified")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is not specified")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }

        public LoginModel(string ReturnUrl)
        {
            this.ReturnUrl = ReturnUrl;
        }

        public LoginModel()
        {
        }
    }
}
