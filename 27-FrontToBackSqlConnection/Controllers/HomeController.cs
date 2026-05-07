using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

            var products = _context.Products
                .Where(p => !p.IsDeleted)
                .Include(x => x.ProductImages)
                .Include(x => x.Category)
                .Take(4)
                .ToList();

            var homeVM = new HomeVM
            {
                Sliders = sliders,
                Products = products
            };

            return View(homeVM);
        }
    }
}
