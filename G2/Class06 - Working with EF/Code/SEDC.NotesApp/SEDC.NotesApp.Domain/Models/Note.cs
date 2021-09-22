using SEDC.NotesApp.Domain.Enums;

namespace SEDC.NotesApp.Domain.Models
{
    public class Note : BaseEntity
    {
        public string Text { get; set; }

        public string Color { get; set; }

        public TagEnum Tag { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
