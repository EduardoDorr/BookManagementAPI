using BookManagement.Application.Dtos.User;

namespace BookManagement.Application.Services;

public interface IUserService
{
    Task<int> CreateUserAsync(CreateUserDto user);
    Task<IEnumerable<GetUserDto>> GetUsersAsync(int skip = 0, int take = 50);
    Task<GetUserDto?> GetUserByIdAsync(int id);
    Task<GetUserAndBorrowsDto?> GetUserAndBorrowByIdAsync(int id);
    Task<bool> UpdateUserAsync(UpdateUserDto user);
    Task<bool> DeleteUserAsync(int id);
}