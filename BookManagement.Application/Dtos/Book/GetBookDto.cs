namespace BookManagement.Application.Dtos.Book;

public record GetBookDto(int Id, string Title, string Author, string Isbn, int PublicationYear, int Stock);