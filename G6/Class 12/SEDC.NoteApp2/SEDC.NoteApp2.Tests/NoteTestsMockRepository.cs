﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using SEDC.NoteApp2.Dto.Models;
using SEDC.NoteApp2.Services.Implementations;
using SEDC.NoteApp2.Services.Interfaces;
using SEDC.NoteApp2.Shared.Exceptions;
using SEDC.NoteApp2.Tests.MockRepositories;

namespace SEDC.NoteApp2.Tests
{
    [TestClass]
    public class NoteTestsMockRepository
    {
        [TestMethod]
        public void GetNoteById_ValidId_Note()
        {
            // Arrange 
            INoteService noteService = new NoteService(MockNoteRepository.GetMockUserRepository());
            int noteId = 1;
            string noteText = "My First Note";

            // Act 
            NoteDto result = noteService.GetNoteById(noteId);

            // Assert
            Assert.AreEqual(noteText, result.Text);
        }

        [TestMethod]
        public void GetNoteById_InvalidId_NoteException()
        {
            // Arrange 
            INoteService noteService = new NoteService(MockNoteRepository.GetMockUserRepository());
            int noteId = 100;

            // Act // Assert
            Assert.ThrowsException<NoteException>(() => noteService.GetNoteById(noteId));
        }
    }
}
