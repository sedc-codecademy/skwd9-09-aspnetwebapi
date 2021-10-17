using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using SEDC.NotesAPI.Shared.Exceptions;
using SEDC.NotesAPI.Services.Interfaces;
using SEDC.NotesAPI.Services.Implementations;
using SEDC.NotesAPI.Models.Notes;
using SEDC.NotesAPI.Shared.Enums;

namespace Tests
{
    [TestClass]
    public class NoteTestsMoq
    {
        [ExpectedException(typeof(NoteException))]
        [TestMethod]
        public void AddNote_InvalidNote_Exception_Moq()
        {
            // Arrange
            INoteService noteService = new NoteService(MockHelper.MockNoteRepository(), MockHelper.MockUserRepository());
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
