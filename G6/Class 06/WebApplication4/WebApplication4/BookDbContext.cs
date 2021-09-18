using Microsoft.EntityFrameworkCore;
using WebApplication4.Models;

namespace WebApplication4
{
    public class BookDbContext : DbContext
    {
        public BookDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(entity =>
            {
                entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
            });

            modelBuilder.Entity<Book>(book =>
            {
                book.HasOne(d => d.Author).WithMany().HasForeignKey(e => e.AuthorId);
                book.Ignore(x => x.ReadCount);
            });
        }
    }
}
