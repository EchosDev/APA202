using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class DashboardController : Controller
    {
        [Authorize(Roles = "Admin,Moderator,Member")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
