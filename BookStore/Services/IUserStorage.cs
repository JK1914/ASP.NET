using BookStore.Models;

namespace BookStore.Services
{
    public interface IUserStorage
    {
        User AddnewUser(string name);
        List<User> GetBooks();      
        User GetUserByName(string name);
        User GetBookById(int id);
        bool AddBooksToRefundList(Book book, string name);
        public void RemoveBookFromRefundList(Book book, string name);
        public bool CheckUserBooksOnEmpty(string name);
    }

    public class UserStorage : IUserStorage
    {
        public static List<User> users = new List<User>() {
            new User(){
                Name = "Вася",
                BooksToRefund = new List<Book>()
            }
        };

        public bool AddBooksToRefundList(Book book, string name)
        {
            var user = users.FirstOrDefault(f => f.Name == name);
            var newBook = user.BooksToRefund.FirstOrDefault(b => b.Name == book.Name);
            if (newBook!=null && newBook.Name == book.Name)
            {
                return false;
            }
            else
            {
                users.FirstOrDefault(f => f.Name == name).BooksToRefund.Add(book);
                return true;
            }
            
        }

        public void RemoveBookFromRefundList(Book book, string name)
        {
            users.FirstOrDefault(u=>u.Name==name).BooksToRefund.Remove(book);
        }

        public User AddnewUser(string name)
        {
            User newUser = new User()
            {
                Name = name
            };

            users.Add(newUser);

            return newUser;
        }

        public User GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public List<User> GetBooks()
        {
            throw new NotImplementedException();
        }

        public User GetUserByName(string name)
        {
            return users.FirstOrDefault(f => f.Name == name);
        }

        public List<User> GetUsers()
        {
            return users;
        }

        public bool CheckUserBooksOnEmpty(string name)
        {
            if (GetUserByName(name).BooksToRefund.Count == 0)
            {
                return true;
            }
            else return false;
        }
    }
}
