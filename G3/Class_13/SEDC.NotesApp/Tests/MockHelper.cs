using Moq;
using SEDC.NotesApp.Models.DbModels;
using SEDC.NotesApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Tests
{
    public static class MockHelper
    {

        public static IRepository<User> MockUserRepository()
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes("sedc123"));
            var hashedpassword = Encoding.ASCII.GetString(md5Data);

            List<User> users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "John",
                    LastName = "Doe",
                    UserName = "John_Doe",
                    Password = hashedpassword
                }
            };

            Mock<IRepository<User>> mockUserRepo = new Mock<IRepository<User>>();
            mockUserRepo.Setup(x => x.GetAll()).Returns(users);
            mockUserRepo.Setup(x => x.GetById(It.IsAny<int>())).Returns(
                (int id) => users.SingleOrDefault(user => user.Id == id)
            );
            mockUserRepo.Setup(x => x.Update(It.IsAny<User>())).Callback(
                (User user) =>
                {
                    User dbUser = users.SingleOrDefault(u => u.Id == user.Id);
                    var md5 = new MD5CryptoServiceProvider();
                    var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes(user.Password));
                    var hashedPassword = Encoding.ASCII.GetString(md5Data);
                    user.Password = hashedPassword;
                    users[users.IndexOf(dbUser)] = user;
                }
            );
            mockUserRepo.Setup(x => x.Remove(It.IsAny<int>())).Callback(
                (int id) =>
                {
                    var user = users.SingleOrDefault(u => u.Id == id);
                    users.Remove(user);
                }
            );
            mockUserRepo.Setup(x => x.Add(It.IsAny<User>())).Callback(
                (User user) =>
                {
                    users.Add(user);
                }
            );

            return mockUserRepo.Object;
        }



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
