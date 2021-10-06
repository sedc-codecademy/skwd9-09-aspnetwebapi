using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEDC.NotesApp.Models.DbModels;
using SEDC.NotesApp.Models.DtoModels;
using SEDC.NotesApp.Models.Enums;
using SEDC.NotesApp.Services;
using SEDC.NotesApp.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestClass]
    public class NoteTests
    {
        [TestMethod]
        public void CreateNote_ValidNote_SuccessMessage()
        {
            // Arrange
            NoteService noteService = new NoteService(new FakeNoteRepository());
            string successMessage = "Note was created succesfully";
            // int expectedResult = 3;

            NoteDto model = new NoteDto()
            {
                Id = 3,
                Text = "Test api",
                Color = "green",
                Tag = Tag.Work,
                UserId = 1
            };

            // Act
            var result = noteService.AddNewNote(model);

            // Assert
            // Assert.AreEqual(successMessage, result);
            // List<NoteDto> resultNotes = noteService.GetAllUserNotes(1);
            Assert.AreEqual(successMessage, result);

        }

        [TestMethod]
        public void CreateNewNote_InvalidNote_ExceptionThrown()
        {
            NoteService noteService = new NoteService(new FakeNoteRepository());

            NoteDto model = new NoteDto()
            {
                Id = 3,
                Text = "",
                Color = "green",
                Tag = Tag.Work,
                UserId = 1
            };

            Assert.ThrowsException<BadRequestException>(() => noteService.AddNewNote(model));
        }

        [TestMethod]
        public void GetAllUserNotes_ValidUserId_AllNotesForThatUser()
        {
            NoteService noteService = new NoteService(new FakeNoteRepository());
            int expectedResult = 2;
            int userId = 1;

            List<NoteDto> result = noteService.GetAllUserNotes(userId);

            Assert.AreEqual(expectedResult, result.Count);
        }

        [TestMethod]
        public void GetAllUserNotes_InvalidUserId_EmptyList()
        {
            NoteService noteService = new NoteService(new FakeNoteRepository());
            int expectedResult = 0;
            int userId = 3;

            List<NoteDto> result = noteService.GetAllUserNotes(userId);

            Assert.AreEqual(expectedResult, result.Count);
        }
    }
}
