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
            return _noteRepository.GetAll().Where(x => x.UserId == userId)
                                        .Select(note => NoteMapper.NoteModelToNoteDto(note)).ToList();
        }
    }
}
