using BookManagement.Application.Dtos.Book;

namespace BookManagement.Application.Services;

public interface IBookService
{
    Task<int> CreateBookAsync(CreateBookDto bookDto);
    Task<IEnumerable<GetBookDto>> GetBooksAsync(int skip = 0, int take = 50);
    Task<GetBookDto?> GetBookByIdAsync(int id);
    Task<bool> UpdateBookAsync(UpdateBookDto bookDto);
    Task<bool> AddQuantityAsync(int id, int quantity);
    Task<bool> DeleteBookAsync(int id);
}
