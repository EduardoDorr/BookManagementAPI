namespace BookManagement.Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public string Author { get; set; }
    public string Isbn { get; set; }
    public int PublicationYear { get; set; }
    public int Quantity { get; set; }

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();
    
    public Book(string title, string author, string isbn, int publicationYear)
    {
        Title = title;
        Author = author;
        Isbn = isbn.Replace("-","");
        PublicationYear = publicationYear;
        IsActive = true;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(string title, string author, string isbn, int publicationYear, bool isActive)
    {
        Title = title;
        Author = author;
        Isbn = isbn.Replace("-", "");
        PublicationYear = publicationYear;
        IsActive = isActive;
        UpdatedAt = DateTime.Now;
    }

    public void Add(int quantity)
    {
        Quantity += quantity;
        UpdatedAt = DateTime.Now;
    }

    public bool Remove(int quantity)
    {
        if (Quantity == 0)
            return false;

        Quantity -= quantity;
        UpdatedAt = DateTime.Now;

        return true;
    }
}
