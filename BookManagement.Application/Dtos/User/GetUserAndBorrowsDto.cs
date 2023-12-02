using BookManagement.Application.Dtos.Borrow;

namespace BookManagement.Application.Dtos.User;

public record GetUserAndBorrowsDto(int Id, string Name, string Email, ICollection<GetBorrowWithoutUser> Borrows);