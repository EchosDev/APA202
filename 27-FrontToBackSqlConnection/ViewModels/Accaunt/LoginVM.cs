using System.ComponentModel.DataAnnotations;

namespace _27_FrontToBackSqlConnection.ViewModels
{
    public class LoginVM
    {
        [MaxLength(100)]
        [MinLength(2)]
        public string UsernameOrEmail { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsPersistent { get; set; }
    }
}
