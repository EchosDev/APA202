using System;
using System.Collections.Generic;
using System.Text;

namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
    internal class Student : Person
    {
        public string StudentNumber;
        public string Faculty;
        public double GPA;
        public int Year;

        public Student(string firstName, string lastName, int age, string email, string id, string studentNumber, string faculty, double gpa, int year) : base(firstName, lastName, age, email, id)
        {
            StudentNumber = studentNumber;
            Faculty = faculty;
            GPA = gpa;
            Year = year;
        }

        public void ShowStudentInfo()
        {
            Console.WriteLine($"""
                Adi:{FirstName}
                Soyad:{LastName}
                Yas:{Age}
                Email:{Email}
                Id:{Id}
                Telebe Nomresi:{StudentNumber}
                Fakulte:{Faculty}
                Orta Bal:{GPA}
                Kurs:{Year}
                """);
        }

        public decimal CalculateScholarship()
        {
            if (GPA >= 90.0)
            {
                return 500;
            }
            else if (GPA >= 80.0 && GPA < 90.0)
            {
                return 350;
            }
            else if (GPA >= 70.0 && GPA < 80.0)
            {
                return 200;
            }
            else
            {
                return 0;
            }
        }
    }
}
