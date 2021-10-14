using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEDC.NotesAPI.Models.Notes;
using SEDC.NotesAPI.Services.Implementations;
using SEDC.NotesAPI.Services.Interfaces;
using SEDC.NotesAPI.Shared.Enums;
using SEDC.NotesAPI.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class NoteTests
    {
        [ExpectedException(typeof(NoteException))]
        [TestMethod]
        public void AddNote_InvalidNote_Exception()
        {
            // Arrange
            INoteService noteService = new NoteService(new FakeNoteRepository(), new FakeUserRepository());
            NoteModel noteModel = new NoteModel()
            {
                Id = 4,
                Text = "",
                Color = "red",
                Tag = TagType.Work,
                UserId = 1
            };

            // Act / Assert
            noteService.AddNote(noteModel);

        }
    }
}
