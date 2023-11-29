namespace BookManagement.Application.Dtos.Book;

public record UpdateBookDto(int Id, string Title, string Author, string Isbn, int PublicationYear, int Stock);