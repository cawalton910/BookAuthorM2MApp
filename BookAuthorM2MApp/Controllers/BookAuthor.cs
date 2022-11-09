using BookAuthorM2MApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookAuthorM2MApp.Controllers
{
    public class BookAuthor : Controller
    {
        private readonly IAuthorRepository _authorRepo;
        private readonly IBookRepository _bookRepo;
        private readonly IBookAuthorRepository _bookAuthorRepo;

        public BookAuthor(IAuthorRepository authorRepo, IBookAuthorRepository bookAuthorRepo, IBookRepository bookRepo)
        {
            _authorRepo = authorRepo;
            _bookRepo = bookRepo;
            _bookAuthorRepo = bookAuthorRepo;
        }
        public async Task<IActionResult> AssignAuthor([Bind(Prefix = "Id")] int bookId)
        {
            var authors = await _authorRepo.ReadAllAsync();
            ViewData["Book"] = bookId;
            return View(authors);
        }
        public async Task<IActionResult> AssignToBook([Bind(Prefix ="Id")]int bookId,int authorid)
        {
            await _bookAuthorRepo.Create(bookId, authorid);
            return RedirectToAction("Index", "Book");
        }
    }
}
