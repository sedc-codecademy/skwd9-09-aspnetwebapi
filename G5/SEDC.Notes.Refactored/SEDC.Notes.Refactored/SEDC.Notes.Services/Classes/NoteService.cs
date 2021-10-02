using SEDC.Notes.DataAccess.Repositories.Interfaces;
using SEDC.Notes.DomainModels;
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
            // we will do validation later!

            var Note = new Note()
            {
                Text = requestModel.Text,
                Color = requestModel.Color,
                Tag = (int)requestModel.Tag,
                UserId = requestModel.UserId
            };

            _noteRepository.Add(Note);
        }

        public IEnumerable<NoteRequestModel> GetUserNotes(int userId)
        {
            var userNotes = _noteRepository.GetAll()
                                           .Where(x => x.UserId == userId);

            var notesRequestModel = new List<NoteRequestModel>();

            foreach (var note in userNotes)
            {
                var noteRequestModel = new NoteRequestModel()
                {
                    Id = note.Id,
                    Text = note.Text,
                    Color = note.Color,
                    Tag = (TagType)note.Tag,
                    UserId = note.UserId
                };

                notesRequestModel.Add(noteRequestModel);
            }

            return notesRequestModel;

            //return _noteRepository.GetAll()
            //                      .Where(x => x.UserId == userId)
            //                      .Select(x =>
            //                        new NoteRequestModel()
            //                        {
            //                            Id = x.Id,
            //                            Text =  x.Text,
            //                            Color = x.Color,
            //                            Tag = (TagType)x.Tag,
            //                            UserId = x.UserId
            //                        }
            //                      );
        }

        public NoteRequestModel GetUserNoteById(int userId, int id)
        {
            var note = _noteRepository.GetAll()
                                      .SingleOrDefault(x => x.UserId == userId && x.Id == id);

            //validation

            var noteRequestModel = new NoteRequestModel()
            {
                Id = note.Id,
                Text = note.Text,
                Color = note.Color,
                Tag = (TagType)note.Tag,
                UserId = note.UserId
            };

            return noteRequestModel;
        }

        public void DeleteNoteById(int userId, int id)
        {
            var note = _noteRepository.GetAll()
                                      .SingleOrDefault(x => x.UserId == userId && x.Id == id);

            //validation

            _noteRepository.Delete(note);
        }

        public void UpdateNote(NoteRequestModel requestModel)
        {
            var note = _noteRepository.GetAll()
                                      .SingleOrDefault(x => x.UserId == requestModel.UserId && x.Id == requestModel.Id);

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
