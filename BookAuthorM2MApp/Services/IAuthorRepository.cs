using BookAuthorM2MApp.Models.Entities;

namespace BookAuthorM2MApp.Services
{
    public interface IAuthorRepository
    {
        Task<ICollection<Author>> ReadAllAsync();
        Task<Author?> ReadAsync(int authorId);
    }
}
