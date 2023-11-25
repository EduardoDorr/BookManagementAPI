using Microsoft.EntityFrameworkCore;
using BookManagement.Domain.Entities;

namespace BookManagement.Infrastructure.Configurations
{
    internal static class BookConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>()
                        .HasKey(b => b.Isbn);

            modelBuilder.Entity<Book>(b =>
            {
                b.Property(b => b.Id).UseIdentityColumn().HasColumnOrder(0);
                b.Property(b => b.Title).HasMaxLength(200).HasColumnOrder(1).IsRequired();
                b.Property(b => b.Author).HasMaxLength(100).HasColumnOrder(2).IsRequired();
                b.Property(b => b.Isbn).HasMaxLength(13).HasColumnOrder(3).IsRequired();
                b.Property(b => b.PublicationYear).IsRequired();
                b.Property(b => b.Stock).IsRequired();
            });

            modelBuilder.Entity<Book>()
                        .HasMany(b => b.Loans)
                        .WithOne(l => l.Book)
                        .HasPrincipalKey(b => b.Id)
                        .IsRequired();
        }
    }
}
