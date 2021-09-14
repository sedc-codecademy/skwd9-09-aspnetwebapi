using Notes.Models.Data;
using Notes.Models.Dto;
using Notes.Models.Enums;

namespace Notes.Models.Mappers
{
    public static class NoteMapper
    {
        public static NoteDto NoteModelToNoteDto(Note note)
        {
            return new NoteDto
            {
                Id = note.Id,
                Color = note.Color,
                Text = note.Text,
                TagType = (TagType)note.Tag,
                UserId = note.UserId,
                DateCreated = note.DateCreated
            };
        }

        public static Note NoteDtoToNoteModel(NoteDto note)
        {
            return new Note
            {
                Id = note.Id != 0 ? note.Id : 0,
                Color = note.Color,
                Text = note.Text,
                Tag = (int)note.TagType,
                UserId = note.UserId,
                DateCreated = note.DateCreated
            };
        }
    }
}
