using SEDC.Notes.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Notes.Models.Dto
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public TagType? TagType { get; set; }
        public DateTime DateCreated { get; set; }
        public int UserId { get; set; }
    }
}
