using BookAuthorM2MApp.Models.Entities;

namespace BookAuthorM2MApp.Services
{
    public interface IBookRepository
    {
        Task<ICollection<Book>> ReadallAsync();
        Task<Book?> ReadAsync(int bookId);
    }
}
