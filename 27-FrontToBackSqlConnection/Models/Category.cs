using _27_FrontToBackSqlConnection.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSqlConnection.Models
{
    public class Category : BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        [MaxLength(30, ErrorMessage = "Name length cannot be greater than 30 characters")]
        public string Name { get; set; }
        public List<Product>? Products { get; set; }
    }
}
