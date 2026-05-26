using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Enums;
using _27_FrontToBackSqlConnection.Utilities.Extentions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin,Moderator,Member")]
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
        [Authorize(Roles = "Admin,Moderator")]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(SliderCreateVM sliderCreateVM)
        {
            if (!ModelState.IsValid) return View();

            if (!sliderCreateVM.Photo.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(sliderCreateVM.Photo), "Please select an image file.");
                return View(sliderCreateVM);
            }

            if (!sliderCreateVM.Photo.CheckFileSize(FileSize.MB, 2))
            {
                ModelState.AddModelError(nameof(sliderCreateVM.Photo), "Image size must be less than 2MB.");
                return View(sliderCreateVM);
            }

            Slider slider = new()
            {
                Image = await sliderCreateVM.Photo.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                Title = sliderCreateVM.Title,
                Subtitle = sliderCreateVM.Subtitle,
                Description = sliderCreateVM.Description,
                Order = sliderCreateVM.Order
            };

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

            SliderDetailVM sliderDetailVM = new()
            {
                Title = slider.Title,
                Description = slider.Description,
                Order = slider.Order,
                Subtitle = slider.Subtitle,
                Image = slider.Image
            };

            return View(sliderDetailVM);
        }
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders
                .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == id);

            if (slider is null) return NotFound();

            slider.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

            _context.Sliders.Remove(slider);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
        [Authorize(Roles = "Admin,Moderator")]
        public async Task<IActionResult> Update(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders
                .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == id);

            if (slider is null) return NotFound();

            SliderUpdateVM sliderUpdateVM = new()
            {
                Title = slider.Title,
                Subtitle = slider.Subtitle,
                Order = slider.Order,
                Description = slider.Description,
                Image = slider.Image
            };

            return View(sliderUpdateVM);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int? id, SliderUpdateVM newSlider)
        {
            if (id is null || id < 1) return BadRequest();

            Slider? slider = await _context.Sliders
                .FirstOrDefaultAsync(s => !s.IsDeleted && s.Id == id);

            if (slider is null) return NotFound();

            bool existSlider = await _context.Sliders.AnyAsync(s => s.Title.Trim() == newSlider.Title.Trim() && s.Id != id);

            if (existSlider)
            {
                ModelState.AddModelError(nameof(newSlider.Title), "This title is already in use.");
            }

            if (!ModelState.IsValid) return View(newSlider);

            if (newSlider.Photo != null)
            {
                if (!newSlider.Photo.CheckFileType("image/"))
                {
                    ModelState.AddModelError(nameof(newSlider.Photo), "Please select an image file.");
                    return View(newSlider);
                }

                if (!newSlider.Photo.CheckFileSize(FileSize.MB, 2))
                {
                    ModelState.AddModelError(nameof(newSlider.Photo), "Image size must be less than 2MB.");
                    return View(newSlider);
                }

                string fileName = await newSlider.Photo.CreateFile(_env.WebRootPath, "assets", "images", "website-images");

                slider.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

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
