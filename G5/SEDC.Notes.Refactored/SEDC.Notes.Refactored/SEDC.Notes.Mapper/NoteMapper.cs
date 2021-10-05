using SEDC.Notes.DomainModels;
using SEDC.Notes.RequestModels;
using SEDC.Notes.RequestModels.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Notes.Mapper
{
    public static class NoteMapper
    {

        public static Note MapToNote(NoteRequestModel requestModel) 
        {
            return new Note()
            {
                Text = requestModel.Text,
                Color = requestModel.Color,
                Tag = (int)requestModel.Tag,
                UserId = requestModel.UserId
            };
        }


        public static NoteRequestModel MapToNoteRequestModel(Note note) 
        {
            return new NoteRequestModel()
            {
                Id = note.Id,
                Text = note.Text,
                Color = note.Color,
                Tag = (TagType)note.Tag,
                UserId = note.UserId
            };
        }

    }
}
