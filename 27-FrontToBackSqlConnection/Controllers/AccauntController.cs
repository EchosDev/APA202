using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class AccauntController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public AccauntController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
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
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }
    }
}
