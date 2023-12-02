using BookManagement.Domain.Enums;
using BookManagement.Application.Dtos.Book;
using BookManagement.Application.Dtos.User;

namespace BookManagement.Application.Dtos.Borrow;

public record GetBorrowDto(int Id, GetUserDto User, GetBookDto Book, DateTime DateOfBorrow, DateTime ScheduledReturnDate, DateTime? RealReturnDate, BorrowStatus Status);