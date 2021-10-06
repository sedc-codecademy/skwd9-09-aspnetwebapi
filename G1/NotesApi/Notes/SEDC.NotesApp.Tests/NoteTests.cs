using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEDC.NotesApp.Api.Services;
using SEDC.NotesApp.Models;
using SEDC.NotesApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.NotesApp.Tests
{
    [TestClass]
    public class NoteTests
    {
        [TestMethod]
        public void GetUserNotes_ValidUserId_AllNotesForThatUser()
        {
            // Arrange
            INoteService noteService = new NoteService(new FakeNoteRepository());
            int userId = 1;
            int expectedResult = 2;

            // Act
            IEnumerable<NoteModel> result = noteService.GetUserNotes(userId);

            // Assert
            Assert.AreEqual(expectedResult, result.ToList().Count);
        }

        [TestMethod]
        public void GetUserNotes_InvalidUserId_Null()
        {
            // Arrange
            INoteService noteService = new NoteService(new FakeNoteRepository());
            int userId = 22;
            int expectedResult = 0;

            // Act
            IEnumerable<NoteModel> result = noteService.GetUserNotes(userId);

            // Assert
            Assert.AreEqual(expectedResult, result.ToList().Count);
        }

        [TestMethod]
        public void GetNoteDetails_ValidUserId_Note()
        {
            // Arrange
            INoteService noteService = new NoteService(new FakeNoteRepository());
            int userId = 1;
            int noteId = 1;
            int expectedResult = 1;

            // Act
            NoteModel result = noteService.GetNoteDetails(noteId, userId);

            // Assert
            Assert.AreEqual(expectedResult, result.Id);
        }

        [TestMethod]
        public void GetNoteDetails_InvalidUserId_Exception()
        {
            // Arrange
            INoteService noteService = new NoteService(new FakeNoteRepository());
            int userId = 12;
            int noteId = 1;

            // Act / Assert
            Assert.ThrowsException<Exception>(() => noteService.GetNoteDetails(noteId, userId));
        }

        // TODO: For homework try to implement tests for AddNote_NoteAdded and DeleteNote_NoteDeleted methods from NoteService

    }
}
