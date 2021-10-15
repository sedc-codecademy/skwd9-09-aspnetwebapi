using SEDC.NotesApp.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.NotesApp.Models.DtoModels
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string NoteText { get; set; }
        public string NoteColor { get; set; }
        public int UserId { get; set; }
        public string Tag { get; set; }
    }
}
