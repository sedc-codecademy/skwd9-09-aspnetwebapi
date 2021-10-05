using SEDC.Notes.Common.Exceptions;
using SEDC.Notes.DataAccess.Repositories.Interfaces;
using SEDC.Notes.DomainModels;
using SEDC.Notes.Mapper;
using SEDC.Notes.RequestModels;
using SEDC.Notes.RequestModels.Enums;
using SEDC.Notes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SEDC.Notes.Services.Classes
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;

        public NoteService(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }

        public void AddNote(NoteRequestModel requestModel)
        {
            if (string.IsNullOrEmpty(requestModel.Text)) 
            {
                throw new NoteException(requestModel.Id, requestModel.UserId, "Text field is requred!");
            }

            if (string.IsNullOrEmpty(requestModel.Color))
            {
                throw new NoteException(requestModel.Id, requestModel.UserId, "Color field is requred!");
            }

            var Note = NoteMapper.MapToNote(requestModel);
            _noteRepository.Add(Note);
        }

        public IEnumerable<NoteRequestModel> GetUserNotes(int userId)
        {     
            var userNotes = _noteRepository.GetAll()
                                           .Where(x => x.UserId == userId);

            if (userNotes == null)
            {
                throw new NoteException();
            }

            var notesRequestModel = new List<NoteRequestModel>();

            foreach (var note in userNotes)
            {
                var noteRequestModel = NoteMapper.MapToNoteRequestModel(note);
                notesRequestModel.Add(noteRequestModel);
            }

            return notesRequestModel;

            //return _noteRepository.GetAll()
            //                      .Where(x => x.UserId == userId)
            //                      .Select(x => NoteMapper.MapToNoteRequestModel(x));
        }

        public NoteRequestModel GetUserNoteById(int userId, int id)
        {
            var note = _noteRepository.GetAll()
                                      .SingleOrDefault(x => x.UserId == userId && x.Id == id);

            if (note == null) 
            {
                throw new NoteException(id, userId, "Note not found!");
            }

            return NoteMapper.MapToNoteRequestModel(note);
        }

        public void DeleteNoteById(int userId, int id)
        {
            var note = _noteRepository.GetAll()
                                      .SingleOrDefault(x => x.UserId == userId && x.Id == id);

            if (note == null)
            {
                throw new NoteException(id, userId, "Note not found!");
            }

            _noteRepository.Delete(note);
        }

        public void UpdateNote(NoteRequestModel requestModel)
        {
            var note = _noteRepository.GetAll()
                                      .SingleOrDefault(x => x.UserId == requestModel.UserId && x.Id == requestModel.Id);

            if (note == null)
            {
                throw new NoteException(note.Id, note.UserId, "Note not found!");
            }

            if (!string.IsNullOrEmpty(requestModel.Text)) 
            {
                note.Text = requestModel.Text;
            }

            if (!string.IsNullOrEmpty(requestModel.Color))
            {
                note.Color = requestModel.Color;
            }

            if (requestModel.Tag != 0) 
            {
                note.Tag = (int)requestModel.Tag;
            }

            _noteRepository.Update(note);
        }
    }
}
