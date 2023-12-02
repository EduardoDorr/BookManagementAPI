using AutoMapper;

using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces;
using BookManagement.Application.Dtos.Borrow;

namespace BookManagement.Application.Services;

public class BorrowService : IBorrowService
{
    private readonly IBorrowRepository _borrowRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public BorrowService(IBorrowRepository borrowRepository,
                         IBookRepository bookRepository,
                         IUserRepository userRepository,
                         IMapper mapper)
    {
        _borrowRepository = borrowRepository;
        _bookRepository = bookRepository;
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<int> CreateBorrowAsync(CreateBorrowDto borrowDto)
    {
        var borrow = _mapper.Map<Borrow>(borrowDto);

        var user = await _userRepository.GetUserByIdAsync(borrow.UserId);

        if (user is null || !user.IsActive)
            throw new Exception("An active user could not be found");

        var book = await _bookRepository.GetBookByIdAsync(borrow.BookId);

        if (book is null)
            throw new Exception("Book could not be found");

        if (book.Quantity == 0)
            throw new Exception("Book is sold out");

        var result = book.Remove(1);

        if (!result)
            throw new Exception("Book could not be removed from stock");

        _bookRepository.UpdateBook(book);

        var updated = await _bookRepository.SaveAsync();

        if (!updated)
            throw new Exception("The book quantity has not been updated");

        await _borrowRepository.CreateBorrowAsync(borrow);

        var created = await _borrowRepository.SaveAsync();

        if (!created)
            throw new Exception("Borrow could not be created");

        return borrow.Id;
    }

    public async Task<bool> ReturnBorrowAsync(int id)
    {
        var borrowToReturn = await _borrowRepository.GetBorrowByIdAsync(id);

        if (borrowToReturn is null)
            return false;

        await ReturnBook(borrowToReturn);

        borrowToReturn.Return();

        _borrowRepository.UpdateBorrow(borrowToReturn);

        return await _borrowRepository.SaveAsync();
    }

    public async Task<IEnumerable<GetBorrowDto>> GetBorrowsAsync(int skip = 0, int take = 50)
    {
        var borrows = await _borrowRepository.GetBorrowsAsync(skip, take);

        return _mapper.Map<IEnumerable<GetBorrowDto>>(borrows);
    }

    public async Task<GetBorrowDto?> GetBorrowByIdAsync(int id)
    {
        var borrow = await _borrowRepository.GetBorrowByIdAsync(id);

        return _mapper.Map<GetBorrowDto?>(borrow);
    }

    public async Task<bool> UpdateBorrowAsync(UpdateBorrowDto borrowDto)
    {
        var borrowToUpdate = await _borrowRepository.GetBorrowByIdAsync(borrowDto.Id);

        if (borrowToUpdate is null)
            return false;

        borrowToUpdate.Update(borrowDto.UserId, borrowDto.BookId, borrowDto.ScheduledReturnDate, borrowDto.IsActive);

        _borrowRepository.UpdateBorrow(borrowToUpdate);

        return await _borrowRepository.SaveAsync();
    }

    public async Task<bool> DeleteBorrowAsync(int id)
    {
        var borrowToDelete = await _borrowRepository.GetBorrowByIdAsync(id);

        if (borrowToDelete is null)
            return false;

        await ReturnBook(borrowToDelete);

        _borrowRepository.DeleteBorrow(borrowToDelete);

        return await _borrowRepository.SaveAsync();
    }

    private async Task ReturnBook(Borrow borrow)
    {
        var book = await _bookRepository.GetBookByIdAsync(borrow.BookId);

        if (book is null)
            throw new Exception("Book could not be found");

        book.Add(1);

        _bookRepository.UpdateBook(book);

        var updated = await _bookRepository.SaveAsync();

        if (!updated)
            throw new Exception("The book quantity has not been updated");
    }
}
