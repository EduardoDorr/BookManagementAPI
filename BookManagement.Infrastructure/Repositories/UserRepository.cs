using Microsoft.EntityFrameworkCore;

using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces;
using BookManagement.Infrastructure.Data;

namespace BookManagement.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    private readonly BooksDbContext _context;

    public UserRepository(BooksDbContext context)
    {
        _context = context;
    }

    public async Task CreateUserAsync(User user)
    {
        await _context.Users.AddAsync(user);
    }

    public async Task<IEnumerable<User>> GetUsersAsync(int skip = 0, int take = 50)
    {
        return await _context.Users.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _context.Users.SingleOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetUserAndBorrowsByIdAsync(int id)
    {
        return await _context.Users.Include(u => u.Borrows)
                                   .ThenInclude(b => b.Book)
                                   .SingleOrDefaultAsync(u => u.Id == id);
    }

    public void UpdateUser(User user)
    {
        _context.Entry(user).State = EntityState.Modified;
    }

    public void DeleteUser(User user)
    {
        _context.Users.Remove(user);
    }

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }    
}
