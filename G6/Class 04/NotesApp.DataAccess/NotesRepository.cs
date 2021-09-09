using NoteApp.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NotesApp.DataAccess
{
    public class NotesRepository : IRepository<Note>
    {
        public void Add(Note entity)
        {
            StaticDb.NoteId++;
            entity.Id = StaticDb.NoteId;
            StaticDb.Notes.Add(entity);
        }

        public void Delete(int id)
        {
            Note note = StaticDb.Notes.FirstOrDefault(x => x.Id == id);
            //Note note = StaticDb.Notes.Where(x => x.Id == id).FirstOrDefault();
            if(note == null)
            {
                throw new Exception($"Note with id {id} does not exist!");
            }
            //delete record from DB
            StaticDb.Notes.Remove(note);
        }

        public List<Note> GetAll()
        {
            // return domain models (all records from the table in DB)
            return StaticDb.Notes;
        }

        public Note GetById(int id)
        {
            //returns one record from a table in DB (by id)
            return StaticDb.Notes.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Note entity)
        {
            Note note = StaticDb.Notes.FirstOrDefault(x => x.Id == entity.Id);
            if(note == null)
            {
                throw new Exception($"Note with id {entity.Id} does not exist!");
            }
            // update the record in DB
            int index = StaticDb.Notes.IndexOf(note);
            StaticDb.Notes[index] = entity;
        }
    }
}
