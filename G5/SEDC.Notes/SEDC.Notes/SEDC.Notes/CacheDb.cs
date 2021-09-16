using SEDC.Notes.Models.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Notes
{
    public static class CacheDb
    {

        public static List<User> Users = new List<User>
        {
            new User 
            {
                Id = 1,
                FirstName = "Viktor",
                LastName = "Jakovlev",
                Username = "vjaklovlev",
                Password = "P@ssw0rd"
            }
        };

        public static List<Note> Notes = new List<Note>
        {
            new Note 
            {
                Id = 1,
                Text = "Buy Juice",
                Color = "blue",
                Tag = 4,
                DateCreated = DateTime.Now,
                UserId = Users.First().Id
            },
            new Note
            {
                Id = 2,
                Text = "Learn ASP.NET Core WebApi",
                Color = "red",
                Tag = 1,
                DateCreated = DateTime.Now,
                UserId = Users.First().Id
            }
        };


    }
}
