using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces;

namespace BookManagement.Application.Services;

public class BorrowService : IBorrowService
{
    private readonly IBorrowRepository _repository;

    public BorrowService(IBorrowRepository borrowRepository)
    {
        _repository = borrowRepository;
    }

    public async Task<int> CreateBorrow(Borrow borrow)
    {
        await _repository.CreateBorrow(borrow);

        return borrow.Id;
    }

    public async Task<IEnumerable<Borrow>> GetBorrows(int skip = 0, int take = 50)
    {
        return await _repository.GetBorrows(skip, take);
    }

    public async Task<Borrow?> GetBorrowById(int id)
    {
        return await _repository.GetBorrowById(id);
    }        

    public async Task<bool> UpdateBorrow(Borrow borrow)
    {
        var borrowToUpdate = await _repository.GetBorrowById(borrow.Id);

        if (borrowToUpdate is null)
            return false;

        borrowToUpdate.Update(borrow.UserId, borrow.BookId);

        return await _repository.UpdateBorrow(borrowToUpdate);
    }
    public async Task<bool> DeleteBorrow(int id)
    {
        var userToDelete = await _repository.GetBorrowById(id);

        if (userToDelete is null)
            return false;

        return await _repository.DeleteBorrow(userToDelete);
    }
}
