using Microsoft.EntityFrameworkCore;

using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces.Repositories;
using BookManagement.Infrastructure.Data;

namespace BookManagement.Infrastructure.Repositories;

public class LoanRepository : ILoanRepository
{
    private readonly BooksDbContext _context;

    public LoanRepository(BooksDbContext context)
    {
        _context = context;
    }

    public async Task<bool> CreateLoan(Loan loan)
    {
        _context.Loans.Add(loan);
        return await _context.SaveChangesAsync() > 0;
    }    

    public async Task<IEnumerable<Loan>> GetLoans(int skip = 0, int take = 50)
    {
        return await _context.Loans.Skip(skip).Take(take).ToListAsync();
    }

    public async Task<Loan?> GetLoanById(int id)
    {
        return await _context.Loans.FirstOrDefaultAsync(l => l.Id == id);
    }

    public async Task<bool> UpdateLoan(Loan loan)
    {
        _context.Entry(loan).State = EntityState.Modified;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteLoan(Loan loan)
    {
        _context.Loans.Remove(loan);
        return await _context.SaveChangesAsync() > 0;
    }
}
