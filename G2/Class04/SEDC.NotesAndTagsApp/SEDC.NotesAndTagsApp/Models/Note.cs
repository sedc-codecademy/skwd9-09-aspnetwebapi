using System.Collections.Generic;

namespace SEDC.NotesAndTagsApp.Models
{
    public class Note : BaseEntity
    {
        public string Text { get; set; }
        public string Color { get; set; }
        public List<Tag> Tags { get; set; }
        public User User { get; set; }
    }
}
