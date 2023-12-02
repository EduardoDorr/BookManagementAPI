using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BookManagement.Domain.Entities;

namespace BookManagement.Infrastructure.Configurations;

internal class BorrowConfiguration : BaseEntityConfiguration<Borrow>
{
    public override void Configure(EntityTypeBuilder<Borrow> builder)
    {
        base.Configure(builder);

        builder.Property(l => l.UserId)
               .IsRequired();

        builder.Property(l => l.BookId)
               .IsRequired();

        builder.Property(l => l.DateOfBorrow)
               .HasColumnType("datetime")
               .IsRequired();

        builder.Property(l => l.ScheduledReturnDate)
               .HasColumnType("datetime")
               .IsRequired();

        builder.Property(l => l.RealReturnDate)
               .HasColumnType("datetime")
               .IsRequired(false);

        builder.Ignore(l => l.Status);

        builder.HasOne(l => l.Book)
               .WithMany(b => b.Borrows)
               .HasForeignKey(l => l.BookId);

        builder.HasOne(l => l.User)
               .WithMany(u => u.Borrows)
               .HasForeignKey(l => l.UserId);
    }
}
