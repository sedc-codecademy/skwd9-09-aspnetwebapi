using SEDC.NotesAPI.Domain.Models;
using SEDC.NotesAPI.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static SEDC.NotesAPI.DataAccess.Interfaces.IRepository;

namespace Tests
{
    public class FakeNoteRepository : IRepository<Note>
    {
        private List<Note> notes;
        public FakeNoteRepository()
        {
            notes = new List<Note>()
            {
                new Note()
                {
                    Id = 1,
                    Text = "Note 1",
                    Color = "rebeccapurple",
                    Tag = (TagType)2,
                    UserId = 1
                },
                new Note()
                {
                    Id = 2,
                    Text = "Note 2",
                    Color = "blue",
                    Tag = (TagType)1,
                    UserId = 1
                }
            };
        }

        public void Add(Note entity)
        {
            notes.Add(entity);
        }

        public void Delete(Note entity)
        {
            notes.Remove(entity);
        }

        public List<Note> GetAll()
        {
            return notes;
        }

        public Note GetById(int id)
        {
            return notes.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Note entity)
        {
            notes[notes.IndexOf(entity)] = entity;
        }
    }
}
