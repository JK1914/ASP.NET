using BookStore.Models;
using BookStore.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BookStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBookStorage _bookStorage;

        public HomeController(ILogger<HomeController> logger, IBookStorage bookStorage)
        {
            _logger = logger;
            _bookStorage = bookStorage;
        }

        public IActionResult Index()
        {
            var books = _bookStorage.GetBooks();
            ViewData["bookCollection"] = books;
            return View();
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