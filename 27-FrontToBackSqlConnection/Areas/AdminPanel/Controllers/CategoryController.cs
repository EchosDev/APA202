using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using AspNetCoreGeneratedDocument;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class CategoryController : Controller
    {
        private readonly AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories
                .Where(c => !c.IsDeleted)
                .Include(c => c.Products)
                .ToListAsync();

            return View(categories);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
            {
                return View(category);
            }

            bool existCategory = await _context.Categories.AnyAsync(c => c.Name.Trim() == category.Name.Trim());

            if (existCategory)
            {
                ModelState.AddModelError("Name", "Category already exist");
                return View(category);
            }

            await _context.AddAsync(category);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Category? category = await _context.Categories
                .Where(c=> !c.IsDeleted)
                .Include(c=> c.Products)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category is null) return NotFound();

            return View(category);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Category? category = await _context.Categories
                .FirstOrDefaultAsync(c => !c.IsDeleted && c.Id == id);

            if (category is null) return NotFound();

            category.IsDeleted = true;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
