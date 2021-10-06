using SEDC.NotesAPI.DataAccess.Interfaces;
using SEDC.NotesAPI.Domain.Models;
using SEDC.NotesAPI.Mappers;
using SEDC.NotesAPI.Models.Notes;
using SEDC.NotesAPI.Services.Interfaces;
using SEDC.NotesAPI.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using static SEDC.NotesAPI.DataAccess.Interfaces.IRepository;

namespace SEDC.NotesAPI.Services.Implementations
{
    public class NoteService : INoteService
    {
        private IRepository<Note> _noteRepository;
        private IUserRepository _userRepository;
        public NoteService(IRepository<Note> noteRepository, IUserRepository userRepository)
        {
            _noteRepository = noteRepository;
            _userRepository = userRepository;
        }

        public void AddNote(NoteModel noteModel)
        {
            User userDb = _userRepository.GetById(noteModel.UserId);
            if (userDb == null)
            {
                throw new NotFoundException($"The user with Id {noteModel.UserId} was not found");
            }
            if (string.IsNullOrEmpty(noteModel.Text))
            {
                throw new NoteException("The property Text for note is required");
            }
            if (noteModel.Text.Length > 100)
            {
                throw new NoteException("The property Text can't contain more then 100 characters");
            }
            if (noteModel.Color.Length > 30)
            {
                throw new NoteException("The property Color can't contain more then 30 characters");
            }
            if (noteModel.Id != 0)
            {
                throw new NoteException("Id must not be set!");
            }
            Note noteForDb = noteModel.ToNote();
            noteForDb.User = userDb;
            _noteRepository.Add(noteForDb);
        }

        public void DeleteNote(int id)
        {
            Note noteDb = _noteRepository.GetById(id);
            if (noteDb == null)
            {
                throw new NotFoundException($"Note with id {id} was not found");
            }
            _noteRepository.Delete(noteDb);
        }

        public List<NoteModel> GetAllNotes()
        {
            List<Note> notesDb = _noteRepository.GetAll();
            List<NoteModel> noteModels = new List<NoteModel>();
            foreach (Note note in notesDb)
            {
                noteModels.Add(note.ToNoteModel());
            }
            return noteModels;
        }

        public NoteModel GetNoteById(int id)
        {
            Note noteDb = _noteRepository.GetById(id);
            if (noteDb == null)
            {
                throw new NotFoundException($"Note with id {id} was not found");
            }

            return noteDb.ToNoteModel();
        }

        public void UpdateNote(NoteModel noteModel)
        {
            Note noteDb = _noteRepository.GetById(noteModel.Id);
            if (noteDb == null)
            {
                throw new NotFoundException($"Note with id {noteModel.Id} was not found!");
            }
            User userDb = _userRepository.GetById(noteModel.UserId);
            if (userDb == null)
            {
                throw new NotFoundException($"The user with id {noteModel.UserId} was not found");
            }
            if (string.IsNullOrEmpty(noteModel.Text))
            {
                throw new NoteException("The property Text for note is required");
            }
            if (noteModel.Text.Length > 100)
            {
                throw new NoteException("The property Text can not contain more than 100 characters");
            }
            if (!string.IsNullOrEmpty(noteModel.Color) && noteModel.Color.Length > 30)
            {
                throw new NoteException("The property Color can not contain more than 30 characters");
            }

            noteDb.Text = noteModel.Text;
            noteDb.Color = noteModel.Color;
            noteDb.Tag = noteModel.Tag;
            noteDb.UserId = noteModel.UserId;
            noteDb.User = userDb;
            _noteRepository.Update(noteDb);
        }
    }
}
