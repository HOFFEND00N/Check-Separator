using CheckSeparatorMVC.Models;
using CheckSeparatorMVC.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CheckSeparatorMVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login(string ReturnUrl)
        {
            return View(new LoginViewModel(ReturnUrl));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                SetReturnUrl(model);

                var result = await signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);

                if (result.Succeeded)
                    return Redirect(model.ReturnUrl);
                else
                    ModelState.AddModelError("", "Wrong Login or(and) password");
            }

            return View(model);
        }

        private void SetReturnUrl(LoginViewModel model)
        {
            if (string.IsNullOrEmpty(model.ReturnUrl) || !Url.IsLocalUrl(model.ReturnUrl))
                model.ReturnUrl = "/Home/Index";
        }

        public IActionResult Register(string ReturnUrl)
        {
            return View(new RegisterViewModel(ReturnUrl));
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                SetReturnUrl(model);
                var user = new User { Email = model.Email, UserName = model.UserName };
                var registrationResult = await userManager.CreateAsync(user, model.Password);

                if (registrationResult.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return Redirect(model.ReturnUrl);
                }

                foreach (var error in registrationResult.Errors)
                    ModelState.AddModelError("", error.Description);
            }
            return View(model);
        }

        private void SetReturnUrl(RegisterViewModel model)
        {
            if (!string.IsNullOrEmpty(model.ReturnUrl) || !Url.IsLocalUrl(model.ReturnUrl))
                model.ReturnUrl = "/Home/Index";
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
