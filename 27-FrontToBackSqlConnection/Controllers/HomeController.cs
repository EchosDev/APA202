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
        public async Task<IActionResult> IndexAsync()
        {

            var sliders = await _context.Sliders
                .Where(s => !s.IsDeleted)
                .OrderBy(s => s.Order)
                //.Take(4)
                .ToListAsync();

            var products = await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(x => x.ProductImages.Where(pi=> pi.IsPrimary != null && !pi.IsDeleted))
                .Include(x => x.Category)
                .Take(4)
                .ToListAsync();

            var homeVM = new HomeVM
            {
                Sliders = sliders,
                Products = products
            };

            return View(homeVM);
        }
    }
}
