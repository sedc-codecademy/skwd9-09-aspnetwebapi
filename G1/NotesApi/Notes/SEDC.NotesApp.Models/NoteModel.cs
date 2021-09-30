using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Models
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public TagType TagType { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }

    public enum TagType
    {
        Work = 1,
        Education,
        Home,
        Misc,
        Other
    }
}
