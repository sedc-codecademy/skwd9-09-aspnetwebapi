using SEDC.NotesAPI.Domain.Models;
using SEDC.NotesAPI.Models.Notes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesAPI.Mappers
{
    public static class NoteMapper
    {
        public static Note ToNote(this NoteModel noteModel)
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

        public static NoteModel ToNoteModel(this Note note)
        {
            return new NoteModel
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
