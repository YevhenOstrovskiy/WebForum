using Microsoft.AspNetCore.Mvc;
using WebForum.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using WebForum.ViewModels;


namespace WebForum.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (model.Login.Trim().Length < 4 || model.Login.Trim().Length > 16)
            {
                ModelState.AddModelError("", "Required lenght from 4 to 16 symbols");
                return View(model);
            }

            if(ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(model.Email);
                if(user == null)
                {
                    user = new User { Email = model.Email, UserName = model.Login };
                    var result = await _userManager.CreateAsync(user, model.Password);
                    if(result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, true);
                        return RedirectToAction("Index", "Forum");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Error! Make sure you're doing everything right");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "User with this login already exists");
                }
            }
            else
            {
                ModelState.AddModelError("", "User with this email already exists");
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.EmailOrLogin, model.Password, true, false);
                if (result.Succeeded)
                {
                    if (string.IsNullOrEmpty(model.ReturnUrl) || string.IsNullOrWhiteSpace(model.ReturnUrl))
                        return RedirectToAction("Index", "Forum");
                    else
                        return Redirect(model.ReturnUrl);
                }
            
            else
            {
                var user = await _userManager.FindByEmailAsync(model.EmailOrLogin);
                if (user != null)
                {
                    result = await _signInManager.PasswordSignInAsync(user, model.Password, true, false);
                    if(result.Succeeded)
                    {
                            if (string.IsNullOrEmpty(model.ReturnUrl) || string.IsNullOrWhiteSpace(model.ReturnUrl))
                                return RedirectToAction("Index", "Forum");
                            else
                            {
                                if (!Url.IsLocalUrl(model.ReturnUrl))
                                    return RedirectToAction("Index", "Forum");
                                else
                                    return Redirect(model.ReturnUrl);
                            }
                    }
                }
            }
                if (!result.Succeeded)
                    ModelState.AddModelError("", "Wrong email/login or password");

            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Forum");
        }

        public IActionResult AccessDenied(string returnUrl) 
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Forum");
            else
                return RedirectToAction("Login", "Forum");
        }

        [HttpGet]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if(ModelState.IsValid)
            {
                var result = await _userManager.ChangePasswordAsync(await _userManager.GetUserAsync(User), model.OldPassword, model.NewPassword);
                if(result.Succeeded)
                {
                    return RedirectToAction("EditProfile", "Forum");
                }
                foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("", "Wrong password!");
                    break;
                }
            }
            return View();
        }
        
    }
}
