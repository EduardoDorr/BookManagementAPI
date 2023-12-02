using Microsoft.EntityFrameworkCore;

using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces;
using BookManagement.Infrastructure.Data;

namespace BookManagement.Infrastructure.Repositories;

public class BorrowRepository : IBorrowRepository
{
    private readonly BooksDbContext _context;

    public BorrowRepository(BooksDbContext context)
    {
        _context = context;
    }

    public async Task CreateBorrowAsync(Borrow borrow)
    {
        await _context.Borrows.AddAsync(borrow);        
    }    

    public async Task<IEnumerable<Borrow>> GetBorrowsAsync(int skip = 0, int take = 50)
    {
        return await _context.Borrows.Include(b => b.User)
                                     .Include(b => b.Book)
                                     .Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Borrow?> GetBorrowByIdAsync(int id)
    {
        return await _context.Borrows.Include(b => b.User)
                                     .Include(b => b.Book)
                                     .SingleOrDefaultAsync(l => l.Id == id);
    }

    public void UpdateBorrow(Borrow borrow)
    {
        _context.Entry(borrow).State = EntityState.Modified;
    }

    public void DeleteBorrow(Borrow borrow)
    {
        _context.Borrows.Remove(borrow);
    }

    public async Task<bool> SaveAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}
