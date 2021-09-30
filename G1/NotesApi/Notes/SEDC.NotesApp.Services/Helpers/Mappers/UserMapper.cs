using SEDC.NotesApp.DataModels;
using SEDC.NotesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.NotesApp.Services.Helpers.Mappers
{
    public class UserMapper
    {
        public static User RegisterModelToUser(RegisterModel model)
        {
            return new User
            {
                Firstname = model.FirstName,
                LastName = model.LastName,
                Username = model.Username,
                Password = model.Password
            };
        }  
    }
}
