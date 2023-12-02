using Microsoft.EntityFrameworkCore;

using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces;
using BookManagement.Infrastructure.Data;

namespace BookManagement.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BooksDbContext _context;

    public BookRepository(BooksDbContext context)
    {
        _context = context;
    }

    public async Task CreateBookAsync(Book user)
    {
        await _context.Books.AddAsync(user);
    }

    public async Task<IEnumerable<Book>> GetBooksAsync(int skip = 0, int take = 50)
    {
        return await _context.Books.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Book?> GetBookByIdAsync(int id)
    {
        return await _context.Books.SingleOrDefaultAsync(u => u.Id == id);
    }

    public void UpdateBook(Book book)
    {
        _context.Entry(book).State = EntityState.Modified;
    }

    public void DeleteBook(Book book)
    {
        _context.Books.Remove(book);
    }

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
