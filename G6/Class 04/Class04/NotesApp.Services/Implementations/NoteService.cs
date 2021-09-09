using NoteApp.Domain;
using NotesApp.DataAccess;
using NotesApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace NotesApp.Services.Implementations
{
    public class NoteService : INoteService
    {
        private IRepository<Note> _noteRepository;
        public NoteService()
        {
            _noteRepository = new NotesRepository();
        }
        public void AddNote(Note note)
        {
            _noteRepository.Add(note);
        }

        public void DeleteNote(int id)
        {
            _noteRepository.Delete(id);
        }

        public List<Note> GetAllNotes()
        {
            return _noteRepository.GetAll();
        }

        public Note GetNoteById(int id)
        {
            return _noteRepository.GetById(id);
        }

        public void UpdateNote(Note note)
        {
            _noteRepository.Update(note);
        }
    }
}
