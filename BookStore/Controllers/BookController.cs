using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookStorage _bookStorage;

        public BookController(IBookStorage bookStorage)
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

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}