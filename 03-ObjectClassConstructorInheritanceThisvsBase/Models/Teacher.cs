using System;
using System.Collections.Generic;
using System.Text;

namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
    internal class Teacher : Person
    {
        public string Department;
        public string MainSubject;
        public decimal BaseSalary;
        public int ExperienceYears;

        public Teacher(string firstName, string lastName, int age, string email, string id, string department, string mainSubject, decimal baseSalary, int experienceYears) : base(firstName, lastName, age, email, id)
        {
            Department = department;
            MainSubject = mainSubject;
            BaseSalary = baseSalary;
            ExperienceYears = experienceYears;
        }

        public void ShowTeacherInfo()
        {
            Console.WriteLine($"""
                Adi:{FirstName}
                Soyad:{LastName}
                Yas:{Age}
                Email:{Email}
                Id:{Id}
                Kafedra:{Department}
                Esas Fenn:{MainSubject}
                Baza Maas:{BaseSalary} AZN
                Tecrube Ili:{ExperienceYears}
                """);
        }

        public decimal CalculateSalary()
        {
            return BaseSalary + (ExperienceYears * 50);
        }

    }
}
