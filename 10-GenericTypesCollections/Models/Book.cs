using System;
using System.Collections.Generic;
using System.Text;

namespace _10_GenericTypesCollections.Models
{
    internal class Book
    {
        private static int _id = 0;
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Year { get; set; }
        public int PageCount { get; set; }

        public Book(string title, string author, int year, int pageCount)
        {
            Title = title;
            Author = author;
            Year = year;
            PageCount = pageCount;
            _id++;
            Id = _id;
        }
        public void DisplayInfo()
        {
            Console.WriteLine($"[{Id}] {Author} {Title}({Year}) - {PageCount} sehife");
        }
    }
}
