using BookManagement.Domain.Entities;

namespace BookManagement.Domain.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooksAsync(int skip = 0, int take = 50);
    Task<Book?> GetBookByIdAsync(int id);
    Task CreateBookAsync(Book book);
    void UpdateBook(Book book);
    void DeleteBook(Book book);
    Task<bool> SaveAsync();
}
