using Moq;
using SEDC.NotesApp.Models.DbModels;
using SEDC.NotesApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tests
{
    public static class MockHelper
    {
        public static IRepository<Note> MockNoteRepository()
        {
            List<Note> notes = new List<Note>()
            {
                new Note(){
                    Id = 1,
                    Text = "Don't forget to water the plant",
                    Color = "blue",
                    Tag = 2,
                    UserId = 1
                },
                new Note(){
                    Id = 2,
                    Text = "Drink more Tea",
                    Color = "yellow",
                    Tag = 3,
                    UserId = 1
                }
            };

            Mock<IRepository<Note>> mockNoteRepo = new Mock<IRepository<Note>>();

            mockNoteRepo.Setup(x => x.GetAll()).Returns(notes);
            mockNoteRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns((int id) =>
            {
                return notes.SingleOrDefault(note => note.Id == id);
            });
            mockNoteRepo.Setup(x => x.Add(It.IsAny<Note>())).Callback(
                (Note note) =>
                {
                    notes.Add(note);
                }
            );
            mockNoteRepo.Setup(x => x.Update(It.IsAny<Note>())).Callback(
                (Note entity) =>
                {
                    var note = notes.SingleOrDefault(note => note.Id == entity.Id);
                    note.Color = entity.Color;
                    note.Tag = entity.Tag;
                    note.UserId = entity.UserId;
                    note.Text = entity.Text;
                    notes[notes.IndexOf(note)] = entity;
                }
            );

            mockNoteRepo.Setup(x => x.Remove(It.IsAny<int>())).Callback(
                (int id) =>
                {
                    var note = notes.SingleOrDefault(note => note.Id == id);
                    notes.Remove(note);
                }
            );

            return mockNoteRepo.Object;
        }
    }
}
