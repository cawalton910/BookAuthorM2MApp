using BookAuthorM2MApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorM2MApp.Controllers
{
    public class AuthorController : Controller
    {
        private readonly IBookAuthorRepository _bookAuthorRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IAuthorRepository _authorRepo;

        public AuthorController(IAuthorRepository authorRepo, IBookRepository bookRepo, IBookAuthorRepository bookAuthorRepo)
        {
            _bookAuthorRepo = bookAuthorRepo;
            _bookRepo = bookRepo;
            _authorRepo = authorRepo;
        }
        public async Task<IActionResult> Index()
        {
            var authors = await _authorRepo.ReadAllAsync();
            return View(authors);
        }
        public async Task<IActionResult> AssignBook([Bind(Prefix = "Id")] int authorId)
        {
            var books = await _bookRepo.ReadallAsync();
            ViewData["Author"] = authorId;
            return View(books);
        }
        public async Task<IActionResult> AssignToAuthor([Bind(Prefix = "Id")] int authorId, int bookId)
        {
            await _bookAuthorRepo.Create(bookId, authorId);
            return RedirectToAction("Index", "Book");
        }
    }
}
