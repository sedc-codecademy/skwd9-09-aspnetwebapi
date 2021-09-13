using Notes.Models.Data;
using Notes.Models.Dto;
using Notes.Models.Enums;
using Notes.Models.Mappers;
using Notes.Repository.IRepository;
using Notes.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Notes.Services
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
            return _noteRepository.GetAll().Where(x => x.UserId == userId)
                                           .Select(note => NoteMapper.NoteModelToNoteDto(note)).ToList();
        }
        public NoteDto GetNoteDetails(int noteId, int userId)
        {
            var note = _noteRepository.GetAll().FirstOrDefault(x => x.Id == noteId && x.UserId == userId);

            if (note == null)
            {
                throw new Exception("Record not found");
            }

            //return new NoteDto
            //{
            //    Id = note.Id,
            //    Text = note.Text,
            //    Color = note.Color,
            //    TagType = (TagType)note.Tag,
            //    UserId = note.UserId
            //};
            var nodeModel = NoteMapper.NoteModelToNoteDto(note);

            return nodeModel;
        }

        public string AddNote(NoteDto note)
        {
            if (string.IsNullOrEmpty(note.Text))
            {
                throw new Exception("Note text is empty");
            }

            if (string.IsNullOrEmpty(note.Color))
            {
                throw new Exception("Note color is empty");
            }

            var noteModel = NoteMapper.NoteDtoToNoteModel(note);
            _noteRepository.Add(noteModel);

            return "Note successfully added";
        }

        public string DeleteNote(int noteId, int userId)
        {
            var note = _noteRepository.GetAll().FirstOrDefault(x => x.Id == noteId && x.UserId == userId);

            if (note == null)
            {
                throw new Exception("Not was not found");
            }

            _noteRepository.Delete(note);

            return "Note deleted successfully";
        }

        public void UpdateNote(NoteDto note)
        {
            var noteDetails = _noteRepository.GetAll().FirstOrDefault(x => x.Id == note.Id && x.UserId == note.UserId);

            if (noteDetails == null)
            {
                throw new Exception("Not was not found");
            }

            var mappedNote = NoteMapper.NoteDtoToNoteModel(note);
            _noteRepository.Update(mappedNote);
        }

        public List<NoteDto> GetUserNotesFilteredByDateTime(int userId, DateTime dateTime)
        {
            return _noteRepository.GetAll().Where(x => x.UserId == userId && x.DateCreated >= dateTime)
                                           .Select(note => NoteMapper.NoteModelToNoteDto(note)).ToList();
        }
    }
}
