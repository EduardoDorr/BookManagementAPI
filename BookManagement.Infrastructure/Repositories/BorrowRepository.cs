using Microsoft.EntityFrameworkCore;

using BookManagement.Domain.Entities;
using BookManagement.Infrastructure.Data;
using BookManagement.Domain.Interfaces;

namespace BookManagement.Infrastructure.Repositories;

public class BorrowRepository : IBorrowRepository
{
    private readonly BooksDbContext _context;

    public BorrowRepository(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateBorrow(Borrow borrow)
    {
        _context.Borrows.Add(borrow);
        return await _context.SaveChangesAsync() > 0;
    }    

    public async Task<IEnumerable<Borrow>> GetBorrows(int skip = 0, int take = 50)
    {
        return await _context.Borrows.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Borrow?> GetBorrowById(int id)
    {
        return await _context.Borrows.SingleOrDefaultAsync(l => l.Id == id);
    }

    public async Task<bool> UpdateBorrow(Borrow borrow)
    {
        _context.Entry(borrow).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteBorrow(Borrow borrow)
    {
        _context.Borrows.Remove(borrow);
        return await _context.SaveChangesAsync() > 0;
    }
}
