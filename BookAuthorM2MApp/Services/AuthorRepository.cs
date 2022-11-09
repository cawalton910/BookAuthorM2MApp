using BookAuthorM2MApp.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookAuthorM2MApp.Services
{
    public class AuthorRepository : IAuthorRepository
    {
        private readonly ApplicationDbContext _db;
        public AuthorRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<ICollection<Author>> ReadAllAsync()
        {
            return await _db.Authors
                .Include(b => b.Books)
                .ToListAsync();
        }
        public async Task<Author?> ReadAsync(int authorId)
        {
            return await _db.Authors.FindAsync(authorId);
        }
    }
}
