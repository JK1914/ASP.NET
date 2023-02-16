using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserStorage _userStorage;
        private readonly ILibraryStorage _libraryStorage;


        public UserController(IUserStorage userStorage, ILibraryStorage libraryStorage)
        {
            _userStorage = userStorage;
            _libraryStorage = libraryStorage;
        }


        public IActionResult ReservedBooks(string userName, int bookId)
        {
            var book = _libraryStorage.GetBookById(bookId, "Библиотека им. Расширения Кругозора");
            var user = _userStorage.GetUserByName(userName);
            if (_userStorage.AddBooksToRefundList(book, userName))
            {
                _libraryStorage.RefundBookById(bookId, "Библиотека им. Расширения Кругозора", userName);
                return View("ReservedBooks", user);
            }
            else return View("AlreadyExist");
        }

        public IActionResult ListBooks(string userName)
        {
            var user = _userStorage.GetUserByName(userName);
            if (_userStorage.CheckUserBooksOnEmpty(userName))
            {
                return View("Empty");
            }
            else
            {                
                return View("ReservedBooks", user);
            }   
        }

        public IActionResult ReturnBook(string userName, int bookId)
        {
            var book = _libraryStorage.GetBookById(bookId, "Библиотека им. Расширения Кругозора");
            _userStorage.RemoveBookFromRefundList(book, userName);
            _libraryStorage.ReturnBookById(bookId, "Библиотека им. Расширения Кругозора", userName);
            return RedirectToAction("Index", "Library");
        }

        //public IActionResult ReservedBook(string userName, int bookId)
        //{
        //    var book = _libraryStorage.GetBookById(bookId, "Atamura");            
        //    _libraryStorage.RefundBookById(bookId, "Atamura", userName);
        //    var user = _userStorage.GetUserByName(userName);
        //    return View("ReservedBooks", user);
        //}
    }
}
