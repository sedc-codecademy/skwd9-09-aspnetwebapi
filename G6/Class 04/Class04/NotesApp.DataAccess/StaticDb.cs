﻿using NoteApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.DataAccess
{
    public class StaticDb
    {
        public static List<NoteModel> Notes = new List<NoteModel>()
        {
            //new Note(){Id = 1, Text = "Do Homework", Color = "blue", Tags = new List<Tag>()
            //{
            //    new Tag{Name = "Homework", Color = "cyan"},
            //    new Tag(){Name = "SEDC", Color = "blue"}
            //}
            //},

            //new Note(){Id = 2, Text = "Drink more Water", Color = "blue", Tags = new List<Tag>()
            //{
            //    new Tag{Name = "Healthy", Color = "orange"},
            //    new Tag(){Name = "Priority High", Color = "red"}
            //}
            //},

            // new Note(){Id = 3, Text = "Go to gym", Color = "blue", Tags = new List<Tag>()
            //{
            //    new Tag{Name = "exercise", Color = "green"},
            //    new Tag(){Name = "Priority Medium", Color = "yellow"}
            //}
            //},
        };

        public static int NoteId { get; set; } = 3;
    }
}
