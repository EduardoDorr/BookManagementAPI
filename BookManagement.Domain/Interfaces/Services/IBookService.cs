using BookManagement.Domain.Entities;

namespace BookManagement.Domain.Interfaces.Services
{
    public interface IBookService
    {
        Task<int> CreateBook(Book book);
        Task<IEnumerable<Book>> GetBooks(int skip = 0, int take = 50);
        Task<Book?> GetBookById(int id);
        Task<bool> UpdateBook(Book book);
        Task<bool> DeleteBook(int id);
    }
}
