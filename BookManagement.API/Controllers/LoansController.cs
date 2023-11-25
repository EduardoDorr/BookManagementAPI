using Microsoft.AspNetCore.Mvc;

using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces.Services;

namespace BookManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoansController : ControllerBase
{
    private readonly ILoanService _loanService;

    public LoansController(ILoanService loanService)
    {
        _loanService = loanService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Loan>>> GetAll(int skip = 0, int take = 50)
    {
        var loans = await _loanService.GetLoans(skip, take);

        return Ok(loans);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Loan>> GetById(int id)
    {
        var loan = await _loanService.GetLoanById(id);

        if (loan is null)
            return NotFound();

        return Ok(loan);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Loan loan)
    {
        var loanId = await _loanService.CreateLoan(loan);

        return CreatedAtAction(nameof(GetById), new { id = loanId }, loan);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Loan loan)
    {
        loan.Id = id;

        var updated = await _loanService.UpdateLoan(loan);

        if (updated)
            return Ok();

        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _loanService.DeleteLoan(id);

        if (deleted)
            return Ok();

        return NotFound();
    }
}
