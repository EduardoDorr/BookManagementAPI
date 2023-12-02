namespace BookManagement.Application.Dtos.Borrow;

public record CreateBorrowDto(int UserId, int BookId, DateTime ScheduledReturnDate);