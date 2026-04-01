using System;
using System.Collections.Generic;
using System.Text;

namespace _10_GenericTypesCollections.Models
{
    internal class Member
    {
        private static int _id = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        private List<Book> BorrowedBooks = new List<Book>();

        public Member(string name, string email)
        {
            Name = name;
            Email = email;
            _id++;
            Id = _id;
        }

        public void BorrowBook(Book book)
        {
            if (BorrowedBooks.Count < 3)
            {
                BorrowedBooks.Add(book);
                Console.WriteLine($"Kitab goturuldu: [{book.Title}]");
            }
            else
            {
                Console.WriteLine($"Hormetli {Name} , Maksimum 3 kitab goture bilersiniz! ");
            }
        }

        public void ReturnBook(int bookId)
        {
            Book returnedBook = null;
            foreach (var book in BorrowedBooks)
            {
                if (book.Id== bookId)
                {
                    returnedBook = book;
                    break;
                }
            }
            if (returnedBook ==null)
            {
                throw new Exception($"Bu {bookId} ID - li kitab borc goturmemisiniz");
            }
            else
            {
                BorrowedBooks.Remove(returnedBook);
                Console.WriteLine($"Kitab qaytarildi: [{returnedBook.Title}]");
            }
        }

        public void DisplayBorrowedBooks()
        {
            if (BorrowedBooks.Count == 0)
            {
                Console.WriteLine("Borc kitab yoxdur");
            }
            else
            {
                Console.WriteLine("Borc goturulen kitablar:");
                foreach (var book in BorrowedBooks)
                {
                    book.DisplayInfo();
                }
            }
        }
    }
}
