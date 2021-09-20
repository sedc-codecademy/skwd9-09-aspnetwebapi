using NoteApp.Domain;
using NoteApp.Domain.Models;
using NotesApp.DataAccess;
using NotesApp.Services.Interfaces;
using SEDC.NotesApp.Mappers;
using SEDC.NotesApp.Models;
using SEDC.NotesApp.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.Services.Implementations
{
    public class NoteService : INoteService
    {
        private IRepository<Note> _noteRepository;
        private IRepository<User> _userRepository;
        public NoteService(IRepository<Note> noteRepository, IRepository<User> userRepository)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
        }
        public void AddNote(NoteModel noteModel)
        {
            User userDb = ValidateNoteModel(noteModel);

            Note noteForDb = noteModel.ToNote();
            noteForDb.User = userDb;
            _noteRepository.Add(noteForDb);
        }

        public void DeleteNote(int id)
        {
            Note noteDb = _noteRepository.GetById(id);
            if(noteDb == null)
            {
                throw new NotFoundException(id);
            }
            _noteRepository.Delete(noteDb);
        }

        public List<NoteModel> GetAllNotes()
        {
            List<Note> notesDb = _noteRepository.GetAll();
            List<NoteModel> noteModels = new List<NoteModel>();

            foreach(Note note in notesDb)
            {
                noteModels.Add(note.ToNoteModel());
            }

            return noteModels;
        }

        public NoteModel GetNoteById(int id)
        {
            Note noteDb = _noteRepository.GetById(id);
            if(noteDb == null)
            {
                throw new NotFoundException($"Note with id {id} was not foun!");
            }
            return noteDb.ToNoteModel();
        }

        public void UpdateNote(NoteModel noteModel)
        {
            Note noteDb = _noteRepository.GetById(noteModel.Id);
            if(noteDb == null)
            {
                throw new NotFoundException(noteModel.Id);
            }
            User userDb = ValidateNoteModel(noteModel);

            noteDb = noteModel.ToNote();
            _noteRepository.Update(noteDb);

        }

        private User ValidateNoteModel(NoteModel noteModel)
        {
            User userDb = _userRepository.GetById(noteModel.UserId);
            if(userDb == null)
            {
                throw new NoteException($"The user with id {noteModel.UserId} was not found");
            }

            if (string.IsNullOrEmpty(noteModel.Text))
            {
                throw new NoteException("The property Text for note is required");
            }
            if (noteModel.Text.Length > 100)
            {
                throw new NoteException($"The property Text can not contain more than 100 caracters");
            }
            return userDb;
        }
    }
}
