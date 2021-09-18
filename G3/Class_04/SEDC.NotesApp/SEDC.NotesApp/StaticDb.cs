using SEDC.NotesApp.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.NotesApp
{
    public static class StaticDb
    {
        public static List<User> Users = new List<User>()
        {
            new User()
            {
                Id = 1,
                UserName = "John_Doe",
                Password = "john123",
                FirstName = "John",
                LastName = "Doe"
            },
            new User()
            {
                Id = 2,
                UserName = "Jane_Doe",
                Password = "jane123",
                FirstName = "Jane",
                LastName = "Doe"
            }
        };

        public static List<Note> Notes = new List<Note>()
        {
            new Note()
            {
                Id = 1,
                Text = "Go to gym",
                Color = "blue",
                Tag = 4,
                UserId = Users.First().Id
            },
            new Note()
            {
                Id = 2,
                Text = "Wash the dishes",
                Color = "red",
                Tag = 3,
                UserId = 2
            },
            new Note()
            {
                Id = 3,
                Text = "Do the homework",
                Color = "green",
                Tag = 2,
                UserId = Users.First().Id
            }
        };
    }
}
