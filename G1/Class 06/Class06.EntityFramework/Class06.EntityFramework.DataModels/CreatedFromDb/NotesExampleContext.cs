﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Class06.EntityFramework.DataModels.CreatedFromDb
{
    public partial class NotesExampleContext : DbContext
    {
        public NotesExampleContext()
        {
        }

        public NotesExampleContext(DbContextOptions<NotesExampleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Notes> Notes { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.;Database=NotesExample;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Notes>(entity =>
            {
                entity.Property(e => e.Text).HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Notes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Notes__UserId__267ABA7A");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.Property(e => e.Username).HasMaxLength(30);


                //entity.Property(e => e.Username).IsRequired();
                //entity.Property(e => e.Username).HasColumnName("email");

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
