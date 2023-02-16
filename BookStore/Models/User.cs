namespace BookStore.Models
{
    public class User
    {
        public string Name { get; set; }

        public List<Book> BooksToRefund { get; set; }
    }
}
