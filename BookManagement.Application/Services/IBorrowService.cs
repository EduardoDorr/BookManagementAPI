using BookManagement.Application.Dtos.Borrow;

namespace BookManagement.Application.Services;

public interface IBorrowService
{
    Task<IEnumerable<GetBorrowDto>> GetBorrowsAsync(int skip = 0, int take = 50);
    Task<GetBorrowDto?> GetBorrowByIdAsync(int id);
    Task<int> CreateBorrowAsync(CreateBorrowDto borrow);
    Task<bool> ReturnBorrowAsync(int id);
    Task<bool> UpdateBorrowAsync(UpdateBorrowDto borrow);
    Task<bool> DeleteBorrowAsync(int id);
}
