using Microsoft.EntityFrameworkCore;
using BookManagement.Domain.Entities;

namespace BookManagement.Infrastructure.Configurations
{
    internal static class LoanConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>()
                        .HasKey(l => l.Id);

            modelBuilder.Entity<Loan>(l =>
            {
                l.Property(l => l.UserId).IsRequired();
                l.Property(l => l.BookId).IsRequired();
                l.Property(l => l.DateOfLoan).HasColumnType("datetime").IsRequired();
                l.Property(l => l.ScheduledReturnDate).HasColumnType("datetime").IsRequired();
                l.Property(l => l.RealReturnDate).HasColumnType("datetime").IsRequired(false);
            });

            modelBuilder.Entity<Loan>()
                        .HasOne(l => l.Book)
                        .WithMany(b => b.Loans)
                        .HasForeignKey(l => l.BookId);

            modelBuilder.Entity<Loan>()
                        .HasOne(l => l.User)
                        .WithMany(u => u.Loans)
                        .HasForeignKey(l => l.UserId);
        }
    }
}
