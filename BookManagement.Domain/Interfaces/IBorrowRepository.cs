using BookManagement.Domain.Entities;

namespace BookManagement.Domain.Interfaces;

public interface IBorrowRepository
{
    Task CreateBorrowAsync(Borrow borrow);
    Task<IEnumerable<Borrow>> GetBorrowsAsync(int skip = 0, int take = 50);
    Task<Borrow?> GetBorrowByIdAsync(int id);
    void UpdateBorrow(Borrow borrow);
    void DeleteBorrow(Borrow borrow);
    Task<bool> SaveAsync();
}
