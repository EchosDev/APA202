using System;
using System.Collections.Generic;
using System.Text;

namespace _03_ObjectClassConstructorInheritanceThisvsBase.Models
{
    internal class Person
    {
        public string FirstName;
        public string LastName;
        public int Age;
        public string Email;
        public string Id;

        public Person(string firstName, string lastName, int age, string email, string id)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this.Email = email;
            this.Id = id;
        }
        public void GetFullName()
        {
            Console.WriteLine($"Tam Adi:{FirstName} {LastName}");
        }
        public void ShowBasicInfo()
        {
            Console.WriteLine($"""
                Adi:{FirstName}
                Soyad:{LastName}
                Yas:{Age}
                Email:{Email}
                Id:{Id}
                """);
        }

    }
}
