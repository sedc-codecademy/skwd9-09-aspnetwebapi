using SEDC.NotesAndTagsApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.NotesAndTagsApp
{
    public static class StaticDb
    {
        public static List<User> Users = new List<User>
        {
            new User
            {
                Id = 1,
                FirstName = "tanja",
                LastName = "Stojanovska",
                Username = "tstojanovska",
                Password = "123"
            },
            new User
            {
                Id = 2,
                FirstName = "Aleksandar",
                LastName = "Manasiev",
                Username = "amanasiev",
                Password = "123"
            }
        };
        public static List<Note> Notes = new List<Note>()
        {
            new Note(){ Id =1, Text = "Do Homework", Color = "blue", Tags = new List<Tag>()
                {
                    new Tag(){ Id = 1, Name = "HomeWork", Color = "cyan"},
                    new Tag(){ Id = 2, Name = "SEDC", Color = "blue"}
                },
                User = Users.First()
            },
            new Note(){ Id=2, Text = "Drink more Water", Color = "blue", Tags = new List<Tag>()
                {
                    new Tag(){ Id = 3, Name = "Healthy", Color = "orange"},
                    new Tag(){ Id = 4, Name = "Priority High", Color = "red"},
                    new Tag(){ Id = 7, Name = "Healthy lifestyle", Color = "green"}
                },
                User = Users.Last()
            },
            new Note(){ Id =3, Text = "Go to the gym", Color = "blue", Tags = new List<Tag>()
                {
                    new Tag(){ Id = 5, Name = "exercise", Color = "blue"},
                    new Tag(){ Id = 6, Name = "Priority Medium", Color = "yellow"},
                    new Tag(){ Id = 7, Name = "Healthy lifestyle", Color = "green"}
                },
                User = Users.First()
            }
        };
    }
}
