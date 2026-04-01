using _10_GenericTypesCollections.Models;

namespace _10_GenericTypesCollections
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Book book1 = new("Martin Eden", "Jack London", 1909, 400);
            Book book2 = new("1984", "George Orwell", 1949, 328);
            Book book3 = new("Animal Farm", "George Orwell", 1945, 112);
            Book book4 = new("Ag Gemi", "Cingiz Aytmatov", 1970, 200);
            Book book5 = new("Qiriq Budaq", "Elcin", 1998, 350);

            Console.WriteLine("=================================================");
            Library<Book> library = new("Milli Kitabxana");
            library.Add(book1);
            library.Add(book2);
            library.Add(book3);
            library.Add(book4);
            library.Add(book5);
            Console.WriteLine("================================================");

            List<Member> members = new List<Member>
            {
                new Member("Ali Memmedov","ali@mail.com"),
                new Member("Leyla Hesenova","leyla@mail.com"),
                new Member("Vuqar Eliyev","ali@mail.com")
            };

            members[0].BorrowBook(book1);
            Console.WriteLine("------------------------------------------------");
            members[0].BorrowBook(book2);
            Console.WriteLine("------------------------------------------------");
            members[0].DisplayBorrowedBooks();
            Console.WriteLine("------------------------------------------------");
            members[0].ReturnBook(1);
            Console.WriteLine("------------------------------------------------");
            members[0].DisplayBorrowedBooks();
            Console.WriteLine("------------------------------------------------");
            members[0].BorrowBook(book3);
            Console.WriteLine("------------------------------------------------");
            members[0].BorrowBook(book4);
            Console.WriteLine("------------------------------------------------");
            members[0].BorrowBook(book5);
            Console.WriteLine("================================================");

            BookManager bookManager = new();
            bookManager.AddBook(book1);
            bookManager.AddBook(book2);
            bookManager.AddBook(book3);
            bookManager.AddBook(book4);
            bookManager.AddBook(book5);
            Console.WriteLine("================================================");
            var authorsBooks1 = bookManager.GetBooksByAuthor("George Orwell");
            var authorsBooks2 = bookManager.GetBooksByAuthor("Cingiz Aytmatov");
            var authorsBooks3 = bookManager.GetBooksByAuthor("Jack London");
            var authorsBooks4 = bookManager.GetBooksByAuthor("Dostoyevski");

            foreach (var book in authorsBooks1)
            {
                book.DisplayInfo();
            }

            Console.WriteLine($"Cingiz Aytmatovun kitab sayi: {authorsBooks2.Count}");
            Console.WriteLine($"Jack Londonun kitab sayi: {authorsBooks3.Count}");
            Console.WriteLine($"Dostoyevskinin kitab sayi: {authorsBooks4.Count}");
            Console.WriteLine("================================================");

            bookManager.AddToWaitingQueue("Nigar");
            bookManager.AddToWaitingQueue("Resad");
            bookManager.AddToWaitingQueue("Sebine");
            Console.WriteLine($"Novbede: {bookManager.WaitingQueue.Count} neferdir");
            Console.WriteLine($"Xidmet Edilir: {bookManager.ServerNextInQueue()}");

            Console.WriteLine("================================================");
            bookManager.ReturnBook(book1);
            bookManager.ReturnBook(book2);
            bookManager.ReturnBook(book3);
            Console.WriteLine($"Stackde {bookManager.RecentlyReturned.Count} eded kitab var");
            Console.WriteLine($"Son qaytarilan kitab [{bookManager.GetLastReturnedBook().Title}]");
            Console.WriteLine($"Stackden [{bookManager.RecentlyReturned.Pop().Title}] kitabi silindi");
            Console.WriteLine($"Stackde {bookManager.RecentlyReturned.Count} eded kitab var");

            Console.WriteLine("================================================");
            Console.WriteLine($"Tapilan kitab: [{bookManager.SearchByTitle("1984").Title}]");
            Console.WriteLine($"Tapilan kitab: [{bookManager.SearchByTitle("Harry Potter")}]");
            Console.WriteLine("================================================");

            Console.WriteLine("Statistika");

            Console.WriteLine($"""
                Umumi kitab sayi: {bookManager.Books.Count}
                Umumi uzv sayi: {members.Count}
                Novbedeki nefer sayi: {bookManager.WaitingQueue.Count}
                Stackdeki kitab sayi: {bookManager.RecentlyReturned.Count}
                """);
            var books = bookManager.Books;
            int oldBook = books[0].Year;
            int newBook = books[0].Year;
            foreach (var book in books)
            {
                if (book.Year < oldBook)
                {
                    oldBook = book.Year;
                }
                else
                {
                    newBook = book.Year;
                }

            }
            Console.WriteLine($"En kohne kitabin ili {oldBook}");
            Console.WriteLine($"En yeniu kitabin ili {newBook}");
        }
    }
}
