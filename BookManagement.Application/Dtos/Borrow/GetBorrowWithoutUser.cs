using BookManagement.Domain.Enums;
using BookManagement.Application.Dtos.Book;

namespace BookManagement.Application.Dtos.Borrow;

public record GetBorrowWithoutUser(int Id, GetBookDto Book, DateTime DateOfBorrow, DateTime ScheduledReturnDate, DateTime RealReturnDate, BorrowStatus Status);
