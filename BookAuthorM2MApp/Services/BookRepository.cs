using BookAuthorM2MApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorM2MApp.Services
{
    public class BookRepository : IBookRepository
    {
        private readonly ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<Book>> ReadallAsync()
        {
            return await _db.Books
                .Include(a => a.Authors)
                .ToListAsync();
        }
        public async Task<Book?> ReadAsync(int bookId)
        {
            return await _db.Books.FindAsync(bookId);
        }
    }
}
