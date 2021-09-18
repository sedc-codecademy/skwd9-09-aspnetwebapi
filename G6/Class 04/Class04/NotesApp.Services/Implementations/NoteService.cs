using NoteApp.Domain;
using NoteApp.Domain.Models;
using NotesApp.DataAccess;
using NotesApp.Services.Interfaces;
using SEDC.NotesApp.Models;
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
        public void AddNote(NoteModel note)
        {
            _noteRepository.Add(note);
        }

        public void DeleteNote(int id)
        {
            _noteRepository.Delete(id);
        }

        public List<NoteModel> GetAllNotes()
        {
            List<Note> notesDb = _noteRepository.GetAll();
            List<NoteModel> noteModels = new List<NoteModel>();

            return noteModels;
        }

        public NoteModel GetNoteById(int id)
        {
            return _noteRepository.GetById(id);
        }

        public void UpdateNote(NoteModel note)
        {
            _noteRepository.Update(note);
        }
    }
}
