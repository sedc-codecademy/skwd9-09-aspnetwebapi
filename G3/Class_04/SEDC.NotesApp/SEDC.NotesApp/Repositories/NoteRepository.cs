using SEDC.NotesApp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.NotesApp.Repositories
{
    public class NoteRepository : IRepository<Note>
    {
        public void Add(Note entity)
        {
            entity.Id = StaticDb.Notes.Count + 1;
            StaticDb.Notes.Add(entity);
        }

        public List<Note> GetAll()
        {
            return StaticDb.Notes;
        }

        public Note GetById(int id)
        {
            return StaticDb.Notes.SingleOrDefault(note => note.Id == id);
        }

        public void Remove(int id)
        {
            Note note = StaticDb.Notes.SingleOrDefault(note => note.Id == id);
            StaticDb.Notes.Remove(note);
        }

        public void Update(Note entity)
        {
            Note note = StaticDb.Notes.SingleOrDefault(note => note.Id == entity.Id);
            int idxOfExistingNote = StaticDb.Notes.IndexOf(note);
            StaticDb.Notes[idxOfExistingNote] = entity;
        }
    }
}
