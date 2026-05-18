using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            List<ProductGetVM> productGetVMs = await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .Select(p => new ProductGetVM
                {
                    ProductId = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    Sku = p.Sku,
                    CategoryName = p.Category != null ? p.Category.Name : "NULL",
                    Image = p.ProductImages.FirstOrDefault(pi => pi.IsPrimary == true).Image
                })
                .ToListAsync();

            return View(productGetVMs);
        }

        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new()
            {
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync()
            };

            return View(productCreateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            productCreateVM.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();

            if (!ModelState.IsValid) return View(productCreateVM);

            bool existCategory = productCreateVM.Categories.Any(c=>c.Id == productCreateVM.CategoryId);

            if (!existCategory) 
            { 
                ModelState.AddModelError(nameof(ProductCreateVM.CategoryId), "Category is not valid.");
                return View(productCreateVM);
            }

            Product newProduct = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                Sku = productCreateVM.Sku,
                CategoryId = productCreateVM.CategoryId.Value,
                Description = productCreateVM.Description
            };

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
