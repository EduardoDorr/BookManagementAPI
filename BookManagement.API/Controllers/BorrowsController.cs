using Microsoft.AspNetCore.Mvc;

using BookManagement.Domain.Entities;
using BookManagement.Application.Services;

namespace BookManagement.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BorrowsController : ControllerBase
{
    private readonly IBorrowService _borrowService;

    public BorrowsController(IBorrowService borrowService)
    {
        _borrowService = borrowService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Borrow>>> GetAll(int skip = 0, int take = 50)
    {
        var borrows = await _borrowService.GetBorrows(skip, take);

        return Ok(borrows);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Borrow>> GetById(int id)
    {
        var borrow = await _borrowService.GetBorrowById(id);

        if (borrow is null)
            return NotFound();

        return Ok(borrow);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Borrow borrow)
    {
        var borrowId = await _borrowService.CreateBorrow(borrow);

        return CreatedAtAction(nameof(GetById), new { id = borrowId }, borrow);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Borrow borrow)
    {
        borrow.Id = id;

        var updated = await _borrowService.UpdateBorrow(borrow);

        if (updated)
            return Ok();

        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _borrowService.DeleteBorrow(id);

        if (deleted)
            return Ok();

        return NotFound();
    }
}
