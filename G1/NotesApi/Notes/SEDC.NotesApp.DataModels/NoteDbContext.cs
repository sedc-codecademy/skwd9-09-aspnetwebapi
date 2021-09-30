using Microsoft.EntityFrameworkCore;

namespace SEDC.NotesApp.DataModels
{
    public class NoteDbContext : DbContext
    {
        public NoteDbContext(DbContextOptions options) 
            : base(options) {  }

        public DbSet<User> Users { get; set; }
        public DbSet<Note> Notes { get; set; }

        public void Seed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasData(
                    new User
                    {
                        Id = 1,
                        Firstname = "Bob",
                        LastName = "Bobsky",
                        Username = "bob007",
                    });

            modelBuilder.Entity<Note>()
                .HasData(
                    new Note
                    {
                        Id = 1,
                        Text = "Buy some bread",
                        Color = "orange",
                        Tag = 4,
                        UserId = 1
                    },
                    new Note
                    {
                        Id = 2,
                        Text = "Learn ASP .NET core WebApi",
                        Color = "red",
                        Tag = 1,
                        UserId = 1
                    }
                );
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Note>()
                .HasOne(x => x.User)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.UserId);

            Seed(modelBuilder);
        }
    }
}
