using SEDC.NoteApp2.Shared.Enums;

namespace SEDC.NoteApp2.Dto.Models
{
    public class NoteDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
        public TagType Tag { get; set; }
        public int UserId { get; set; }
        public string UserFullName { get; set; }
    }
}
