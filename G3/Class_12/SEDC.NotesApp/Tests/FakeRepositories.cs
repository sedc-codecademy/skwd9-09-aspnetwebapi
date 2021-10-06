using SEDC.NotesApp.Models.DbModels;
using SEDC.NotesApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Tests
{

    public class FakeNoteRepository : IRepository<Note>
    {
        private List<Note> notes;

        public FakeNoteRepository()
        {
            notes = new List<Note>()
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
        }

        public void Add(Note entity)
        {
            notes.Add(entity);
        }

        public List<Note> GetAll()
        {
            return notes;
        }

        public Note GetById(int id)
        {
            return notes.SingleOrDefault(note => note.Id == id);
        }

        public void Remove(int id)
        {
            Note note = notes.SingleOrDefault(note => note.Id == id);
            notes.Remove(note);
        }

        public void Update(Note entity)
        {
            notes[notes.IndexOf(entity)] = entity;
        }
    }





    public class FakeUserRepository : IRepository<User>
    {
        private List<User> users;

        public FakeUserRepository()
        {
            var md5 = new MD5CryptoServiceProvider();
            var md5Data = md5.ComputeHash(Encoding.ASCII.GetBytes("kabov123"));
            var hashedPassword = Encoding.ASCII.GetString(md5Data);
            users = new List<User>()
            {
                new User()
                {
                    Id = 1,
                    FirstName = "Goce",
                    LastName = "Kabov",
                    UserName = "Goce_Kabov",
                    Password = hashedPassword
                }
            };
        }
        public void Add(User entity)
        {
            users.Add(entity);
        }

        public List<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            return users.SingleOrDefault(user => user.Id == id);
        }

        public void Remove(int id)
        {
            User user = users.SingleOrDefault(user => user.Id == id);
            users.Remove(user);
        }

        public void Update(User entity)
        {
            var index = users.IndexOf(entity);
            users[index] = entity;
        }
    }
}
