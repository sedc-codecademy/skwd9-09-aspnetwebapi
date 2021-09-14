using Notes.Models.Dto;
using System;
using System.Collections.Generic;

namespace Notes.Services.Interface
{
    public interface INoteService
    {
        List<NoteDto> GetUserNotes(int userId);
        NoteDto GetNoteDetails(int noteId, int userId);
        string AddNote(NoteDto note);
        string DeleteNote(int noteId, int userId);
        void UpdateNote(NoteDto note);
        List<NoteDto> GetUserNotesFilteredByDateTime(int userId, DateTime dateTime);
    }
}
