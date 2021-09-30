using SEDC.NotesApp.DataModels;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.NotesApp.DataAccess
{
    public static class CacheDb
    {
        public static int UserId = 1;
        public static List<User> Users = new List<User>
        {
            new User{ Id=1,Firstname="John", LastName="Smith", Username="JohnS", Password="111222333"}
        };

        public static int NoteId = 2;
        public static List<Note> Notes = new List<Note>
        {
            new Note{ Id=1, Text= "Buy Juice", Color= "blue", Tag= 4, UserId= Users.First().Id},
            new Note{ Id=2, Text="Learn ASP.NET Core WebApi", Color= "orange", Tag= 1, UserId= Users.First().Id }
        };
    }
}
