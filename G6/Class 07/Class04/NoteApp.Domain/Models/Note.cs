using NoteApp.Domain.Models;
using SEDC.NotesApp.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace NoteApp.Domain
{
    public class Note
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public TagType Tag { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
