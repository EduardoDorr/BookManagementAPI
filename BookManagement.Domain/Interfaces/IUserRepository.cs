using BookManagement.Domain.Entities;

namespace BookManagement.Domain.Interfaces;

public interface IUserRepository
{
    Task<bool> CreateUser(User user);
    Task<IEnumerable<User>> GetUsers(int skip = 0, int take = 50);
    Task<User?> GetUserById(int id);
    Task<bool> UpdateUser(User user);
    Task<bool> DeleteUser(User user);
}
