using Microsoft.EntityFrameworkCore;
using BookManagement.Domain.Entities;

namespace BookManagement.Infrastructure.Configurations
{
    internal static class UserConfiguration
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                        .HasKey(u => u.Email);

            modelBuilder.Entity<User>()
                        .Property(u => u.Id).UseIdentityColumn();

            modelBuilder.Entity<User>(u =>
            {
                u.Property(u => u.Id).HasColumnOrder(0);
                u.Property(u => u.Name).HasMaxLength(100).HasColumnOrder(1).IsRequired();
                u.Property(u => u.Email).HasMaxLength(100).HasColumnOrder(2).IsRequired();
            });

            modelBuilder.Entity<User>()
                        .HasMany(u => u.Loans)
                        .WithOne(l => l.User)
                        .HasPrincipalKey(u => u.Id)
                        .IsRequired();
        }
    }
}
