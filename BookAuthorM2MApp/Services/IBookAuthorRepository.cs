

using BookAuthorM2MApp.Models.Entities;

namespace BookAuthorM2MApp.Services
{
    public interface IBookAuthorRepository
    {
        Task<BookAuthor?> Create(int bookId, int authorId);
    }
}
