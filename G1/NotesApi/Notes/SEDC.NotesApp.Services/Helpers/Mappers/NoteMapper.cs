using SEDC.NotesApp.DataModels;
using SEDC.NotesApp.Models;

namespace SEDC.NotesApp.Services.Helpers.Mappers
{
    public static class NoteMapper
    {
        public static NoteModel NoteModelToNoteModel(Note note)
        {
            return new NoteModel
            {
                Id = note.Id,
                Color = note.Color,
                Text = note.Text,
                TagType = (TagType)note.Tag,
                UserId = note.UserId,
                DateCreated = note.DateCreated
            };
        }

        public static Note NoteModelToNoteModel(NoteModel note)
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
