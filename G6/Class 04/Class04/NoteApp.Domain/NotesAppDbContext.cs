using Microsoft.EntityFrameworkCore;
using NoteApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.Domain
{
    public class NotesAppDbContext:DbContext
    {
        public NotesAppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<NoteModel> Notes { get; set; }
        public DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<NoteModel>()
                .Property(x => x.Text)
                .HasMaxLength(100)
                .IsRequired();
            modelBuilder.Entity<NoteModel>()
                .Property(x => x.Color)
                .HasMaxLength(30);

            //relation
            modelBuilder.Entity<NoteModel>()
                .HasOne(x => x.User)
                .WithMany(x => x.Notes)
                .HasForeignKey(x => x.UserId);

        }

    }

   

    


}
