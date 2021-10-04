using SEDC.Notes.RequestModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.Notes.Services.Interfaces
{
    public interface INoteService
    {
        void AddNote(NoteRequestModel requestModel);
        IEnumerable<NoteRequestModel> GetUserNotes(int userId);
        NoteRequestModel GetUserNoteById(int userId, int id);
        void DeleteNoteById(int userId, int id);
        void UpdateNote(NoteRequestModel requestModel);
    }
}
