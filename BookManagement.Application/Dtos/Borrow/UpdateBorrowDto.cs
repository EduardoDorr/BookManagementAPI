using BookManagement.Domain.Enums;

namespace BookManagement.Application.Dtos.Borrow;

public record UpdateBorrowDto(int Id, int UserId, int BookId, DateTime ScheduledReturnDate, bool IsActive);