using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSqlConnection.ViewModels
{
    public class RegisterVM
    {
        [MinLength(2, ErrorMessage = "Name must be at least 2 characters long")]
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }
        
        [MinLength(2, ErrorMessage = "Surname must be at least 2 characters long")]
        [Required(ErrorMessage = "Surname is required")]
        public string Surname { get; set; }
        
        [MinLength(3, ErrorMessage = "Username must be at least 3 characters long")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password,ErrorMessage = "Invalid password format")]
        public string Password { get; set; }

        [Compare(nameof(Password), ErrorMessage = "Passwords do not match")]
        [DataType(DataType.Password,ErrorMessage = "Invalid password format")]
        public string ConfirmPassword { get; set; }
    }
}
