using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class LibraryController : Controller
    {
        private readonly ILibraryStorage _libraryStorage;
        public LibraryController(ILibraryStorage libraryStorage)
        {
            _libraryStorage = libraryStorage;
        }
        public IActionResult Index()
        {
            var library = _libraryStorage.GetLibraryByName("Библиотека им. Расширения Кругозора");
            return View(library);
        }

        public IActionResult ReservedBook(int id) {
            var book = _libraryStorage.GetBookById(id, "Библиотека им. Расширения Кругозора");
            return View(book);
        }

        [HttpPost]
        public IActionResult ReserveBookPost(string userName, int bookId)
        {
            return RedirectToAction("ReservedBooks", "User", routeValues:new {
                userName, bookId
            });
        }
    }
}
