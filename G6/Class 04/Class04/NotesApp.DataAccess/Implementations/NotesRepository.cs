using Microsoft.EntityFrameworkCore;
using NoteApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotesApp.DataAccess
{
    public class NotesRepository : IRepository<NoteModel>
    {
        private NotesAppDbContext _notesAppDbContext;
        public NotesRepository(NotesAppDbContext notesAppDbContext)
        {
            _notesAppDbContext = notesAppDbContext;
        }
        public void Add(NoteModel entity)
        {
            _notesAppDbContext.Notes.Add(entity);
            _notesAppDbContext.SaveChanges();
        }

        public void Delete(NoteModel entity)
        {
            _notesAppDbContext.Notes.Remove(entity);
            _notesAppDbContext.SaveChanges();
        }

        public List<NoteModel> GetAll()
        {
            return _notesAppDbContext
                .Notes
                .Include(x => x.User) //join with table users
                .ToList();
        }

        public NoteModel GetById(int id)
        {
            return _notesAppDbContext
                .Notes
                .Include(x => x.User)
                .FirstOrDefault(x => x.Id == id);
        }

        public void Update(NoteModel entity)
        {
            _notesAppDbContext.Notes.Update(entity);
            _notesAppDbContext.SaveChanges();
        }
    }
}
