using SEDC.Notes.Models.Data;
using SEDC.Notes.Models.Dto;
using SEDC.Notes.Models.Mappers;
using SEDC.Notes.Repositories.IRepository;
using SEDC.Notes.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SEDC.Notes.Services.Classes
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;

        public NoteService(IRepository<Note> noteRepository)
        {
            _noteRepository = noteRepository;
        }
        public List<NoteDto> GetUserNotes(int userId)
        {
            if (userId < 1) 
            {
                throw new Exception("Invalid userId!");
            }

            return _noteRepository.GetAll().Where(x => x.UserId == userId)
                                           .Select(note => NoteMapper.NoteModelToNoteDto(note)).ToList();
        }

        public string AddNote(NoteDto note)
        {
            if (string.IsNullOrEmpty(note.Text)) 
            {
                throw new Exception("Note text is empty.");
            }

            if (string.IsNullOrEmpty(note.Color))
            {
                throw new Exception("Note color is empty.");
            }

            var noteModel = NoteMapper.NoteDtoToNoteModel(note);
            _noteRepository.Add(noteModel);

            return "Note successfully added!";
        }

        public NoteDto GetNoteDetails(int noteId, int userId)
        {
            var note = _noteRepository.GetAll().FirstOrDefault(x => x.Id == noteId && x.UserId == userId);

            if (note == null) 
            {
                throw new Exception("Record not found!");
            }

            return NoteMapper.NoteModelToNoteDto(note);
        }

        public string DeleteNote(int noteId, int userId)
        {
            var note = _noteRepository.GetAll().FirstOrDefault(x => x.Id == noteId && x.UserId == userId);

            if (note == null)
            {
                throw new Exception("Record not found!");
            }

            _noteRepository.Delete(note);

            return "Note succesfully deleted!";
        }

        //potental bug...
        public string UpdateNote(NoteDto note)
        {
            if (note == null) 
            {
                throw new Exception("Note was not found!");
            }

            var noteData = _noteRepository.GetAll().FirstOrDefault(x => x.Id == note.Id && x.UserId == note.UserId);

            if (!string.IsNullOrEmpty(note.Color)) 
            {
                noteData.Color = note.Color;
            }

            if (!string.IsNullOrEmpty(note.Text)) 
            {
                noteData.Text = note.Text;
            }

            if (note.TagType != null) 
            {
                noteData.Tag = (int)note.TagType;
            }

            _noteRepository.Update(noteData);

            return "Note succesfully updated!";
        }
    }
}
