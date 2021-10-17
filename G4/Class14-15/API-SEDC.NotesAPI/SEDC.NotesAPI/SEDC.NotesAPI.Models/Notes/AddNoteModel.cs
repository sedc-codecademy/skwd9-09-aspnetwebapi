using SEDC.NotesAPI.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesAPI.Models.Notes
{
    public class AddNoteModel
    {
        public string Text { get; set; }
        public string Color { get; set; }
        public int Tag { get; set; }
        public int UserId { get; set; }
    }
}
