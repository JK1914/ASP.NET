using BookStore.Models;

namespace BookStore.Services
{
    public interface IBookStorage
    {
        Book AddNewBook(string bookname, DateTime publishDate, string authorName);

        List<Book> GetBooks();
        Book GetBookById(int id);

    }

    public class BookStorage : IBookStorage {
        Random rnd = new Random();
        public static List<Book> Books = new List<Book>() {

            //new Book() {
            //Id = 1,
            //Name="War and Peace",
            //PublisherDate=new DateTime(1867,12,12),
            //AuthorName="L.N.Tolstoy",
            //Description="Super Description",
            //ImageUrl="https://books.google.kz/books/content?id=_VUEAAAAYAAJ&hl=ru&pg=PP5&img=1&zoom=3&sig=ACfU3U1KbudKKqs6BUK2wMs9dPUMIdfXkw&w=1025",
            //Refund= 20,
            //inStore = 3
            //},
            //new Book{
            //Id=2,
            //Name="Naruto",
            //PublisherDate=(DateTime)new DateTime(1960,10,2),
            //AuthorName="Gustavo Sus",
            //ImageUrl="https://pbs.twimg.com/profile_images/1553004296400166912/WVuCuoE-_400x400.jpg",
            //Refund= 10,
            //inStore = 3
            //},
            //new Book() {
            //Id = 3,
            //Name="War and Peace",
            //PublisherDate=new DateTime(1867,12,12),
            //AuthorName="L.N.Tolstoy",
            //Description="Super Description",
            //ImageUrl="https://books.google.kz/books/content?id=_VUEAAAAYAAJ&hl=ru&pg=PP5&img=1&zoom=3&sig=ACfU3U1KbudKKqs6BUK2wMs9dPUMIdfXkw&w=1025",
            //Refund= 20,
            //inStore = 3
            //},
            //new Book{
            //Id=4,
            //Name="Naruto",
            //PublisherDate=(DateTime)new DateTime(1960,10,2),
            //AuthorName="Gustavo Sus",
            //ImageUrl="https://pbs.twimg.com/profile_images/1553004296400166912/WVuCuoE-_400x400.jpg",
            //Refund= 10,
            //inStore = 3
            //},
            //new Book() {
            //Id = 5,
            //Name="War and Peace",
            //PublisherDate=new DateTime(1867,12,12),
            //AuthorName="L.N.Tolstoy",
            //Description="Super Description",
            //ImageUrl="https://books.google.kz/books/content?id=_VUEAAAAYAAJ&hl=ru&pg=PP5&img=1&zoom=3&sig=ACfU3U1KbudKKqs6BUK2wMs9dPUMIdfXkw&w=1025",
            //Refund= 20,
            //inStore = 3
            //},
            //new Book{
            //Id=6,
            //Name="Naruto",
            //PublisherDate=(DateTime)new DateTime(1960,10,2),
            //AuthorName="Gustavo Sus",
            //ImageUrl="https://pbs.twimg.com/profile_images/1553004296400166912/WVuCuoE-_400x400.jpg",
            //Refund= 10,
            //inStore = 3
            //}

        };

        public Book AddNewBook(string bookname, DateTime publishDate, string authorName)
        {
            var lastId = Books.Max(mbox => mbox.Id);
            var newBook = new Book()
            {
                Id = lastId++,
                Name = bookname,
                PublisherDate = publishDate,
                AuthorName= authorName
            };

            Books.Add(newBook);
            return newBook;
        }

        public Book GetBookById(int id)
        {
            foreach (Book book in Books)
            {
                if (book.Id == id)
                {
                    return book;
                }
            }
            return null;
        }


        public List<Book> GetBooks()
        {
            return Books;
        }
    }
}
