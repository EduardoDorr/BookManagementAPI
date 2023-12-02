using BookManagement.Domain.Enums;

namespace BookManagement.Domain.Entities;

public class Borrow : BaseEntity
{
    public int UserId { get; set; }
    public int BookId { get; set; }
    public DateTime DateOfBorrow { get; set; }
    public DateTime ScheduledReturnDate { get; set; }
    public DateTime? RealReturnDate { get; set; }
    public BorrowStatus Status => GetStatus();

    public virtual User? User { get; set; }
    public virtual Book? Book { get; set; }

    public Borrow(int userId, int bookId, DateTime scheduledReturnDate)
    {
        UserId = userId;
        BookId = bookId;
        ScheduledReturnDate = scheduledReturnDate;
        IsActive = true;
        DateOfBorrow = DateTime.Now;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }

    public void Update(int userId, int bookId, DateTime scheduledReturnDate, bool isActive)
    {
        UserId = userId;
        BookId = bookId;
        ScheduledReturnDate = scheduledReturnDate;
        IsActive = isActive;
        UpdatedAt = DateTime.Now;
    }

    public void Return()
    {
        RealReturnDate = DateTime.Today;
        UpdatedAt = DateTime.Now;
    }

    private BorrowStatus GetStatus()
    {
        if (RealReturnDate is null)
            return DateTime.Today > ScheduledReturnDate.Date ? BorrowStatus.Overdue : BorrowStatus.OnTime;

        return RealReturnDate > ScheduledReturnDate.Date ? BorrowStatus.Overdue : BorrowStatus.OnTime;
    }
}
