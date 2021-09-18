using System.Collections.Generic;

namespace SEDC.NotesAndTagsApp.Models
{
    public class Note
    {
        public string Text { get; set; }
        public string Color { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
