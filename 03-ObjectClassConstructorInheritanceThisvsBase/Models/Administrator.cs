using System;
using System.Collections.Generic;
using System.Text;

namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
    internal class Administrator : Person
    {
        public string Position;
        public string Department;
        public int AccessLevel;

        public Administrator(string firstName, string lastName, int age, string email, string id, string position, string department, int acceslevel) : base(firstName, lastName, age, email, id)
        {
            Position = position;
            Department = department;
            AccessLevel = acceslevel;
        }

        public void ShowAdminInfo()
        {
            Console.WriteLine($"""
                Adi:{FirstName}
                Soyad:{LastName}
                Yas:{Age}
                Email:{Email}
                Id:{Id}
                Vezife:{Position}
                Kafedra:{Department}
                Giris seviyyesi:{AccessLevel}
                """);
        }

        public void GrantAccess(string studentFirstName, string studentLastName)
        {
            Console.WriteLine($"Giris Icazesi verildi! INFO - Icaze verilen telebe: {studentFirstName} {studentLastName}");
        }

    }
}
