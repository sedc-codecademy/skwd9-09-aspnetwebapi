using SEDC.NotesAPI.Models.Notes;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesAPI.Services.Interfaces
{
    public interface INoteService
    {
        List<NoteModel> GetAllNotes();
        NoteModel GetNoteById(int id);
        void AddNote(AddNoteModel noteModel);
        void UpdateNote(NoteModel noteModel);
        void DeleteNote(int id);
    }
}
