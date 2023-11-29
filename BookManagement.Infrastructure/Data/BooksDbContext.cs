using System.Reflection;
using Microsoft.EntityFrameworkCore;

using BookManagement.Domain.Entities;

namespace BookManagement.Infrastructure.Data;

public class BooksDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Borrow> Borrows { get; set; }

    public BooksDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
