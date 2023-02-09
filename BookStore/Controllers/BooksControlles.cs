using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class BooksController : Controller
    {
        public readonly IBookStorage _bookStorage;

        public BooksController(IBookStorage bookStorage)
        {
            _bookStorage = bookStorage;
        }

        public IActionResult Index()
        {
            var books = _bookStorage.GetBooks();
            return View(books);
        }


        public IActionResult Details(int id)
        {
            var book = _bookStorage.GetBookById(id);
            return View(book);
        }
    }
}
