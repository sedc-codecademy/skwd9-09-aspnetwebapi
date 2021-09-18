using NoteApp.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Mappers
{
    public static class NoteMapper
    {
        public static Note ToNote(this Models.NoteModel noteModel)
        {
            return new Note
            {
                Id = noteModel.Id,
                Text = noteModel.Text,
                Color = noteModel.Color,
                Tag = noteModel.Tag,
                UserId = noteModel.UserId
            };
        }

        public static Models.NoteModel ToNoteModel(this Note note)
        {
            return new Models.NoteModel
            {
                Id = note.Id,
                Text = note.Text,
                Color = note.Color,
                Tag = note.Tag,
                UserId = note.UserId,
                UserFullName = $"{note.User.FirstName} {note.User.LastName}"
            };
        }

    }
}
