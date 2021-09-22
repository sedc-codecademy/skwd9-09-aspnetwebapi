using SEDC.NotesApp.Models;
using System;
using System.Collections.Generic;

namespace SEDC.NotesApp.Services.Interface
{
    public interface INoteService
    {
        List<NoteModel> GetUserNotes(int userId);
        NoteModel GetNoteDetails(int noteId, int userId);
        string AddNote(NoteModel note);
        string DeleteNote(int noteId, int userId);
        void UpdateNote(NoteModel note);
        List<NoteModel> GetUserNotesFilteredByDateTime(int userId, DateTime dateTime);
    }
}
