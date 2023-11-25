namespace BookManagement.Domain.Entities;

public class Book : EntityBase
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public int PublicationYear { get; set; }
    public int Stock { get; set; }

    public void Update(string title, string author, string isbn, int publicationYear, int stock)
    {
        Title = title;
        Author = author;
        Isbn = isbn;
        PublicationYear = publicationYear;
        Stock = stock;
    }
}
