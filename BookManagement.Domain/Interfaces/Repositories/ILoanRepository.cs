using BookManagement.Domain.Entities;

namespace BookManagement.Domain.Interfaces.Repositories;

public interface ILoanRepository
{
    Task<bool> CreateLoan(Loan loan);
    Task<IEnumerable<Loan>> GetLoans(int skip = 0, int take = 50);
    Task<Loan?> GetLoanById(int id);
    Task<bool> UpdateLoan(Loan loan);
    Task<bool> DeleteLoan(Loan loan);
}
