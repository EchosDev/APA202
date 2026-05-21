using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Enums;
using _27_FrontToBackSqlConnection.Utilities.Extentions;
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

            if (!productCreateVM.MainPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(ProductCreateVM.MainPhoto), "File type must be image.");
                return View(productCreateVM);
            }

            if (!productCreateVM.HoverPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(ProductCreateVM.HoverPhoto), "File type must be image.");
                return View(productCreateVM);
            }

            if (!productCreateVM.MainPhoto.CheckFileSize(FileSize.MB, 2))
            {
                ModelState.AddModelError(nameof(ProductCreateVM.MainPhoto), "File size must be max 2MB.");
                return View(productCreateVM);
            }

            if (!productCreateVM.HoverPhoto.CheckFileSize(FileSize.MB, 2))
            {
                ModelState.AddModelError(nameof(ProductCreateVM.HoverPhoto), "File size must be max 2MB.");
                return View(productCreateVM);
            }

            bool existCategory = productCreateVM.Categories.Any(c => c.Id == productCreateVM.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(ProductCreateVM.CategoryId), "Category is not valid.");
                return View(productCreateVM);
            }

            if (productCreateVM.TagIds is not null)
            {
                bool existTags = productCreateVM.TagIds.Any(tagId => !productCreateVM.Tags.Exists(t => t.Id == tagId));
                if (existTags)
                {
                    ModelState.AddModelError(nameof(ProductCreateVM.TagIds), "Tags is not valid.");
                    return View(productCreateVM);
                }
            }

            ProductImage mainPhoto = new()
            {
                Image = await productCreateVM.MainPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = true
            };

            ProductImage hoverPhoto = new()
            {
                Image = await productCreateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = false
            };

            Product newProduct = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                Sku = productCreateVM.Sku,
                CategoryId = productCreateVM.CategoryId.Value,
                Description = productCreateVM.Description,
                ProductImages = new() { mainPhoto, hoverPhoto },
            };

            if (productCreateVM.TagIds is not null)
            {
                newProduct.ProductTags = productCreateVM.TagIds.Select(tagId => new ProductTag
                {
                    TagId = tagId
                }).ToList();
            }

            if (productCreateVM.AdditionalPhotos is not null)
            {
                string warningText = string.Empty;

                foreach (IFormFile file in productCreateVM.AdditionalPhotos)
                {
                    if (!file.CheckFileType("image/"))
                    {
                
                        warningText += $"<p class=\"text-danger\">{file.FileName} is not a valid image file. </p>";
                        continue;
                    }

                    if (!file.CheckFileSize(FileSize.MB, 2))
                    {
                        warningText += $"<p class=\"text-danger\">{file.FileName} exceeds the maximum file size of 2MB. </p>";
                        continue;
                    }

                    newProduct.ProductImages.Add(new ProductImage
                    {
                        Image= await productCreateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                        IsPrimary = null
                    });
                }

                TempData["Warning"] = warningText;
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
                .Include(p => p.ProductImages)
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
                ProductImages = product.ProductImages
            };

            return View(productUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpdateVM)
        {
            if (id is null || id < 1) return BadRequest();

            Product? product = await _context.Products
                .Include(p => p.ProductTags)
                .FirstOrDefaultAsync(p => p.Id == id && !p.IsDeleted);
            if (product is null) return NotFound();

            productUpdateVM.Categories = await _context.Categories.Where(c => !c.IsDeleted).ToListAsync();
            productUpdateVM.Tags = await _context.Tags.Where(t => !t.IsDeleted).ToListAsync();

            if (!ModelState.IsValid) return View(productUpdateVM);

            bool existCategory = productUpdateVM.Categories.Any(c => c.Id == productUpdateVM.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(ProductUpdateVM.CategoryId), "Category is not valid.");
                return View(productUpdateVM);
            }

            if (productUpdateVM.TagIds is not null)
            {
                bool existTags = productUpdateVM.TagIds.Any(tagId => !productUpdateVM.Tags.Exists(t => t.Id == tagId));
                if (existTags)
                {
                    ModelState.AddModelError(nameof(ProductUpdateVM.TagIds), "Tags is not valid.");
                    return View(productUpdateVM);
                }
            }

            if (productUpdateVM.TagIds is null)
            {
                productUpdateVM.TagIds = new();
            }
            List<ProductTag> deletedTags = product.ProductTags
                .Where(pTag => !productUpdateVM.TagIds
                .Exists(tId => tId == pTag.TagId)).ToList();

            List<ProductTag> newTags = productUpdateVM.TagIds
                .Where(tId => !product.ProductTags
                .Exists(pTag => pTag.TagId == tId))
                .Select(tagId => new ProductTag
                {
                    TagId = tagId,
                    ProductId = product.Id
                })
                .ToList();

            _context.ProductTags.RemoveRange(deletedTags);
            _context.ProductTags.AddRange(newTags);

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

            if(product.ProductImages is not null)
            {
                foreach (ProductImage productImage in product.ProductImages)
                {
                    productImage.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
                }
            }

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
