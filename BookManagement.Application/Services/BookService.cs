using AutoMapper;
using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces;
using BookManagement.Application.Dtos.Book;

namespace BookManagement.Application.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IMapper _mapper;

    public BookService(IBookRepository bookRepository, IMapper mapper)
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateBook(CreateBookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);

        await _bookRepository.CreateBook(book);

        var created = await _bookRepository.Save();

        if (!created)
            throw new Exception("Book can not be created");

        return book.Id;
    }

    public async Task<IEnumerable<GetBookDto>> GetBooks(int skip = 0, int take = 50)
    {
        var books = await _bookRepository.GetBooks(skip, take);

        return _mapper.Map<IEnumerable<GetBookDto>>(books);
    }

    public async Task<GetBookDto?> GetBookById(int id)
    {
        var book = await _bookRepository.GetBookById(id);

        return _mapper.Map<GetBookDto>(book);
    }

    public async Task<bool> UpdateBook(UpdateBookDto book)
    {
        var bookToUpdate = await _bookRepository.GetBookById(book.Id);

        if (bookToUpdate is null)
            return false;

        bookToUpdate.Update(book.Title, book.Author, book.Isbn, book.PublicationYear, book.Stock);

        _bookRepository.UpdateBook(bookToUpdate);

        return await _bookRepository.Save();
    }

    public async Task<bool> DeleteBook(int id)
    {
        var bookToDelete = await _bookRepository.GetBookById(id);

        if (bookToDelete is null)
            return false;

        _bookRepository.DeleteBook(bookToDelete);

        return await _bookRepository.Save();
    }
}
