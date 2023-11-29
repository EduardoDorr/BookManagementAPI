using BookManagement.Domain.Entities;

namespace BookManagement.Application.Services;

public interface IUserService
{
    Task<int> CreateUser(User user);
    Task<IEnumerable<User>> GetUsers(int skip = 0, int take = 50);
    Task<User?> GetUserById(int id);
    Task<bool> UpdateUser(User user);
    Task<bool> DeleteUser(int id);
}
