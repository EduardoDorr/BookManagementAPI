using Microsoft.AspNetCore.Mvc;

using BookManagement.Application.Services;
using BookManagement.Application.Dtos.Borrow;

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
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GetBorrowDto>>> GetBorrows(int skip = 0, int take = 50)
    {
        var borrowsDto = await _borrowService.GetBorrowsAsync(skip, take);

        return Ok(borrowsDto);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetBorrowDto>> GetBorrowById(int id)
    {
        var borrowDto = await _borrowService.GetBorrowByIdAsync(id);

        if (borrowDto is null)
            return NotFound();

        return Ok(borrowDto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateBorrow([FromBody] CreateBorrowDto borrowDto)
    {
        var borrowId = await _borrowService.CreateBorrowAsync(borrowDto);

        return CreatedAtAction(nameof(GetBorrowById), new { id = borrowId }, borrowDto);
    }

    [HttpPost("return/{id}")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> ReturnBook(int id)
    {
        var returned = await _borrowService.ReturnBorrowAsync(id);

        if (returned)
            return Ok();

        return NotFound();
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBorrow([FromBody] UpdateBorrowDto borrowDto)
    {
        var updated = await _borrowService.UpdateBorrowAsync(borrowDto);

        if (updated)
            return Ok();

        return NotFound();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBorrow(int id)
    {
        var deleted = await _borrowService.DeleteBorrowAsync(id);

        if (deleted)
            return Ok();

        return NotFound();
    }
}
