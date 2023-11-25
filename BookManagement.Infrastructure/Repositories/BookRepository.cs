using Microsoft.EntityFrameworkCore;

using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces.Repositories;
using BookManagement.Infrastructure.Data;

namespace BookManagement.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BooksDbContext _context;

    public BookRepository(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateBook(Book user)
    {
        _context.Books.Add(user);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<Book>> GetBooks(int skip = 0, int take = 50)
    {
        return await _context.Books.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Book?> GetBookById(int id)
    {
        return await _context.Books.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> UpdateBook(Book book)
    {
        _context.Entry(book).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteBook(Book book)
    {
        _context.Books.Remove(book);
        return await _context.SaveChangesAsync() > 0;
    }
}
