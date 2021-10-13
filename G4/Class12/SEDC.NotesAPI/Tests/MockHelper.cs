using Moq;
using SEDC.NotesAPI.DataAccess.Interfaces;
using SEDC.NotesAPI.Domain.Models;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Linq;
using SEDC.NotesAPI.Shared.Enums;
using static SEDC.NotesAPI.DataAccess.Interfaces.IRepository;

namespace Tests
{
    public static class MockHelper
    {
        public static IUserRepository MockUserRepository()
        {
            // We create an instance of the MD5CryptoServiceProvider that will help us create the hash
            var md5 = new MD5CryptoServiceProvider();
            // We create the hash from the password
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes("netikazuvam123"));
            // We get the hash string
            var hashedPassword = Encoding.ASCII.GetString(md5Data);

            List<User> users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "Bob",
                    LastName = "Bobsky",
                    Username = "bob123",
                    Password = hashedPassword
                }
            };

            Mock<IUserRepository> mockUserRepository = new Mock<IUserRepository>();

            mockUserRepository.Setup(x => x.GetAll()).Returns(users);

            mockUserRepository.Setup(x => x.GetById(
                It.IsAny<int>())).Returns((int id) => users.FirstOrDefault(u => u.Id == id));

            mockUserRepository.Setup(x => x.Add(
                It.IsAny<User>())).Callback((User user) =>
                {
                    users.Add(user);
                });

            mockUserRepository.Setup(x => x.Update(
                It.IsAny<User>())).Callback((User user) =>
                {
                    users[users.IndexOf(user)] = user;
                });

            mockUserRepository.Setup(x => x.Delete(
                It.IsAny<User>())).Callback((User user) =>
                {
                    users.Remove(user);
                });

            mockUserRepository.Setup(x => x.GetUserByUsername(
                It.IsAny<string>())).Returns((string username) => users.FirstOrDefault(u => u.Username == username));

            mockUserRepository.Setup(x => x.LoginUser(
                It.IsAny<string>(), It.IsAny<string>())).Returns((string username, string password) => users.FirstOrDefault(u => u.Username == username));

            return mockUserRepository.Object;
        }

        public static IRepository<Note> MockNoteRepository()
        {
            List<Note> notes = new List<Note>()
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

            Mock<IRepository<Note>> mockNoteRepository = new Mock<IRepository<Note>>();

            mockNoteRepository.Setup(x => x.GetAll()).Returns(notes);

            mockNoteRepository.Setup(x => x.Add(
                It.IsAny<Note>())).Callback((Note note) =>
                {
                    notes.Add(note);
                });

            mockNoteRepository.Setup(x => x.Update(
                It.IsAny<Note>())).Callback((Note note) =>
                {
                    notes[notes.IndexOf(note)] = note;
                });

            mockNoteRepository.Setup(x => x.Delete(
                It.IsAny<Note>())).Callback((Note note) =>
                {
                    notes.Remove(note);
                });

            return mockNoteRepository.Object;
        }
    }
}
