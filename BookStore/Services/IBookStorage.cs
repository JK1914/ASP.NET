using BookStore.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookStore.Services
{
    public interface IBookStorage
    {
        Book AddNewBook(string bookName, DateTime publishDate, string authorName);
        List<Book> GetBooks();
        Book GetBookById(int id);        
        List<Book> GetBooksForPerson(int id);
        List<Book> GetBook(int bookId);
        List<Book> ReturnBook(int bookId);
        List<Book> GetBooksForPerson();
        bool PersonBooksCheck();

    }

    public class BookStorage : IBookStorage
    {
        //public static List<Book> Books = new List<Book>() {
        //    new Book()
        //    {
        //        Id = 1,
        //        Name = "Война и мир",
        //        PublishDate = new DateTime(1867, 9,5),
        //        AuthorName = "Л.Н.Толстой"
        //    },
        //    new Book()
        //    {
        //        Id = 2,
        //        Name = "Аэропорт",
        //        PublishDate = new DateTime(1968, 9,5),
        //        AuthorName = "А. Хейли"
        //    },
        //};

        public static List<Book> PersonBooks = new List<Book>();

        public Book AddNewBook(string bookName, DateTime publishDate, string authorName)
        {
            var lastId = Library.Books.Max(m => m.Id);
            var newbook = new Book()
            {
                Id = lastId++,
                Name = bookName,
                PublishDate = publishDate,
                AuthorName = authorName

            };
            Library.Books.Add(newbook);
            return newbook;
        }

        public List<Book> GetBooks()
        {
            if (Library.Books == null)
            {
                string path = "BookStorage.txt";

                string result = "";

                using (StreamReader reader = new StreamReader(path))
                {
                    result = reader.ReadToEnd();
                }

                Library.Books = JsonSerializer.Deserialize<List<Book>>(result)!;

            }

            var books = GetActualBooks();
            return books;
        }

        public Book GetBookById(int id)
        {
            var book = PersonBooks.First(b => b.Id == id);
            return book;
        }

        private List<Book> GetActualBooks()
        {
            var actualBooks = Library.Books.Where(b => b.IsBooked == false).ToList();
            return actualBooks;
        }

        public List<Book> GetBooksForPerson(int id)
        {
            var booksForPerson = GetBooks().Where(b => b.BookedByPersonId == id).ToList();
            return booksForPerson;
        }

        public List<Book> GetBooksForPerson()
        {            
            return PersonBooks;
        }


        public List<Book> GetBook(int bookId)
        {
            var book = GetBooks().Where(b => b.Id == bookId).FirstOrDefault();
            book.ReturnDate = DateTime.Now.AddDays(7);
            PersonBooks.Add(book);            
            Library.Books.Remove(book);
            book.IsBooked = true;
            Library.Books.Add(book);            
            return PersonBooks;
        }

        public List<Book> ReturnBook(int bookId)
        {
            var book = Library.Books.Where(b => b.Id == bookId).FirstOrDefault();
            PersonBooks.Remove(book);
            Library.Books.Remove(book);
            book.IsBooked = false;
            Library.Books.Add(book);            
            return PersonBooks;
        }

        public bool PersonBooksCheck()
        {
            if (PersonBooks.Count == 0)
            {
                return true;
            }
            else return false;
        }
    }
}
