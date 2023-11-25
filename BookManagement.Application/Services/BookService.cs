using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces.Services;
using BookManagement.Domain.Interfaces.Repositories;

namespace BookManagement.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _repository;

    public BookService(IBookRepository repository)
    {
        _repository = repository;
    }

    public async Task<int> CreateBook(Book book)
    {
        await _repository.CreateBook(book);

        return book.Id;
    }

    public async Task<IEnumerable<Book>> GetBooks(int skip = 0, int take = 50)
    {
        return await _repository.GetBooks(skip, take);
    }

    public async Task<Book?> GetBookById(int id)
    {
        return await _repository.GetBookById(id);
    }

    public async Task<bool> UpdateBook(Book book)
    {
        var bookToUpdate = await _repository.GetBookById(book.Id);

        if (bookToUpdate is null)
            return false;

        bookToUpdate.Update(book.Title, book.Author, book.Isbn, book.PublicationYear, book.Stock);

        return await _repository.UpdateBook(bookToUpdate);
    }

    public async Task<bool> DeleteBook(int id)
    {
        var bookToDelete = await _repository.GetBookById(id);

        if (bookToDelete is null)
            return false;

        return await _repository.DeleteBook(bookToDelete);
    }
}
