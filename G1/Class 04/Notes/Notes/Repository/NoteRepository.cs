using Notes.Models.Data;
using Notes.Repository.IRepository;
using System.Collections.Generic;
using System.Linq;

namespace Notes.Repository
{
    public class NoteRepository : IRepository<Note>
    {
        public void Add(Note entity)
        {
            CacheDb.NoteId++;
            entity.Id = CacheDb.NoteId;
            CacheDb.Notes.Add(entity);
        }

        public void Delete(Note entity)
        {
            //if (CacheDb.Notes.Any(x => x.Id == entity.Id))
            //{
            //    Note note = CacheDb.Notes.FirstOrDefault(x => x.Id == entity.Id);
            //    CacheDb.Notes.Remove(note);
            //}
            Note note = CacheDb.Notes.FirstOrDefault(x => x.Id == entity.Id);
            if (note != null)
            {
                CacheDb.Notes.Remove(note);
            }

            //if (note != null)
            //{
            //    CacheDb.Notes.Remove(note);
            //}
        }

        public List<Note> GetAll()
        {
            return CacheDb.Notes;
        }

        public void Update(Note entity)
        {
            Note note = CacheDb.Notes.FirstOrDefault(x => x.Id == entity.Id);
            if (note != null)
            {
                int indexOfRecord = CacheDb.Notes.IndexOf(note);
                CacheDb.Notes[indexOfRecord] = entity;

                //updating by property
                //note.Color = entity.Color;
                //note.Text = entity.Text;
                //note.Tag = entity.Tag;
                //note.UserId = entity.UserId;
            }
        }
    }
}
