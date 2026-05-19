using _27_FrontToBackSqlConnection.Models;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels
{
    public class ProductUpdateVM
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Sku { get; set; }
        public string Description { get; set; }
        public int? CategoryId { get; set; }
        public List<Category>? Categories { get; set; }
        public List<int>? TagIds { get; set; }
        public List<Tag>? Tags { get; set; }
    }
}
