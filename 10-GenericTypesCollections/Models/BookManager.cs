using System;
using System.Collections.Generic;
using System.Text;

namespace _10_GenericTypesCollections.Models
{
    internal class BookManager
    {
        public List<Book> Books = new List<Book>();
        public Dictionary<string, List<Book>> BooksByAuthor = new Dictionary<string, List<Book>>();
        public Queue<string> WaitingQueue = new Queue<string>();
        public Stack<Book> RecentlyReturned = new Stack<Book>();

        public void AddBook(Book book)
        {
            Books.Add(book);

            if (!BooksByAuthor.ContainsKey(book.Author))
            {
                BooksByAuthor[book.Author] = new List<Book>();
            }

            BooksByAuthor[book.Author].Add(book);

            Console.WriteLine($"Kitab ugurla elave olundu {book.Title}");
        }
        public Book SearchByTitle(string title)
        {
            foreach (var book in Books)
            {
                if (book.Title.ToLower() == title.ToLower())
                {
                    return book;
                }
            }
            return null;
        }
        public List<Book> GetBooksByAuthor(string author)
        {
            if (BooksByAuthor.ContainsKey(author))
            {
                return BooksByAuthor[author];
            }
            return new List<Book>();
        }
        public void AddToWaitingQueue(string memberName)
        {
            WaitingQueue.Enqueue(memberName);
            Console.WriteLine($"[{memberName}] novbeye elave olundu");
        }
        public string ServerNextInQueue()
        {
            if (WaitingQueue.Count != 0)
            {

                return WaitingQueue.Dequeue();
            }
            return null;
        }
        public void ReturnBook(Book book)
        {
            RecentlyReturned.Push(book);
            Console.WriteLine($"Kitab qebul edildi: [{book.Title}]");
        }
        public Book GetLastReturnedBook()
        {
            if (RecentlyReturned.Count != 0)
            {
                return RecentlyReturned.Peek();
            }
            return null;
        }
    }
}
