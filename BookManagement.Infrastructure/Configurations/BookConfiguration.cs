using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BookManagement.Domain.Entities;

namespace BookManagement.Infrastructure.Configurations;

internal class BookConfiguration : BaseEntityConfiguration<Book>
{
    public override void Configure(EntityTypeBuilder<Book> builder)
    {
        base.Configure(builder);

        builder.HasIndex(b => b.Isbn)
               .IsUnique();

        builder.Property(b => b.Title)
               .HasMaxLength(200)
               .IsRequired();

        builder.Property(b => b.Author)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(b => b.Isbn)
               .HasMaxLength(13)
               .IsRequired();

        builder.Property(b => b.PublicationYear)
               .IsRequired();

        builder.Property(b => b.Stock)
               .IsRequired();

        builder.HasMany(b => b.Borrows)
               .WithOne(l => l.Book)
               .HasForeignKey(l => l.BookId)
               .IsRequired();
    }
}
