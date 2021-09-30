using SEDC.Notes.DataAccess.Context;
using SEDC.Notes.DataAccess.Repositories.Interfaces;
using SEDC.Notes.DomainModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Notes.DataAccess.Repositories.Classes
{
    public class NoteRepository : IRepository<Note>
    {
        private readonly NotesAppDbContext _context;
        public NoteRepository(NotesAppDbContext context)
        {
            _context = context;
        }


        public void Add(Note entity)
        {
            _context.Notes.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Note entity)
        {
            _context.Notes.Remove(entity);
            _context.SaveChanges();
        }

        public IEnumerable<Note> GetAll()
        {
            return _context.Notes;
        }

        public void Update(Note entity)
        {
            _context.Notes.Update(entity);
            _context.SaveChanges();
        }
    }
}
