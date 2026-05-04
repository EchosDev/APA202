using Microsoft.AspNetCore.Mvc;

namespace _25_MVC_Intro.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Details(int? id)
        {

            if (id is null || id < 1)
            {
                return RedirectToAction(nameof(Error));
            }
            return View(id);
        }

        public IActionResult Error() 
        {
            return View();
        }
    }
}
