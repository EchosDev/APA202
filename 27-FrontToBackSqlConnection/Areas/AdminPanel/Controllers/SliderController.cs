using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class SliderController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public SliderController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public async Task<IActionResult> Index()
        {
            var sliders = await _context.Sliders
                .Where(s => !s.IsDeleted)
                .ToListAsync();

            return View(sliders);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid) return View();

            if (!slider.Photo.ContentType.Contains("image/"))
            {
                ModelState.AddModelError(nameof(Slider.Photo), "Please select an image file.");
                return View(slider);
            }

            if (slider.Photo.Length > 2 * 1024 * 1024)
            {
                ModelState.AddModelError(nameof(Slider.Photo), "Image size must be less than 2MB.");
                return View(slider);
            }

            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(slider.Photo.FileName);

            var filePath = Path.Combine(_env.WebRootPath, "assets", "images", "website-images", fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await slider.Photo.CopyToAsync(stream);
            }

            slider.Image = fileName;

            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Detail(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders
                .Where(s => !s.IsDeleted && s.Id == id)
                .FirstOrDefaultAsync();

            if (slider is null) return NotFound();

            return View(slider);
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders
                .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == id);

            if (slider is null) return NotFound();

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders
                .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == id);

            if (slider is null) return NotFound();

            return View(slider);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, Slider newSlider)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders
                .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == id);

            if (slider is null) return NotFound();

            bool existSlider = await _context.Sliders.AnyAsync(s => s.Title.Trim() == newSlider.Title.Trim() && s.Id != id);
            if (existSlider)
            {
                ModelState.AddModelError(nameof(Slider.Title), "This title is already in use.");
            }

            if (newSlider.Photo == null)
            {
                ModelState.Remove(nameof(Slider.Photo));
            }

            if (!ModelState.IsValid) return View(newSlider);

            if (newSlider.Photo != null)
            {
                if (!newSlider.Photo.ContentType.Contains("image/"))
                {
                    ModelState.AddModelError(nameof(Slider.Photo), "Please select an image file.");
                    return View(newSlider);
                }

                if (newSlider.Photo.Length > 2 * 1024 * 1024)
                {
                    ModelState.AddModelError(nameof(Slider.Photo), "Image size must be less than 2MB.");
                    return View(newSlider);
                }

                string fileName = Guid.NewGuid().ToString() + Path.GetExtension(newSlider.Photo.FileName);
                string path = Path.Combine(_env.WebRootPath, "assets", "images", "website-images", fileName);

                using (FileStream stream = new FileStream(path, FileMode.Create))
                {
                    await newSlider.Photo.CopyToAsync(stream);
                }

                string oldPath = Path.Combine(_env.WebRootPath, "assets", "images", "website-images", slider.Image);
                if (System.IO.File.Exists(oldPath))
                {
                    System.IO.File.Delete(oldPath);
                }

                slider.Image = fileName;
            }

            slider.Title = newSlider.Title;
            slider.Subtitle = newSlider.Subtitle;
            slider.Description = newSlider.Description;
            slider.Order = newSlider.Order;

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
