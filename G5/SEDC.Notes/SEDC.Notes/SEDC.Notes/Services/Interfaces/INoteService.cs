using SEDC.Notes.Models.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Notes.Services.Interfaces
{
    public interface INoteService
    {
        List<NoteDto> GetUserNotes(int userId);
        string AddNote(NoteDto note);
        NoteDto GetNoteDetails(int noteId, int userId);
        string DeleteNote(int noteId, int userId);
        string UpdateNote(NoteDto note);
    }
}
