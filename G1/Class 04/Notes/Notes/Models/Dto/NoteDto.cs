using Notes.Models.Enums;
using System;

namespace Notes.Models.Dto
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public TagType TagType { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
