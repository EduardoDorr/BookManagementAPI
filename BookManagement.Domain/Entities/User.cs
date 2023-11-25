namespace BookManagement.Domain.Entities;

public class User : EntityBase
{
    public string Name { get; set; }
    public string Email { get; set; }

    public virtual ICollection<Loan> BooksBorrowed { get; set; }

    public void Update(string name, string email)
    {
        Name = name;
        Email = email;
    }
}
