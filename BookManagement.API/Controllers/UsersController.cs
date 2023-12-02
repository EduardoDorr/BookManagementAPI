using Microsoft.AspNetCore.Mvc;

using BookManagement.Application.Services;
using BookManagement.Application.Dtos.User;

namespace BookManagement.API.Controllers;

[Route("/api/v1/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public async Task<ActionResult<IEnumerable<GetUserDto>>> GetUsers(int skip = 0, int take = 50)
    {
        var usersDto = await _userService.GetUsersAsync(skip, take);

        return Ok(usersDto);
    }

    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetUserDto>> GetUserById(int id)
    {
        var userDto = await _userService.GetUserByIdAsync(id);

        if (userDto is null)
            return NotFound();

        return Ok(userDto);
    }

    [HttpGet("borrows/{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<GetUserAndBorrowsDto>> GetUserAndBorrowsById(int id)
    {
        var userAndBorrowsDto = await _userService.GetUserAndBorrowByIdAsync(id);

        if (userAndBorrowsDto is null)
            return NotFound();

        return Ok(userAndBorrowsDto);
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserDto userDto)
    {
        var userId = await _userService.CreateUserAsync(userDto);

        return CreatedAtAction(nameof(GetUserById), new { id = userId }, userDto);
    }

    [HttpPut]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDto userDto)
    {
        var updated = await _userService.UpdateUserAsync(userDto);

        if (updated)
            return Ok();

        return NotFound();
    }

    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var deleted = await _userService.DeleteUserAsync(id);

        if (deleted)
            return Ok();

        return NotFound();
    }
}
