using BookStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    public class PersonController : Controller
    {
        public readonly IBookStorage _bookStorage;
        public PersonController(IBookStorage bookStorage)
        {
            _bookStorage = bookStorage;
        }
        public IActionResult Index()
        {            
            var books = _bookStorage.GetBooksForPerson();
            if(books.Count == 0)
            {
                return View("Empty");
            }
            else return View(books);
        }

        public IActionResult GetBook(int id)
        {
           if (_bookStorage.PersonBooksCheck())
           {
                var books = _bookStorage.GetBook(id);
                return View("Index", books);
           }
           else return View("NoMore");
      
        }

        public IActionResult ReturnBook(int id)
        {
            var books = _bookStorage.ReturnBook(id);
            if (books.Count == 0)
            {
                return View("Empty");
            }
            else return View("Index", books);
        }

        public IActionResult Details(int id)
        {
            var book = _bookStorage.GetBookById(id);
            return View(book);
        }


    }
}
