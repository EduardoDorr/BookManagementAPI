namespace BookManagement.Domain.Entities;

public class Borrow : BaseEntity
{
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime DateOfBorrow { get; set; }
    public DateTime ScheduledReturnDate { get; set; }
    public DateTime? RealReturnDate { get; set; }

    public virtual User? User { get; set; }
    public virtual Book? Book { get; set; }

    public void Update(int userId, int bookId)
    {
        UserId = userId;
        BookId = bookId;
    }
}
