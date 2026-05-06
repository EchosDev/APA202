using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;
        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var sliders = _context.Sliders
                .Where(s => !s.IsDeleted)
                .OrderBy(s => s.Order)
                .Take(2)
                .ToList();

            var homeVM = new HomeVM 
            { 
                Sliders = sliders
            };

            return View(homeVM);
        }
    }
}
