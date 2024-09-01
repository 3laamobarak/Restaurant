using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Restaurant.Models;
namespace Restaurant.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser> _userManager ,SignInManager<IdentityUser> _signInManager)
        {
            userManager = _userManager;
            signInManager = _signInManager;
        }
        public IActionResult Register()
        {
            if (!User.Identity.IsAuthenticated)
            {
                return View();
            }
            return RedirectToAction("Error", "Home");
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel NewAccount)
        {
            if (ModelState.IsValid)
            {
                IdentityUser user = new IdentityUser();
                user.UserName = NewAccount.UserName;
                user.Email = NewAccount.Email;
                IdentityResult Result = await userManager.CreateAsync(user, NewAccount.Password);
                if(Result.Succeeded)
                {
                    await signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in Result.Errors)
                    ModelState.AddModelError("", item.Description);
            }
            return View(NewAccount);
        }
        public IActionResult Login(string ReturnUrl = "~/Restaurant/showrestaurants")
        {
            if (!User.Identity.IsAuthenticated)
            {
                ViewData["Redirect Url"] = ReturnUrl;
                return View();
            }
            return RedirectToAction("Error","Home");
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel LoginUser,string ReturnUrl= "~/Restaurant/showrestaurants")
        {
            if(ModelState.IsValid)
            {
                IdentityUser user = await userManager.FindByNameAsync(LoginUser.UserName);
                if(user!=null)
                {
                    Microsoft.AspNetCore.Identity.SignInResult
                        Result = await signInManager.PasswordSignInAsync(user, LoginUser.Password, LoginUser.RemmemberMe, false);
                    if(Result.Succeeded)
                    {
                        return LocalRedirect(ReturnUrl);
                    }
                    else
                    {
                        ModelState.AddModelError("", "Invalid UserNmae Or Password");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid UserName ,Password");
                }
            }
            return View(LoginUser);
        }
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }
    }
}
