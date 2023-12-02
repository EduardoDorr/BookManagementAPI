using BookManagement.Application.Dtos.Book;
using BookManagement.Application.Dtos.User;
using BookManagement.Domain.Enums;

namespace BookManagement.Application.Dtos.Borrow;

public record GetBorrowDto(int Id, GetUserDto User, GetBookDto Book, DateTime DateOfBorrow, DateTime ScheduledReturnDate, DateTime RealReturnDate, BorrowStatus Status);