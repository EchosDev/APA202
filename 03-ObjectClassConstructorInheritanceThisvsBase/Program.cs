using _03_ObjectClassConstructorInheritanceThisvsBase.Models;

namespace _03_ObjectClassConstructorInheritanceThisvsBase
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("================================================================");

            Student student1 = new Student("Elmir", "Shikhaliyev", 20, "null@gmail.com", "12345678", "87654321", "ITT", 88.5, 3);
            Student student2 = new Student("Ali", "Aliyev", 30, "null@gmail.com", "12345678", "87654321", "ITT", 92.0, 4);
            Student student3 = new Student("Vali", "Valiyev", 40, "null@gmail.com", "12345678", "87654321", "ITT", 68.5, 2);
            student1.ShowStudentInfo();
            Console.WriteLine($"Telebenin Alacagi Teqaud {student1.CalculateScholarship()}");
            Console.WriteLine("-----------------------------------------------------------------");
            student2.ShowStudentInfo();
            Console.WriteLine($"Telebenin Alacagi Teqaud {student2.CalculateScholarship()}");
            Console.WriteLine("-----------------------------------------------------------------");
            student3.ShowStudentInfo();
            Console.WriteLine($"Telebenin Alacagi Teqaud {student3.CalculateScholarship()}");
            Console.WriteLine("-----------------------------------------------------------------");
            decimal totalScholarShip = student1.CalculateScholarship() + student2.CalculateScholarship() + student3.CalculateScholarship();
            Console.WriteLine($"Umumi teqaud xerci: {totalScholarShip}");

            Console.WriteLine("================================================================");

            Teacher teacher1 = new Teacher("Elmir", "Shikhaliyev", 20, "null@gmail.com", "12345678", "ITT", "Front End", 1000, 15);
            Teacher teacher2 = new Teacher("Ali", "Aliyev", 30, "null@gmail.com", "12345678", "ITT", "Front End", 2000, 8);
            teacher1.ShowTeacherInfo();
            Console.WriteLine($"Muellimin Alacagi Maas {teacher1.CalculateSalary()}");
            Console.WriteLine("-----------------------------------------------------------------");
            teacher2.ShowTeacherInfo();
            Console.WriteLine($"Muellimin Alacagi Maas {teacher2.CalculateSalary()}");
            Console.WriteLine("-----------------------------------------------------------------");
            decimal totalSalary = teacher1.CalculateSalary() + teacher2.CalculateSalary();
            Console.WriteLine($"Umumi maas xerci: {totalSalary}");

            Console.WriteLine("================================================================");

            Administrator admin1 = new Administrator("Elmir", "Shikhaliyev", 20, "null@gmail.com", "12345678", "Dekan", "ITT", 5);
            admin1.ShowAdminInfo();
            Console.WriteLine("-----------------------------------------------------------------");
            admin1.GrantAccess("Ali", "Aliyev");

            Console.WriteLine("================================================================");
        }
    }
}
