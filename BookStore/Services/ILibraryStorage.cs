using BookStore.Models;

namespace BookStore.Services
{
    public interface ILibraryStorage
    {
        Library GetLibraryByName(string name);
        Book GetBookById(int id, string libraryName);
        void RefundBookById(int bookId, string libraryName, string username);
        public void ReturnBookById(int bookId, string libraryName, string username);
    }

    public class LibraryStorage : ILibraryStorage
    {
        private readonly List<Library> _libraries;
        private readonly IUserStorage _userStorage;

        public LibraryStorage(List<Library> libraries, IUserStorage userStorage)
        {
            _libraries = libraries;
            _userStorage = userStorage;
        }

        public Book GetBookById(int id, string LibraryName)
        {
            Library library = _libraries.FirstOrDefault(f => f.Name == LibraryName);
            return library.AvailableBooks.FirstOrDefault(f => f.Id == id);
        }

        public Library GetLibraryByName(string name)        
        {
            return _libraries.FirstOrDefault(f => f.Name == name);
        }

        public void RefundBookById(int bookId, string libraryName, string username)
        {
            User user = _userStorage.GetUserByName(username);
            _libraries.FirstOrDefault(f => f.Name == libraryName).AvailableBooks.FirstOrDefault(f => f.Id == bookId).IsBooked = true;
            _libraries.FirstOrDefault(f => f.Name == libraryName).AvailableBooks.FirstOrDefault(f => f.Id == bookId).BookedBy = user;
        }

        public void ReturnBookById(int bookId, string libraryName, string username)
        {
            User user = _userStorage.GetUserByName(username);
            _libraries.FirstOrDefault(f => f.Name == libraryName).AvailableBooks.FirstOrDefault(f => f.Id == bookId).IsBooked = false;
            _libraries.FirstOrDefault(f => f.Name == libraryName).AvailableBooks.FirstOrDefault(f => f.Id == bookId).BookedBy = null;
        }
    }
}
