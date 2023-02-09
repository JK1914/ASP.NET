using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class LibraryController : Controller
    {
        public readonly IBookStorage _bookStorage;
        private readonly IPersonCheck _personCheck;

        public LibraryController(IBookStorage bookStorage, IPersonCheck personCheck)
        {
            _bookStorage = bookStorage;
            _personCheck = personCheck;
        }

        public IActionResult Index()
        {
            var books = _bookStorage.GetBooks();
            return View(books);
        }

        [HttpPost]
        public IActionResult Index(string name)
        {
            var result = _personCheck.IsChecked(name);

            if (result)
            {
                var books = _bookStorage.GetBooks();
                return View(books);                
            }
            else return View("Error");
        }


        public IActionResult Details(int id)
        {
            var book = _bookStorage.GetBookById(id);
            return View(book);
        }
    }
}
