using BookAuthorM2MApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorM2MApp.Controllers
{
    public class BookController : Controller
    {
        private readonly IBookRepository _bookRepo;

        public BookController(IBookRepository bookRepo)
        {
            _bookRepo = bookRepo;
        }
        public async Task<IActionResult> Index()
        {
            var books = await _bookRepo.ReadallAsync();
            return View(books);
        }
    }
}
