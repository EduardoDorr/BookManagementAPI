namespace BookManagement.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();

    public User(string name, string email)
    {
        Name = name;
        Email = email;
        IsActive = true;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(string name, string email, bool isActive)
    {
        Name = name;
        Email = email;
        IsActive = isActive;
        UpdatedAt = DateTime.Now;
    }
}
