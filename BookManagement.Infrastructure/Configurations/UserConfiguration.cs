using Microsoft.EntityFrameworkCore.Metadata.Builders;

using BookManagement.Domain.Entities;

namespace BookManagement.Infrastructure.Configurations;

internal class UserConfiguration : BaseEntityConfiguration<User>
{
    public override void Configure(EntityTypeBuilder<User> builder)
    {
        base.Configure(builder);

        builder.HasIndex(u => u.Email)
               .IsUnique();

        builder.Property(u => u.Name)
               .HasMaxLength(100)
               .IsRequired();

        builder.Property(u => u.Email)
               .HasMaxLength(100)
               .IsRequired();

        builder.HasMany(u => u.Borrows)
               .WithOne(l => l.User)
               .HasForeignKey(l => l.UserId)
               .IsRequired();
    }
}
