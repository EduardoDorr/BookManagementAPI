using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces.Services;
using BookManagement.Domain.Interfaces.Repositories;

namespace BookManagement.Application.Services;

public class LoanService : ILoanService
{
    private readonly ILoanRepository _repository;

    public LoanService(ILoanRepository loanRepository)
    {
        _repository = loanRepository;
    }

    public async Task<int> CreateLoan(Loan loan)
    {
        await _repository.CreateLoan(loan);

        return loan.Id;
    }

    public async Task<IEnumerable<Loan>> GetLoans(int skip = 0, int take = 50)
    {
        return await _repository.GetLoans(skip, take);
    }

    public async Task<Loan?> GetLoanById(int id)
    {
        return await _repository.GetLoanById(id);
    }        

    public async Task<bool> UpdateLoan(Loan loan)
    {
        var loanToUpdate = await _repository.GetLoanById(loan.Id);

        if (loanToUpdate is null)
            return false;

        loanToUpdate.Update(loan.UserId, loan.BookId);

        return await _repository.UpdateLoan(loanToUpdate);
    }
    public async Task<bool> DeleteLoan(int id)
    {
        var userToDelete = await _repository.GetLoanById(id);

        if (userToDelete is null)
            return false;

        return await _repository.DeleteLoan(userToDelete);
    }
}
