using Microsoft.EntityFrameworkCore;
using SEDC.NotesAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SEDC.NotesAPI.DataAccess.Interfaces.IRepository;

namespace SEDC.NotesAPI.DataAccess.Implementations
{
    public class NoteRepository : IRepository<Note>
    {
        private NotesAppDbContext _notesAppDbContext;
        public NoteRepository(NotesAppDbContext notesAppDbContext)
        {
            _notesAppDbContext = notesAppDbContext;
        }
        public void Add(Note entity)
        {
            _notesAppDbContext.Notes.Add(entity);
            _notesAppDbContext.SaveChanges();
        }

        public void Delete(Note entity)
        {
            _notesAppDbContext.Notes.Remove(entity);
            _notesAppDbContext.SaveChanges();
        }

        public List<Note> GetAll()
        {
            return _notesAppDbContext
                .Notes
                .Include(x => x.User)
                .ToList();
        }

        public Note GetById(int id)
        {
            return _notesAppDbContext
                .Notes
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(Note entity)
        {
            _notesAppDbContext.Notes.Update(entity);
            _notesAppDbContext.SaveChanges();
        }
    }
}
