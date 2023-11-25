namespace BookManagement.Domain.Entities;

public class User : EntityBase
{
    public string Name { get; set; }
    public string Email { get; set; }

    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    public void Update(string name, string email)
    {
        Name = name;
        Email = email;
    }
}
