using SEDC.NotesAPI.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesAPI.Models.Notes
{
    public class NoteModel
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public TagType Tag { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
    }
}
