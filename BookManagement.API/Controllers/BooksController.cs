using Microsoft.AspNetCore.Mvc;

using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces.Services;

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
    public async Task<ActionResult<IEnumerable<Book>>> GetAll(int skip = 0, int take = 50)
    {
        var books = await _bookService.GetBooks(skip, take);

        return Ok(books);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetById(int id)
    {
        var book = await _bookService.GetBookById(id);

        if (book is null)
            return NotFound();

        return Ok(book);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] Book book)
    {
        var bookId = await _bookService.CreateBook(book);

        return CreatedAtAction(nameof(GetById), new { id = bookId }, book);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] Book book)
    {
        book.Id = id;

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
