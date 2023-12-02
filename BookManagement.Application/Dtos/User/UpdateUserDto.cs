namespace BookManagement.Application.Dtos.User;

public record UpdateUserDto(int Id, string Name, string Email, bool IsActive);