using Microsoft.EntityFrameworkCore;
using SEDC.Notes.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Notes.DataAccess.Context
{
    //Microsoft.EntityFrameworkCore.SqlServer
    //Microsoft.EntityFrameworkCore.SqlServer.Design
    //Microsoft.EntityFrameworkCore.Tools
    public class NotesAppDbContext : DbContext
    {
        public NotesAppDbContext(DbContextOptions<NotesAppDbContext> options) : base(options) { }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Note> Notes { get; set; }
    }
}
