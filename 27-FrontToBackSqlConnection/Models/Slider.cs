using _27_FrontToBackSqlConnection.Models.Base;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace _27_FrontToBackSqlConnection.Models
{
    public class Slider :BaseEntity
    {
        [ValidateNever]
        public string Image { get; set; }
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Subtitle is required")]
        public string Subtitle { get; set; }
        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Order is required")]
        public int Order { get; set; }
        [NotMapped]
        [Required(ErrorMessage = "Image is required")]
        public IFormFile Photo { get; set; }
    }
}
