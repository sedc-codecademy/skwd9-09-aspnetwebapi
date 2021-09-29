using SEDC.NotesApp.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.NotesApp.DataAccess.EntityFramework
{
    public class NoteRepository : IRepository<Note>
    {
        private readonly NoteDbContext _db;

        public NoteRepository(NoteDbContext db)
        {
            _db = db;
        }

        public void Add(Note entity)
        {
            _db.Notes.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Note entity)
        {
            //if (_db.Notes.Any(x => x.Id == entity.Id))
            //{
            //    Note note = _db.Notes.FirstOrDefault(x => x.Id == entity.Id);
            //    _db.Notes.Remove(note);
            //}
            Note note = _db.Notes.SingleOrDefault(x => x.Id == entity.Id);
            if (note != null)
            {
                _db.Notes.Remove(note);
                _db.SaveChanges();
            }

            //if (note != null)
            //{
            //    _db.Notes.Remove(note);
            //}
        }

        public List<Note> GetAll()
        {
            return _db.Notes.ToList();
        }

        public void Update(Note entity)
        {
            Note note = _db.Notes.SingleOrDefault(x => x.Id == entity.Id);
            if (note != null)
            {
                //updating by property
                note.Color = entity.Color;
                note.Text = entity.Text;
                note.Tag = entity.Tag;
                note.UserId = entity.UserId;
                //_db.Update(entity);
                _db.SaveChanges();
            }
        }
    }
}
