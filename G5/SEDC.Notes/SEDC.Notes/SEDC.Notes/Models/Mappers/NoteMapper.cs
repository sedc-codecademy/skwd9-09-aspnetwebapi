using SEDC.Notes.Models.Data;
using SEDC.Notes.Models.Dto;
using SEDC.Notes.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Notes.Models.Mappers
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
                DateCreated = note.DateCreated,
                UserId = note.UserId
            };
        }

        public static Note NoteDtoToNoteModel(NoteDto note) 
        {
            return new Note
            {
                Id = note.Id,
                Color = note.Color,
                Text = note.Text,
                Tag = (int)note.TagType,
                DateCreated = note.DateCreated,
                UserId = note.UserId
            };
        }
    }
}
