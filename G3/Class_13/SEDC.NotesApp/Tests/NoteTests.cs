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

        [TestMethod]
        public void RemoveNote_ValidNoteId_SuccessMessage()
        {
            // Arrange
            NoteService service = new NoteService(new FakeNoteRepository());
            string expectedResult = "Note deleted succesfully";
            int noteId = 1;

            // Act
            string result = service.RemoveNote(noteId);

            // Assert

            Assert.AreEqual(expectedResult, result);

        }
        [TestMethod]
        public void RemoveNote_InvalidNoteId_ExceptionThrown()
        {
            NoteService service = new NoteService(new FakeNoteRepository());
            int noteId = 100;

            //Act/ Assert

            Assert.ThrowsException<NoteExeption>(() => service.RemoveNote(noteId));
        }

        [TestMethod]
        public void UpdateNote_ValidNote_SuccessMessage()
        {
            // Arrange
            NoteService service = new NoteService(new FakeNoteRepository());
            string expectedResult = "Note updated succesfully";
            NoteDto model = new NoteDto()
            {
                Id = 1,
                Text = "New Note",
                Color = "blue",
                Tag = Tag.Education,
                UserId = 1
            };

            //act
            string result = service.UpdateNote(model);

            // Assert

            Assert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void UpdateNote_InvalidNote_ExceptionThrown()
        {
            //Arrange 
            NoteService service = new NoteService(new FakeNoteRepository());
            NoteDto model = new NoteDto()
            {
                Id = 1293462,
                Text = "New Note",
                Color = "blue",
                Tag = Tag.Education,
                UserId = 1
            };

            // act/assert

            Assert.ThrowsException<NoteExeption>(() => service.UpdateNote(model));
        }
    }
}
