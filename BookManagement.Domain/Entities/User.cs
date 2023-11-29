namespace BookManagement.Domain.Entities;

public class User : BaseEntity
{
    public string Name { get; set; }
    public string Email { get; set; }

    public virtual ICollection<Borrow> Borrows { get; set; } = new List<Borrow>();

    public void Update(string name, string email)
    {
        Name = name;
        Email = email;
    }
}
