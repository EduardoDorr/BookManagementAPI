using BookManagement.Application.Dtos.Book;
using BookManagement.Domain.Enums;

namespace BookManagement.Application.Dtos.Borrow;

public record GetBorrowWithoutUser(int Id, GetBookDto Book, DateTime DateOfBorrow, DateTime ScheduledReturnDate, DateTime RealReturnDate, BorrowStatus Status);
