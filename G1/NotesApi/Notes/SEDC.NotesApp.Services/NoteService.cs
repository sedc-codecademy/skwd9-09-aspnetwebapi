using AutoMapper;
using FluentValidation.Results;
using SEDC.NotesApp.DataAccess;
using SEDC.NotesApp.DataModels;
using SEDC.NotesApp.Models;
using SEDC.NotesApp.Services.CustomExceptions;
using SEDC.NotesApp.Services.Helpers.Mappers;
using SEDC.NotesApp.Services.Helpers.Validators;
using SEDC.NotesApp.Services.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SEDC.NotesApp.Api.Services
{
    public class NoteService : INoteService
    {
        private readonly IRepository<Note> _noteRepository;
        private readonly IMapper _mapper;
        public NoteService(IRepository<Note> noteRepository, IMapper mapper)
        {
            _noteRepository = noteRepository;
            _mapper = mapper;
        }

        public List<NoteModel> GetUserNotes(int userId)
        {
            //mapping with static function mappers
            //return _noteRepository.GetAll().Where(x => x.UserId == userId)
            //                               .Select(note => NoteMapper.NoteModelToNoteModel(note)).ToList();

            //mapping with select
            //return _noteRepository.GetAll().Where(x => x.UserId == userId)
            //                               .Select(note => new NoteModel
            //                               {
            //                                   Id = note.Id,
            //                                   Color = note.Color,
            //                                   Text = note.Text,
            //                                   TagType = (TagType)note.Tag,
            //                                   UserId = note.UserId,
            //                                   DateCreated = note.DateCreated
            //                               }).ToList();

            //mapping with automaper
            var userNotes = _noteRepository.GetAll().Where(x => x.UserId == userId).ToList();

            var mappedList = userNotes.Select(note => _mapper.Map<NoteModel>(note)).ToList();

            return mappedList;
        }
        public NoteModel GetNoteDetails(int noteId, int userId)
        {
            var note = _noteRepository.GetAll().FirstOrDefault(x => x.Id == noteId && x.UserId == userId);

            if (note == null)
            {
                throw new NoteException($"Note with id:{noteId} for user with id:{userId} was not found");
            }

            //return new NoteModel
            //{
            //    Id = note.Id,
            //    Text = note.Text,
            //    Color = note.Color,
            //    TagType = (TagType)note.Tag,
            //    UserId = note.UserId
            //};
            var nodeModel = NoteMapper.NoteModelToNoteModel(note);

            return nodeModel;
        }

        public string AddNote(NoteModel note)
        {
            if (string.IsNullOrEmpty(note.Text))
            {
                throw new NoteException("Note text is empty");
            }

            //implementation with fluent validation
            //NoteValidator noteValidator = new NoteValidator();
            //ValidationResult validationResult = noteValidator.Validate(note);

            //if (!validationResult.IsValid)
            //{
            //    throw new NoteException(validationResult.Errors.FirstOrDefault().ErrorMessage);
            //}
            
            if (string.IsNullOrEmpty(note.Color))
            {
                //some case scenario where we're returning different exception(not NoteException)
                //throw new Exception("Note color is empty");
                throw new NoteException("Note color is empty");
            }

            // var noteModel = NoteMapper.NoteModelToNoteModel(note);
            var noteModel = _mapper.Map<Note>(note);
            noteModel.DateCreated = DateTime.Now;

            _noteRepository.Add(noteModel);

            return "Note successfully added";
        }

        public string DeleteNote(int noteId, int userId)
        {
            var note = _noteRepository.GetAll().FirstOrDefault(x => x.Id == noteId && x.UserId == userId);

            if (note == null)
            {
                throw new NoteException($"Note with id: {noteId} for user with id: {userId}, was not found");
            }

            _noteRepository.Delete(note);

            return "Note deleted successfully";
        }

        public void UpdateNote(NoteModel note)
        {
            var noteDetails = _noteRepository.GetAll().FirstOrDefault(x => x.Id == note.Id && x.UserId == note.UserId);

            if (noteDetails == null)
            {
                throw new NoteException("Note was not found");
            }

            var mappedNote = NoteMapper.NoteModelToNoteModel(note);
            _noteRepository.Update(mappedNote);
        }

        public List<NoteModel> GetUserNotesFilteredByDateTime(int userId, DateTime dateTime)
        {
            return _noteRepository.GetAll().Where(x => x.UserId == userId && x.DateCreated >= dateTime)
                                           .Select(note => NoteMapper.NoteModelToNoteModel(note)).ToList();
        }
    }
}
