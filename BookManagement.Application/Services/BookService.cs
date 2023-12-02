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

    public async Task<int> CreateBookAsync(CreateBookDto bookDto)
    {
        var book = _mapper.Map<Book>(bookDto);

        await _bookRepository.CreateBookAsync(book);

        var created = await _bookRepository.SaveAsync();

        if (!created)
            throw new Exception("Book could not be created");

        return book.Id;
    }

    public async Task<IEnumerable<GetBookDto>> GetBooksAsync(int skip = 0, int take = 50)
    {
        var books = await _bookRepository.GetBooksAsync(skip, take);

        return _mapper.Map<IEnumerable<GetBookDto>>(books);
    }

    public async Task<GetBookDto?> GetBookByIdAsync(int id)
    {
        var book = await _bookRepository.GetBookByIdAsync(id);

        return _mapper.Map<GetBookDto>(book);
    }

    public async Task<bool> UpdateBookAsync(UpdateBookDto bookDto)
    {
        var bookToUpdate = await _bookRepository.GetBookByIdAsync(bookDto.Id);

        if (bookToUpdate is null)
            return false;

        bookToUpdate.Update(bookDto.Title, bookDto.Author, bookDto.Isbn, bookDto.PublicationYear, bookDto.IsActive);

        _bookRepository.UpdateBook(bookToUpdate);

        return await _bookRepository.SaveAsync();
    }

    public async Task<bool> AddQuantityAsync(int id, int quantity)
    {
        var bookToUpdate = await _bookRepository.GetBookByIdAsync(id);

        if (bookToUpdate is null)
            return false;

        bookToUpdate.Add(quantity);

        _bookRepository.UpdateBook(bookToUpdate);

        return await _bookRepository.SaveAsync();
    }

    public async Task<bool> DeleteBookAsync(int id)
    {
        var bookToDelete = await _bookRepository.GetBookByIdAsync(id);

        if (bookToDelete is null)
            return false;

        _bookRepository.DeleteBook(bookToDelete);

        return await _bookRepository.SaveAsync();
    }    
}
