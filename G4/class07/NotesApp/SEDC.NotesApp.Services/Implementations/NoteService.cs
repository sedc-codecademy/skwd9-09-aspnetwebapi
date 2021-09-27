using SEDC.NotesApp.DataAccess;
using SEDC.NotesApp.Domain.Models;
using SEDC.NotesApp.Mappers;
using SEDC.NotesApp.Models;
using SEDC.NotesApp.Services.Interfaces;
using SEDC.NotesApp.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SEDC.NotesApp.Services.Implementations
{
    public class NoteService : INoteService 
    {
        private IRepository<Note> _noteRepository;
        public NoteService(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
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
                throw new NotFoundException($"Note with id {id} was not found");
            }

            return noteDb.ToNoteModel();
        }
    }
}
