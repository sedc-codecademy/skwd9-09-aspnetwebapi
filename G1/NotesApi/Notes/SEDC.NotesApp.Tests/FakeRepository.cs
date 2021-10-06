using SEDC.NotesApp.DataAccess;
using SEDC.NotesApp.DataModels;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace SEDC.NotesApp.Tests
{
    public class FakeUserRepository : IRepository<User>
    {
        private List<User> users;

        public FakeUserRepository()
        {
            var md5 = new MD5CryptoServiceProvider();
            byte[] passwordData = md5.ComputeHash(Encoding.ASCII.GetBytes("12345sedc"));
            string hashedPassword = Encoding.ASCII.GetString(passwordData);

            users = new List<User>
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
        }

        public void Add(User entity)
        {
            users.Add(entity);
        }

        public void Delete(User entity)
        {
            users.Remove(entity);
        }

        public List<User> GetAll()
        {
            return users;
        }

        public void Update(User entity)
        {
            users[users.IndexOf(entity)] = entity;
        }
    }

    public class FakeNoteRepository : IRepository<Note>
    {
        private List<Note> notes;
        public FakeNoteRepository()
        {
            notes = new List<Note>
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
        }


        public void Add(Note entity)
        {
            notes.Add(entity);
        }

        public void Delete(Note entity)
        {
            notes.Remove(entity);
        }

        public List<Note> GetAll()
        {
            return notes;
        }

        public void Update(Note entity)
        {
            notes[notes.IndexOf(entity)] = entity;
        }
    }
}
