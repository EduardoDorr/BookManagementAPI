using Microsoft.AspNetCore.Mvc;

using BookManagement.Application.Services;
using BookManagement.Application.Dtos.Book;

namespace BookManagement.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class BooksController : ControllerBase
{
    private readonly IBookService _bookService;

    public BooksController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GetBookDto>>> GetBooks(int skip = 0, int take = 50)
    {
        var booksDto = await _bookService.GetBooksAsync(skip, take);

        return Ok(booksDto);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetBookDto>> GetBookById(int id)
    {
        var bookDto = await _bookService.GetBookByIdAsync(id);

        if (bookDto is null)
            return NotFound();

        return Ok(bookDto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookDto bookDto)
    {
        var bookId = await _bookService.CreateBookAsync(bookDto);

        return CreatedAtAction(nameof(GetBookById), new { id = bookId }, bookDto);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateBook([FromBody] UpdateBookDto bookDto)
    {
        var updated = await _bookService.UpdateBookAsync(bookDto);

        if (updated)
            return Ok();

        return NotFound();
    }

    [HttpPut("{id}/add")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> AddQuantity(int id, int quantity)
    {
        if (quantity <= 0)
            return BadRequest("Quantity must be greater than 0");

        var updated = await _bookService.AddQuantityAsync(id, quantity);

        if (updated)
            return Ok();

        return NotFound();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteBook(int id)
    {
        var deleted = await _bookService.DeleteBookAsync(id);

        if (deleted)
            return Ok();

        return NotFound();
    }
}
