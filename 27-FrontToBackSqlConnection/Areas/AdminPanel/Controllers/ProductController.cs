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
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync()
            };

            return View(productCreateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            productCreateVM.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            productCreateVM.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();

            if (!ModelState.IsValid) return View(productCreateVM);

            bool existCategory = productCreateVM.Categories.Any(c => c.Id == productCreateVM.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(ProductCreateVM.CategoryId), "Category is not valid.");
                return View(productCreateVM);
            }

            if (productCreateVM.TagIds is not null)
            {
                bool exitTags = productCreateVM.TagIds.Any(tagId => !productCreateVM.Tags.Exists(t => t.Id == tagId));
                if (exitTags)
                {
                    ModelState.AddModelError(nameof(ProductCreateVM.TagIds), "Tags is not valid.");
                    return View(productCreateVM);
                }
            }

            Product newProduct = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                Sku = productCreateVM.Sku,
                CategoryId = productCreateVM.CategoryId.Value,
                Description = productCreateVM.Description,
            };

            if (productCreateVM.TagIds is not null)
            {
                newProduct.ProductTags = productCreateVM.TagIds.Select(tagId => new ProductTag
                {
                    TagId = tagId
                }).ToList();
            }

            await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Product? product = await _context.Products
                .Include(p => p.Category)
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product is null) return NotFound();

            ProductUpdateVM productUpdateVM = new()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Sku = product.Sku,
                CategoryId = product.CategoryId,
                TagIds = product.ProductTags.Select(pt => pt.TagId).ToList(),
                Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync(),
                Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync(),
            };

            return View(productUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpdateVM)
        {
            if (id is null || id < 1) return BadRequest();

            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (product is null) return NotFound();

            productUpdateVM.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();

            if (!ModelState.IsValid) return View(productUpdateVM);

            bool existCategory = productUpdateVM.Categories.Any(c => c.Id == productUpdateVM.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(ProductUpdateVM.CategoryId), "Category is not valid.");
                return View(productUpdateVM);
            }

            product.Name = productUpdateVM.Name;
            product.Price = productUpdateVM.Price;
            product.Description = productUpdateVM.Description;
            product.Sku = productUpdateVM.Sku;
            product.CategoryId = productUpdateVM.CategoryId.Value;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Product? product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);

            if (product is null) return NotFound();

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Product? product = await _context.Products
                .Where(p => !p.IsDeleted)
                .Include(p => p.Category)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product is null) return NotFound();

            ProductDetailVM productDetailVM = new()
            {
                Name = product.Name,
                Price = product.Price,
                Description = product.Description,
                Sku = product.Sku,
                CategoryName = product.Category != null ? product.Category.Name : "NULL",
            };

            return View(productDetailVM);
        }
    }
}
