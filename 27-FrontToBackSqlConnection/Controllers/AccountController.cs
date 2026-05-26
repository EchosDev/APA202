using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Enums;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid) return View(registerVM);

            AppUser appUser = new()
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.Username,
                Email = registerVM.Email
            };

            var result = await _userManager.CreateAsync(appUser, registerVM.Password);

            if (!result.Succeeded)
            {
                foreach (var error in result.Errors)
                {
                    if (error.Code.Contains("Username"))
                    {
                        ModelState.AddModelError(nameof(registerVM.Username), error.Description);
                    }
                    else if (error.Code.Contains("Email"))
                    {
                        ModelState.AddModelError(nameof(registerVM.Email), error.Description);
                    }
                    else if (error.Code.Contains("Password"))
                    {
                        ModelState.AddModelError(nameof(registerVM.Password), error.Description);
                    }
                }
                return View();
            }

            await _userManager.AddToRoleAsync(appUser, UserRole.Member.ToString());
            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Login()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid) return View();

            AppUser? appUser = await _userManager.Users
                .FirstOrDefaultAsync(u => u.UserName == loginVM.UsernameOrEmail || u.Email == loginVM.UsernameOrEmail);

            if (appUser == null)
            {
                ModelState.AddModelError(string.Empty, "Username, Email or password is wrong");
                return View(loginVM);
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, loginVM.Password, loginVM.IsPersistent, true);

            if (result.IsLockedOut)
            {
                ModelState.AddModelError(string.Empty, "Your account is locked out. Please try again later.");
                return View(loginVM);
            }

            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Username, Email or password is wrong");
                return View(loginVM);

            }

            return RedirectToAction(nameof(Index), "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Index), "Home");
        }

        //public async Task<IActionResult> CreateRoles()
        //{
        //    foreach (var role in Enum.GetValues(typeof(UserRole)))
        //    {
        //        await _roleManager.CreateAsync(new IdentityRole { Name = role.ToString() });
        //    }

        //    return RedirectToAction(nameof(Index), "Home");
        //}

        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
