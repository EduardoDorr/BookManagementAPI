using BookManagement.Domain.Entities;

namespace BookManagement.Domain.Interfaces;

public interface IBookRepository
{
    Task<IEnumerable<Book>> GetBooks(int skip = 0, int take = 50);
    Task<Book?> GetBookById(int id);
    Task CreateBook(Book book);
    void UpdateBook(Book book);
    void DeleteBook(Book book);
    Task<bool> Save();
}
