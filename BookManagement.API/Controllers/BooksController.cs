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
    public async Task<ActionResult<IEnumerable<GetBookDto>>> GetAll(int skip = 0, int take = 50)
    {
        var books = await _bookService.GetBooks(skip, take);

        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<GetBookDto>> GetById(int id)
    {
        var book = await _bookService.GetBookById(id);

        if (book is null)
            return NotFound();

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] CreateBookDto book)
    {
        var bookId = await _bookService.CreateBook(book);

        return CreatedAtAction(nameof(GetById), new { id = bookId }, book);
    }

    [HttpPut]
    public async Task<IActionResult> Put([FromBody] UpdateBookDto book)
    {
        var updated = await _bookService.UpdateBook(book);

        if (updated)
            return Ok();

        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _bookService.DeleteBook(id);

        if (deleted)
            return Ok();

        return NotFound();
    }
}
