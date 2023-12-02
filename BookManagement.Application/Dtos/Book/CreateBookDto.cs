namespace BookManagement.Application.Dtos.Book;

public record CreateBookDto(string Title, string Author, string Isbn, int PublicationYear, int Quantity);