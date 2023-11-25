using Microsoft.EntityFrameworkCore;

using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces.Repositories;
using BookManagement.Infrastructure.Data;

namespace BookManagement.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BooksDbContext _context;

    public UserRepository(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateUser(User user)
    {
        _context.Users.Add(user);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<IEnumerable<User>> GetUsers(int skip = 0, int take = 50)
    {
        return await _context.Users.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<User?> GetUserById(int id)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<bool> UpdateUser(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteUser(User user)
    {
        _context.Users.Remove(user);
        return await _context.SaveChangesAsync() > 0;
    }
}
