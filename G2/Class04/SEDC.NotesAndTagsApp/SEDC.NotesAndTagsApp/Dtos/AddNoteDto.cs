using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.NotesAndTagsApp.Dtos
{
    public class AddNoteDto
    {
        public string Text { get; set; }
        public string Color { get; set; }
        public int UserId { get; set; }
        public List<TagDto> Tags { get; set; }
    }
}
