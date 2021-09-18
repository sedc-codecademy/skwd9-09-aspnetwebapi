using SEDC.Notes.Models.Data;
using SEDC.Notes.Repositories.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Notes.Repositories
{
    public class NoteRepository : IRepository<Note>
    {
        public void Add(Note entity)
        {
            CacheDb.NoteIdCounter++;
            entity.Id = CacheDb.NoteIdCounter;
            CacheDb.Notes.Add(entity);
        }

        public void Delete(Note entity)
        {
            var note = CacheDb.Notes.FirstOrDefault(n => n.Id == entity.Id);

            if (note != null) 
            {
                CacheDb.Notes.Remove(note);
            }
        }

        public List<Note> GetAll()
        {
            return CacheDb.Notes;
        }

        public void Update(Note entity)
        {
            var note = CacheDb.Notes.FirstOrDefault(n => n.Id == entity.Id);

            if (note != null) 
            {
                var indexOfNote = CacheDb.Notes.IndexOf(note);
                CacheDb.Notes[indexOfNote] = entity;
            }
        }
    }
}
