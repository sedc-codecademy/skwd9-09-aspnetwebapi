using Moq;
using SEDC.NotesApp.DataAccess;
using SEDC.NotesApp.DataModels;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.NotesApp.Tests
{
    public static class MockHelper
    {
        public static IRepository<User> MockUserRepository()
        {
            var md5 = new MD5CryptoServiceProvider();
            byte[] passwordData = md5.ComputeHash(Encoding.ASCII.GetBytes("12345sedc"));
            string hashedPassword = Encoding.ASCII.GetString(passwordData);

            List<User> users = new List<User>
            {
                new User
                {
                    Id = 1,
                    Firstname = "Bob",
                    LastName = "Bobsky",
                    Username = "bob007",
                    Password = hashedPassword
                }
            };


            Mock<IRepository<User>> mockUserRepo = new Mock<IRepository<User>>();

            mockUserRepo.Setup(x => x.GetAll()).Returns(users);

            mockUserRepo.Setup(x => x.Add(
                It.IsAny<User>())).Callback((User user) =>
                {
                    users.Add(user);
                });

            mockUserRepo.Setup(x => x.Update(
                It.IsAny<User>())).Callback((User user) =>
                {
                    users[users.IndexOf(user)] = user;
                });

            mockUserRepo.Setup(x => x.Delete(
                It.IsAny<User>())).Callback((User user) =>
                {
                    users.Remove(user);
                });

            return mockUserRepo.Object;
        }


        public static IRepository<Note> MockNoteRepository()
        {
            List<Note> notes = new List<Note>
            {
                new Note
                {
                    Id = 1,
                    Text = "Don't forget to water the plant!",
                    Color = "orange",
                    Tag = 2,
                    UserId = 1
                },
                new Note
                {
                    Id = 2,
                    Text = "Drink more water",
                    Color = "red",
                    Tag = 3,
                    UserId = 1
                }
            };

            Mock<IRepository<Note>> mockNoteRepo = new Mock<IRepository<Note>>();

            mockNoteRepo.Setup(x => x.GetAll()).Returns(notes);

            mockNoteRepo.Setup(x => x.Add(
                It.IsAny<Note>())).Callback((Note note) =>
                {
                    notes.Add(note);
                });

            mockNoteRepo.Setup(x => x.Update(
                It.IsAny<Note>())).Callback((Note note) =>
                {
                    notes[notes.IndexOf(note)] = note;
                });

            mockNoteRepo.Setup(x => x.Delete(
                It.IsAny<Note>())).Callback((Note note) =>
                {
                    notes.Remove(note);
                });

            return mockNoteRepo.Object;
        }
    }
}
