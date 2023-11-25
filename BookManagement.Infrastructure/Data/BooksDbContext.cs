using Microsoft.EntityFrameworkCore;

using BookManagement.Domain.Entities;
using BookManagement.Infrastructure.Configurations;

namespace BookManagement.Infrastructure.Data;

public class BooksDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Loan> Loans { get; set; }

    public BooksDbContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BookConfiguration.Configure(modelBuilder);
        UserConfiguration.Configure(modelBuilder);
        LoanConfiguration.Configure(modelBuilder);
    }
}
