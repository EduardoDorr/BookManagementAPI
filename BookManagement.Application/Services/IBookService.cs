using BookManagement.Application.Dtos.Book;

namespace BookManagement.Application.Services;

public interface IBookService
{
    Task<int> CreateBook(CreateBookDto bookDto);
    Task<IEnumerable<GetBookDto>> GetBooks(int skip = 0, int take = 50);
    Task<GetBookDto?> GetBookById(int id);
    Task<bool> UpdateBook(UpdateBookDto bookDto);
    Task<bool> DeleteBook(int id);
}
