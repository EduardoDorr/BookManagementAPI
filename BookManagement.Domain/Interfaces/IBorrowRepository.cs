using BookManagement.Domain.Entities;

namespace BookManagement.Domain.Interfaces;

public interface IBorrowRepository
{
    Task<bool> CreateBorrow(Borrow borrow);
    Task<IEnumerable<Borrow>> GetBorrows(int skip = 0, int take = 50);
    Task<Borrow?> GetBorrowById(int id);
    Task<bool> UpdateBorrow(Borrow borrow);
    Task<bool> DeleteBorrow(Borrow borrow);
}
