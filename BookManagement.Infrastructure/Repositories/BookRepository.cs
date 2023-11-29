using Microsoft.EntityFrameworkCore;

using BookManagement.Domain.Entities;
using BookManagement.Infrastructure.Data;
using BookManagement.Domain.Interfaces;

namespace BookManagement.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly BooksDbContext _context;

    public BookRepository(BooksDbContext context)
    {
        _context = context;
    }

    public async Task CreateBook(Book user)
    {
        await _context.Books.AddAsync(user);
    }

    public async Task<IEnumerable<Book>> GetBooks(int skip = 0, int take = 50)
    {
        return await _context.Books.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Book?> GetBookById(int id)
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

    public async Task<bool> Save()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
