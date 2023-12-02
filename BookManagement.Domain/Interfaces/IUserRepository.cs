using BookManagement.Domain.Entities;

namespace BookManagement.Domain.Interfaces;

public interface IUserRepository
{
    Task CreateUserAsync(User user);
    Task<IEnumerable<User>> GetUsersAsync(int skip = 0, int take = 50);
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserAndBorrowsByIdAsync(int id);
    void UpdateUser(User user);
    void DeleteUser(User user);
    Task<bool> SaveAsync();
}
