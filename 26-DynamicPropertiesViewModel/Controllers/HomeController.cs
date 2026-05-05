using _26_DynamicPropertiesViewModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace _26_DynamicPropertiesViewModel.Controllers
{
    public class HomeController : Controller
    {
        private List<Student> _students = new List<Student>
        {
            new Student { Id = 1, Name = "John", LastName = "Doe" },
            new Student { Id = 2, Name = "Jane", LastName = "Smith" },
        };
        private List<Teacher> _teachers = new List<Teacher>
        {
            new Teacher { Id = 1, Name = "Mr. Anderson", Salary = 50000 },
            new Teacher { Id = 2, Name = "Ms. Johnson", Salary = 55000 },
        };

        public IActionResult Index()
        {
            var homeVM = new ViewModel.HomeVM
            {
                Students = _students,
                Teachers = _teachers
            };  

            return View(homeVM);
        }

        [Route("koperativ-satislar")]
        public IActionResult CorporativeSales()
        {
            return View();
        }
    }
}
