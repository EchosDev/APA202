using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace _27_FrontToBackSqlConnection.Controllers
{
    public class ShopController : Controller
    {
        private readonly AppDbContext _context;

        public ShopController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var products = await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.ProductImages.Where(pi => pi.IsPrimary != null && !pi.IsDeleted))
                .ToListAsync();

            ShopVM shopVM = new()
            {
                Products = products
            };

            return View(shopVM);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id is null && id < 1) return BadRequest();

            Product? product = await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.Category)
                .Include(p => p.ProductImages.Where(pi => !pi.IsDeleted))
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) return NotFound();

            var relatedProducts = await _context.Products
                .Where(p => !p.IsDeleted && p.CategoryId == product.CategoryId && p.Id != product.Id)
                .Include(x => x.ProductImages.Where(pi => pi.IsPrimary != null && !pi.IsDeleted))
                .ToListAsync();

            DetailsVM detailsVM = new()
            {
                Product = product,
                RelatedProducts = relatedProducts

            };
            return View(detailsVM);
        }
    }
}
