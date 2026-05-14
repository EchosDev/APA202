using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels.Sliders
{
    public class SliderCreateVM
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Subtitle is required")]
        public string Subtitle { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Order is required")]
        public int Order { get; set; }
        [Required(ErrorMessage = "Image is required")]
        public IFormFile Photo { get; set; }
    }
}
