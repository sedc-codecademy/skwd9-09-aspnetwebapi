﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => $"{ FirstName } { LastName}";
        public string Token { get; set; }
        public List<NoteModel> Notes { get; set; }

        public UserModel()
        {
            Notes = new List<NoteModel>();
        }

    }
}
