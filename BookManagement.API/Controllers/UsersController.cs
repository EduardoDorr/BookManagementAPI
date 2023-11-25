using Microsoft.AspNetCore.Mvc;

using BookManagement.Domain.Entities;
using BookManagement.Domain.Interfaces.Services;

namespace BookManagement.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetAll(int skip = 0, int take = 50)
    {
        var users = await _userService.GetUsers(skip, take);

        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Book>> GetById(int id)
    {
        var user = await _userService.GetUserById(id);

        if (user is null)
            return NotFound();

        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Post([FromBody] User user)
    {
        var userId = await _userService.CreateUser(user);

        return CreatedAtAction(nameof(GetById), new { id = userId }, user);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, [FromBody] User user)
    {
        user.Id = id;

        var updated = await _userService.UpdateUser(user);

        if (updated)
            return Ok();

        return NotFound();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var deleted = await _userService.DeleteUser(id);

        if (deleted)
            return Ok();

        return NotFound();
    }
}
