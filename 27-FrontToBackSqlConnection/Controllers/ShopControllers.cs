using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class ShopControllers : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
