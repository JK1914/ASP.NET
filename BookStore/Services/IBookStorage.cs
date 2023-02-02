using BookStore.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace BookStore.Services
{
    public interface IBookStorage
    {
        Book AddNewBook(string bookName, DateTime publishDate, string authorName);
        List<Book> GetBooks();
    }

    public class BookStorage : IBookStorage
    {
        public static List<Book> Books = new List<Book>(); 

        public Book AddNewBook(string bookName, DateTime publishDate, string authorName)
        {
            var lastId = Books.Max(m => m.Id);
            var newbook = new Book()
            {
                Id = lastId++,
                Name = bookName,
                PublishDate = publishDate,
                AuthorName = authorName
            
            };
            Books.Add(newbook);
            return newbook;
        }

        public List<Book> GetBooks()
        {
            string path = "BookStorage.txt";    

            string result = "";

            using (StreamReader reader = new StreamReader(path))
            {
                result = reader.ReadToEnd();
            }

            Books = JsonSerializer.Deserialize<List<Book>>(result)!;
            
            return Books;
        }
    }
}
